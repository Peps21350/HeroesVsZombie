using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {

        public RobotMechanic robot_mechanic;
        public InfantrymanMechanic infantryman_mechanic;
        public Text text_health_heroes;
        private static float HeroesHp;
        public Text text_count_coins;

        [NonReorderable]public static int count_coins;
        public int count_coins_per_seconds = 2;


        private void SumAllHeroesHP()
        {
            HeroesHp = +robot_mechanic.allHealth + infantryman_mechanic.allHealth;
            text_health_heroes.text = $"{HeroesHp}";
        }

        private void  Update()
        {
            SumAllHeroesHP();
            SetTextCountCoins();
        }

        public static void EndGame()
        {
            
        }
        

        public void Pause()
        {
            // movement.enabled = false;
            // gmenu.Open(true,false);
        }

        private void SetTextCountCoins()
        {
            count_coins = +(int) Time.time * count_coins_per_seconds;
            text_count_coins.text = $"{count_coins}";
        }


        public void Finish()
        {
            // movement.enabled = false;
            // NewMothod();
            // gmenu.Open(false, true);
        }
    }
    
}