using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textHealthHeroes;
    public Text textHealthZombie;
    private static float s_heroesHp;
    public static int Level;
        
    private bool _isStartGame  = true;

    [SerializeField] private Text textCountCoins;
        
    [SerializeField] private Button[] buttonsSpawn = null;

    [SerializeField] private GameObject[] allowedHeroes;
    [SerializeField] private NpcSpawner npcSpawner;
        
    private bool isGameStopped = false;
    public static int GameTimer = 0;

    public GameObject[] blockImageForHeroes = new GameObject[4];
    public static List<NpcId> SelectedNpc = new List<NpcId>();
    public static int CountCoins;
    public static int CountMoney;
    public int countCoinsPerSeconds = 2;

    private static bool s_itsFirstTime = true;
        
    private Rect _windowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 600) / 2, 400, 600);

    private bool _show = false;
    private bool _pause = false;
    private bool _finish = false;

    public GUIStyle[] labelStyle;
    


    private void CheckSelectedHeroes()
    {
        if (!s_itsFirstTime)
        {
            int countAddHeroes = 4 - (SelectedNpc.Count);
            for (int i = 0; i < countAddHeroes; i++)
            {
                SelectedNpc.Add(NpcId.None); 
            }
        }
        else
        {
            int countAddHeroes = 4 - SelectedNpc.Count;
            for (int i = 0; i < countAddHeroes; i++)
            {
                SelectedNpc.Add(NpcId.None); 
            }   
        }

    }

    private void SetHeroes()
    {
        if (SelectedNpc == null || SelectedNpc.Count == 0) return;
        for (int i = 0; i < 4; i++)
        {
            switch (SelectedNpc[i])
            {
                case NpcId.Infantryman:
                    allowedHeroes[0].SetActive(true);
                    break;
                case NpcId.Robot:
                    allowedHeroes[1].SetActive(true);
                    break;
                case NpcId.Robot2:
                    allowedHeroes[2].SetActive(true);
                    break;
                case NpcId.Infantryman2:
                    allowedHeroes[3].SetActive(true);
                    break;
                default:
                    for (int j = 0; j < allowedHeroes.Length; j++)
                    {
                        if(allowedHeroes[j].activeInHierarchy == false)
                            blockImageForHeroes[j].SetActive(false);
                    }
                    break;
            }
        }
    }


    private void  Update()
    {
        SetTextCountCoins();
        ShowHP();
        HideCurtain();
        SetHeroes();

        if (Input.GetKey("escape"))
        {
            Open(true,false);
        }
            

        if ((NpcSpawner.HealthZombie == 0  && _isStartGame) && npcSpawner.createdZombies[0].current_health == 0)
        {
            _isStartGame = false;
            CountMoney += CountCoins;
            SavePrefs.MoneyToSave = CountMoney;
            SavePrefs.Save();
            Debug.Log("Writed");
            Open(false,true);
        }

    }

    public void Pause()
    {
        Open(true,false);
    }


    public void ShowButtonsSpawn(bool state)
    {
        if (buttonsSpawn[0] != null)
        {
            foreach (Button button in buttonsSpawn)
            {
                button.gameObject.SetActive(state);
            }
        }
        else
            Debug.Log("Button array = null");
    }

    private void ShowHP()
    {
        textHealthHeroes.text = $"{(int)NpcSpawner.HealthHeroes}";
        textHealthZombie.text = $"{(int)NpcSpawner.HealthZombie}";
    }
        

    private void HideCurtain()
    {
        blockImageForHeroes[0].SetActive(!(CountCoins >= 10));
        blockImageForHeroes[1].SetActive(!(CountCoins >= 15));
        blockImageForHeroes[2].SetActive(!(CountCoins >= 25));
        blockImageForHeroes[3].SetActive(!(CountCoins >= 35));
    }
        
    IEnumerator Timer(int value) 
    {        
        while(true) 
        {       
            if (!isGameStopped) 
            {
                Debug.Log("TimerCount: " + (GameTimer++));
                if(GameTimer == 18 - value)
                    npcSpawner.SpawnZombie(2);
                yield return new WaitForSeconds(1);             
            }
            yield return null;
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void Start()
    {
        GameTimer = 0;
        CountCoins = 0;
        Time.timeScale = 1;
        ShowButtonsSpawn(false);
        StartCoroutine(Timer(Level));
        Debug.Log($"{Level}");
        CheckSelectedHeroes();
        SetHeroes();
        ShowHP();
    }
        
    private void SetTextCountCoins()
    {
        CountCoins = +GameTimer * countCoinsPerSeconds;
        textCountCoins.text = $"{CountCoins}";
    }

    public Font font;
        
    void OnGUI()
    {
        if (_show && _pause && !_finish)
        {
            _windowRect = GUI.Window(1, _windowRect, DialogWindowPause, "");
        }
        if(_show && !_pause && !_finish)
        {
            _windowRect = GUI.Window(0, _windowRect, DialogWindow, ""); 
        }
        if (_show && _finish && !_pause) 
        {
            _windowRect = GUI.Window(2, _windowRect, DialogWindow, ""); 
        }
    }

    private GUIStyle SetNewGuiStyle()
    {
        GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
        guiStyle.fontSize = 28;
        return guiStyle;
    }

    void DialogWindowPause(int windowID)
    {
        GUI.Label(new Rect(5, 5, _windowRect.width, 320), "", labelStyle[1]);

        if (GUI.Button(new Rect(5, 330, _windowRect.width - 10, 60), "Continue", SetNewGuiStyle() ))
        {
            Time.timeScale = 1;
            _show = false;
        }

        if (GUI.Button(new Rect(5, 400, _windowRect.width - 10, 60), "Restart", SetNewGuiStyle()))
        {
            SceneManager.LoadScene("FirstScene");
            _show = false;
        }

        if (GUI.Button(new Rect(5, 470, _windowRect.width - 10, 60), "Exit", SetNewGuiStyle()))
        {
            SceneManager.LoadScene("MainMenu");
            SelectedNpc.Clear();
            s_itsFirstTime = false;
            _show = false;
        }
    }

    void DialogWindow(int windowID)
    {
        string text = windowID == 2 ? "Next level" : "Restart";

        GUI.Label(new Rect(5, 5, _windowRect.width, 360),"",labelStyle[windowID]);
            
            
        if (GUI.Button(new Rect(5, 380, _windowRect.width - 10, 70), text, SetNewGuiStyle()))
        {
            switch (windowID)
            {
                case 2:
                    Level += 1;
                    break;
            }

            SceneManager.LoadScene("FirstScene");
            _show = false;
        }

        if (GUI.Button(new Rect(5, 460, _windowRect.width - 10, 70), "Exit to menu", SetNewGuiStyle()))
        {
            SceneManager.LoadScene("MainMenu");
            _show = false;
        }
    }

    public void Open(bool pause, bool finish)
    {
        Time.timeScale = 0;
        _show = true;
        this._pause = pause;
        this._finish = finish;
    }


}