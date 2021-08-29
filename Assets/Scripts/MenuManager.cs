using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject[] block_hero;
    public GameObject[] buttons_buy;
    public GameObject menu_buttons;
    public GameObject button_back;
    public Text text_amount_coin;
    public GameObject shop_elements;
    

    
    private List<int> _price = new List<int>(3);
    public static List<bool> StateOfPurchase = new List<bool>();
    
    
     public Text text_information_about_hero;

    public void ShowInformation(string name, float health, float speedOfMovement, int priceToSpawn,int damage)
    {
        text_information_about_hero.text = $"Name: {name}\n" +
                                           $"Health: {health}\n" +
                                           $"Speed: {speedOfMovement}\n" +
                                           $"Price to spawn: {priceToSpawn}\n"+
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
        if (GameManager.CountMoney >= _price[number] && StateOfPurchase[number] == false)
        {
            SavePrefs.MoneyToSave -= _price[number];
            GameManager.CountMoney -= _price[number];
            StateOfPurchase[number] = true;
            ChangeStatusBeforeRecording();
            block_hero[number].SetActive(false);
            SavePrefs.Save();
        }

        else
        {
            Debug.Log("No money");
            text_information_about_hero.text = $"Not enough money\nIts cost: {_price[number]}";
        }
    }

    private void ShowLock()
    {
        for (int i = 0; i < StateOfPurchase.Count && i <= 2; i++)
        {
            if (StateOfPurchase[i])
            {
                block_hero[i].SetActive(false);
                buttons_buy[i].SetActive(false);
            }
        }
    }


    public void ChangeStatusBeforeRecording()
    {
        SavePrefs.StateItem[0] = Convert.ToString(StateOfPurchase[0]);
        SavePrefs.StateItem[1] = Convert.ToString(StateOfPurchase[1]);
        SavePrefs.StateItem[2] = Convert.ToString(StateOfPurchase[2]);
    }
    

    private void Update()
    {
        text_amount_coin.text = GameManager.CountMoney.ToString();
        if (button_back.activeInHierarchy)
        {
            ShowLock();
        }
    }

    private void Start()
    {
        SavePrefs.LoadData();
        AddPrice();
    }

    private void AddPrice()
    {
        _price.Add(25);
        _price.Add(35);
        _price.Add(50);
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
