using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // public GameObject buttonPlay;
    // public GameObject buttonShop;
    // public GameObject buttonExit;
    // public GameObject buttonOptions;
    public GameObject allButtons;
    
    
    
    
    public void Exit()
    {
        Application.Quit();
    }

    public void SetActiveButtons(bool state)
    {
        allButtons.SetActive(state);
    }

    public void Shop()
    {
        SetActiveButtons(false);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstScene");
    }
    
    
    

}
