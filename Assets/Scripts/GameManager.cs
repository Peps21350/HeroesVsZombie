using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Drawing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        public Text text_health_heroes;
        public Text text_health_zombie;
        private static float HeroesHp;
        public static int level;
        
        private  bool is_start_game = true;
        [SerializeField] private Text text_count_coins;
        
        [SerializeField] private Button[] buttons_spawn = null;

        [SerializeField] private GameObject[] allowed_heroes;
        
        private bool isGameStopped = false;
        public static int timer = 0;

        public GameObject[] block_image_for_heroes = new GameObject[4];
        public static List<NpcId> selected_npc = new List<NpcId>();
        public static int count_coins;
        public static int count_money;
        public int count_coins_per_seconds = 2;

        private static bool its_first_time = true;
        
        private Rect windowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 600) / 2, 400, 600);

        private bool show = false;
        private bool pause = false;
        private bool finish = false;

        //private SavePrefs sp = new SavePrefs();
        
        public GUIStyle[] labelStyle;


        public void Awake()
        {
            //selected_npc.Clear();
            if (instance == null)
            {
                instance = this;
            }
        }


        private void CheckSelectedHeroes()
        {
            if (!its_first_time)
            {
                int count_add_heroes = 4 - (selected_npc.Count);
                for (int i = 0; i < count_add_heroes; i++)
                {
                    selected_npc.Add(NpcId.NONE); 
                }
            }
            else
            {
                int count_add_heroes = 4 - selected_npc.Count;
                for (int i = 0; i < count_add_heroes; i++)
                {
                    selected_npc.Add(NpcId.NONE); 
                }   
            }

        }

        private void SetHeroes()
        {
            if (selected_npc == null || selected_npc.Count == 0) return;
            for (int i = 0; i < 4; i++)
            {
                switch (selected_npc[i])
                {
                    case NpcId.NONE:
                        allowed_heroes[i].SetActive(false);
                        block_image_for_heroes[i].SetActive(false);
                        break;
                    case NpcId.INFANTRYMAN:
                        allowed_heroes[i].SetActive(true);
                        break;
                    case NpcId.ROBOT:
                        allowed_heroes[i].SetActive(true);
                        break;
                    case NpcId.ROBOT2:
                        allowed_heroes[i].SetActive(true);
                        break;
                    case NpcId.INFANTRYMAN2:
                        allowed_heroes[i].SetActive(true);
                        break;
                    default:
                        allowed_heroes[i].SetActive(false);
                        block_image_for_heroes[i].SetActive(false);
                        break;
                }
            }
        }


        private void  Update()
        {
            SetTextCountCoins();
            ShowHP();
            HideCurtain();
            //CheckSelectedHeroes();
            SetHeroes();

            if (Input.GetKey("escape"))
            {
                //Time.timeScale = 0;
                Open(true,false);
            }

            if (NpcSpawner.health_zombie <= 0 && !is_start_game)
            {
                count_money += count_coins;
                SavePrefs.moneyToSave = count_money;
                SavePrefs.Save();
                Debug.Log("Writed");
                //Time.timeScale = 0;
                Open(false,true);
            }
            else
            {
                is_start_game = false;
            }
            
        }

        public void Pause()
        {
            //Time.timeScale = 0;
            Open(true,false);
        }


        public void ShowButtonsSpawn(bool state)
        {
            if (buttons_spawn[0] != null)
            {
                foreach (Button button in buttons_spawn)
                {
                    button.gameObject.SetActive(state);
                }
            }
            else
                Debug.Log("Button array = null");
        }

        private void ShowHP()
        {
            text_health_heroes.text = $"{(int)NpcSpawner.health_heroes}";
            text_health_zombie.text = $"{(int)NpcSpawner.health_zombie}";
        }
        

        private void HideCurtain()
        {
            block_image_for_heroes[0].SetActive(!(count_coins >= 10));
            block_image_for_heroes[1].SetActive(!(count_coins >= 15));
            block_image_for_heroes[2].SetActive(!(count_coins >= 25));
            block_image_for_heroes[3].SetActive(!(count_coins >= 35));
        }
        

        IEnumerator Timer(int value) 
        {        
            while(true) 
            {       
                if (!isGameStopped) 
                {
                    Debug.Log("TimerCount: " + (timer++));
                    if(timer == 18 - value)
                        NpcSpawner.instance_npc_spawner.SpawnZombie(2);
                    yield return new WaitForSeconds(1);             
                }
                yield return null;
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void Start() 
        {  
            timer = 0;
            count_coins = 0;
            Time.timeScale = 1;
            ShowButtonsSpawn(false);
            StartCoroutine(Timer(level));
            Debug.Log($"{level}");
            CheckSelectedHeroes();
            SetHeroes();
        }
        
        private void SetTextCountCoins()
        {
            count_coins = +timer * count_coins_per_seconds;
            text_count_coins.text = $"{count_coins}";
        }

        public Font font;
        
        void OnGUI()
        {
            if (show && pause && !finish)
            {
                windowRect = GUI.Window(1, windowRect, DialogWindowPause, "");
            }
            if(show && !pause && !finish)
            {
                windowRect = GUI.Window(0, windowRect, DialogWindow, ""); 
            }
            if (show && finish && !pause) 
            {
                windowRect = GUI.Window(2, windowRect, DialogWindow, ""); 
            }
        }

        private GUIStyle NewGuiStyle()
        {
            GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
            guiStyle.fontSize = 28;
            return guiStyle;
        }

        void DialogWindowPause(int windowID) //for pause
        {
            GUI.Label(new Rect(5, 5, windowRect.width, 320), "", labelStyle[1]);

            if (GUI.Button(new Rect(5, 330, windowRect.width - 10, 60), "Continue", NewGuiStyle() ))
            {
                Time.timeScale = 1;
                show = false;
            }

            if (GUI.Button(new Rect(5, 400, windowRect.width - 10, 60), "Restart", NewGuiStyle()))
            {
                SceneManager.LoadScene("FirstScene");
                show = false;
            }

            if (GUI.Button(new Rect(5, 470, windowRect.width - 10, 60), "Exit", NewGuiStyle()))
            {
                SceneManager.LoadScene("MainMenu");
                selected_npc.Clear();
                its_first_time = false;
                show = false;
            }
        }

        void DialogWindow(int windowID)
        {
            string text = windowID == 2 ? "Next level" : "Restart";

            GUI.Label(new Rect(5, 5, windowRect.width, 360),"",labelStyle[windowID]);
            
            
            if (GUI.Button(new Rect(5, 380, windowRect.width - 10, 70), text, NewGuiStyle()))
            {
                switch (windowID)
                {
                    case 2:
                        level += 1;
                        break;
                }

                SceneManager.LoadScene("FirstScene");
                show = false;
            }

            if (GUI.Button(new Rect(5, 460, windowRect.width - 10, 70), "Exit to menu", NewGuiStyle()))
            {
                SceneManager.LoadScene("MainMenu");
                show = false;
            }
        }

        public void Open(bool pause, bool finish)
        {
            Time.timeScale = 0;
            show = true;
            this.pause = pause;
            this.finish = finish;
        }


    }
    
}