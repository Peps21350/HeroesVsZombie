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
        private static float HeroesHp;
        [SerializeField] private Text text_count_coins;
        
        [SerializeField] private Button[] buttons_spawn = null;
        
        private bool isGameStopped = false;
        public static int timer = 0;

        public GameObject[] raw_image = new GameObject[4];
        
        public static int count_coins;
        public int count_coins_per_seconds = 2;
        
        private Rect windowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 600) / 2, 400, 600);
        //public new Camera camera;

        private bool show = false;
        private bool pause = false;
        private bool finish = false;

        public GUIStyle[] labelStyle;


        public void Awake()
        {
            if ( instance == null ) 
                instance = this;
        }
        
        private void  Update()
        {
            SetTextCountCoins();
            ShowHPHeroes();
            HideCurtain();
            if (Input.GetKey("escape"))
            {
                Open(true,false);
            }
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

        private void ShowHPHeroes()
        {
            float all_health = NpcSpawner.all_health;
            text_health_heroes.text = $"{(int)all_health}";
        }
        

        private void HideCurtain()
        {
            raw_image[0].SetActive(!(count_coins >= 10));
            raw_image[1].SetActive(!(count_coins >= 15));
            raw_image[2].SetActive(!(count_coins >= 25));
            raw_image[3].SetActive(!(count_coins >= 35));
        }
        

        IEnumerator Timer() 
        {        
            while(true) 
            {       
                if (!isGameStopped) 
                {
                    Debug.Log("TimerCount: " + (timer++));
                    yield return new WaitForSeconds(1);             
                }
                yield return null;
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void Start() 
        {  
            ShowButtonsSpawn(false);
            StartCoroutine(Timer());
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
            Time.timeScale = 0;
            
            if (GUI.Button(new Rect(5, 330, windowRect.width - 10, 60), "Continue", NewGuiStyle() ))
            {
                Time.timeScale = 1;
                show = false;
            }

            if (GUI.Button(new Rect(5, 400, windowRect.width - 10, 60), "Restart", NewGuiStyle()))
            {
                SceneManager.LoadScene("FirstScene");
                timer = 0;
                count_coins = 0;
                show = false;
            }

            if (GUI.Button(new Rect(5, 470, windowRect.width - 10, 60), "Exit", NewGuiStyle()))
            {
                SceneManager.LoadScene("MainMenu");
                show = false;
            }
        }

        void DialogWindow(int windowID)
        {

            GUI.Label(new Rect(5, 5, windowRect.width, 360),"",labelStyle[windowID]);
            
            Time.timeScale = 0;
            
            if (GUI.Button(new Rect(5, 380, windowRect.width - 10, 70), "Restart", NewGuiStyle()))
            {
                SceneManager.LoadScene("FirstScene");
                timer = 0;
                count_coins = 0;
                show = false;
            }

            if (GUI.Button(new Rect(5, 450, windowRect.width - 10, 70), "Exit", NewGuiStyle()))
            {
                SceneManager.LoadScene("MainMenu");
                show = false;
            }
        }

        public void Open(bool pause, bool finish)
        {
            show = true;
            this.pause = pause;
            this.finish = finish;
        }


    }
    
}