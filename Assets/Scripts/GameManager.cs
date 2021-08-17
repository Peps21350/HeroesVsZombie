using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public Text text_health_heroes;
        private static float HeroesHp;
        [SerializeField] private Text text_count_coins;
        [SerializeField] private Button[] buttons_spawn = new Button[3];
        
        private bool isGameStopped = false;
        [NonReorderable]public static int timer = 0;
        //public event Action<int> onCountCoinChange = delegate {};

        public GameObject[] raw_image = new GameObject[4];
        
        [NonReorderable]public static int count_coins;
        public int count_coins_per_seconds = 2;
        
        private void  Update()
        {
            SetTextCountCoins();
            ShowHPHeroes();
            HideCurtain();
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
            if (count_coins >= 10)
                raw_image[0].SetActive(false);
            if(count_coins >= 15)
                raw_image[1].SetActive(false);
            if(count_coins >= 25)
                raw_image[2].SetActive(false);
            if(count_coins >= 35)
                raw_image[3].SetActive(false);
            if(count_coins < 10)
            {
                foreach (var image in raw_image)
                {
                    image.SetActive(true);
                }
            }

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
        
    }
    
}