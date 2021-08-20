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
    // public GameObject buttonShop;
    // public GameObject buttonExit;
    // public GameObject buttonOptions;
    public GameObject menu_buttons;
    public GameObject button_back;
    public GameObject button_options;
    public Text text_amount_coin;
    public GameObject shop_elements;
    public static MenuManager instance = null;
    
     public Text text_information_about_hero;

    public void ShowInformation()
    {
        text_information_about_hero.text = "Health: 50";
        
    }
    
    public void Awake()
    {
        if ( instance == null ) 
            instance = this;
    }

    private void Update()
    {
        text_amount_coin.text = GameManager.count_coins.ToString();
    }

    private void Start()
    {
        SavePrefs.LoadMoney();
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

    private void BuyHero()
    {
        
    }




}
