using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DefaultNamespace;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public static int moneyToSave;
    public static int level_to_save;
    public static string[] stateitem = new string[3];

    

    private static readonly string[] keys = new string[] { "Pixel_money", "Pixel_skin1", "Pixel_skin2", "Pixel_skin3", "Pixel_level" };


    public static void Save()
    {
        PlayerPrefs.SetInt(keys[0], moneyToSave);
        PlayerPrefs.SetString(keys[1], stateitem[0]);
        PlayerPrefs.SetString(keys[2], stateitem[1]); 
        PlayerPrefs.SetString(keys[3], stateitem[2]);
        PlayerPrefs.SetInt(keys[4], level_to_save);

        // PlayerPrefs.SetString(keys[1], "false");
        // PlayerPrefs.SetString(keys[2], "false");
        // PlayerPrefs.SetString(keys[3], "false");

        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        Load();
        GameManager.count_money = moneyToSave;
        MenuManager.state_of_purchase.Add(Convert.ToBoolean(stateitem[0])); 
        MenuManager.state_of_purchase.Add(Convert.ToBoolean(stateitem[1])); 
        MenuManager.state_of_purchase.Add(Convert.ToBoolean(stateitem[2]));
        GameManager.level = level_to_save;
    }

    private static void Load()
    {
        if (PlayerPrefs.HasKey(keys[0]))
        {
            moneyToSave = PlayerPrefs.GetInt(keys[0]);
            stateitem[0] = PlayerPrefs.GetString(keys[1]);
            stateitem[1] = PlayerPrefs.GetString(keys[2]); 
            stateitem[2] = PlayerPrefs.GetString(keys[3]);
            level_to_save = PlayerPrefs.GetInt(keys[4]);
        }
    }



}