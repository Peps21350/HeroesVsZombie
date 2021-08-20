using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // public GameObject buttonPlay;
    public GameObject[] block_hero;
    public GameObject[] buttons_buy;
    public GameObject menu_buttons;
    public GameObject button_back;
    public GameObject button_options;
    public Text text_amount_coin;
    public GameObject shop_elements;
    
    public static MenuManager instance = null;
    
    private List<int> price = new List<int>(3);
    public static List<bool> state_of_purchase = new List<bool>(3);
    
    
     public Text text_information_about_hero;

    public void ShowInformation(string name, float health, float speed_of_movement, int price_to_spawn,int damage)
    {
        text_information_about_hero.text = $"Name: {name}\n" +
                                           $"Health: {health}\n" +
                                           $"Speed: {speed_of_movement}\n" +
                                           $"Price to spawn: {price_to_spawn}\n"+
                                           $"Damage: {damage}";

    }

    public void ShowInformationInfantryman()
    {
        ShowInformation("Infantryman",75,10,10,10);
    }
    public void ShowInformationInfantryman2()
    {
        ShowInformation("Hard infantryman",150,9f,35,12);
    }
    public void ShowInformationRobot()
    {
        ShowInformation("Robot",90, 10, 15,12);
    }
    public void ShowInformationRobot2()
    {
        ShowInformation("Robot v2",60,10,25,12);
    }

    public void Awake()
    {
        if ( instance == null ) 
            instance = this;
    }

    public void WantBuyRobot()
    {
        BuyHero(0);
    }
    public void WantBuyRobot2()
    {
        BuyHero(1);
    }
    public void WantBuyInfantryman()
    {
        BuyHero(2);
    }

    private void BuyHero(int number)
    {
        if (GameManager.count_money >= price[number] && state_of_purchase[number] == false)
        {
            SavePrefs.moneyToSave -= price[number];
            GameManager.count_money -= price[number];
            state_of_purchase[number] = true;
            ChangeStateBeforeWrite();
            block_hero[number].SetActive(false);
            SavePrefs.Save();
        }

        else
        {
            Debug.Log("No money");
            text_information_about_hero.text = $"Not enough money\nIts cost: {price[number]}";
        }
    }

    private void ShowLock()
    {
        for (int i = 0; i < state_of_purchase.Count; i++)
        {
            if (state_of_purchase[i])
            {
                block_hero[i].SetActive(false);
                buttons_buy[i].SetActive(false);
            }

            
        }
    }


    public void ChangeStateBeforeWrite()
    {
        SavePrefs.stateitem[0] = Convert.ToString(state_of_purchase[0]);
        SavePrefs.stateitem[1] = Convert.ToString(state_of_purchase[1]);
        SavePrefs.stateitem[2] = Convert.ToString(state_of_purchase[2]);
    }
    

    private void Update()
    {
        text_amount_coin.text = GameManager.count_money.ToString();
        ShowLock();
    }

    private void Start()
    {
        SavePrefs.LoadData();
        AddPrice();
    }

    private void AddPrice()
    {
        price.Add(25);
        price.Add(35);
        price.Add(50);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Shop()
    {
        menu_buttons.SetActive(false);
        button_back.SetActive(true);
        shop_elements.SetActive(true);
    }

    public void BackToMenu()
    {
        menu_buttons.SetActive(true);
        button_back.SetActive(false);
        shop_elements.SetActive(false);
    }

    public void Options()
    {
        menu_buttons.SetActive(false);
        button_back.SetActive(true);
        shop_elements.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
        
    }
    




}
