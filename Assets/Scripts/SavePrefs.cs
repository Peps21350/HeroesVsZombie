using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DefaultNamespace;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public static int moneyToSave;
    //public static string[] stateitem = new string[4];

    

    private static readonly string[] keys = new string[] { "Pixel"/*, "MyGame1", "MyGame2", "MyGame3", "MyGame4"*/ };


    public static void Save()
    {
        PlayerPrefs.SetInt(keys[0], moneyToSave);
        // PlayerPrefs.SetString(keys[1], stateitem[0]);
        // PlayerPrefs.SetString(keys[2], stateitem[1]);
        // PlayerPrefs.SetString(keys[3], stateitem[2]);
        // PlayerPrefs.SetString(keys[4], stateitem[3]);
        //PlayerPrefs.SetString(keys[1], "false");
        //PlayerPrefs.SetString(keys[2], "false");
        //PlayerPrefs.SetString(keys[3], "false");
        //PlayerPrefs.SetString(keys[4], "false");
        PlayerPrefs.Save();
    }

    public static void LoadMoney()
    {
        Load();
        GameManager.count_coins = moneyToSave;
        // Shop.state_buying[0] = stateitem[0];
        // Shop.state_buying[1] = stateitem[1];
        // Shop.state_buying[2] = stateitem[2];
        // Shop.state_buying[3] = stateitem[3];


    }

    private static void Load()
    {
        if (PlayerPrefs.HasKey(keys[0]))
        {
            moneyToSave = PlayerPrefs.GetInt(keys[0]);
            // stateitem[0] = PlayerPrefs.GetString(keys[1]);
            // stateitem[1] = PlayerPrefs.GetString(keys[2]);
            // stateitem[2] = PlayerPrefs.GetString(keys[3]);
            // stateitem[3] = PlayerPrefs.GetString(keys[4]);
        }
    }



}