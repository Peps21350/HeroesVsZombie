using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using DefaultNamespace;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public static int MoneyToSave;
    public static int LevelToSave;
    public static string[] StateItem = new string[3];


    private static readonly string[] _keys = new string[] { "Pixel_money", "Pixel_skin1", "Pixel_skin2", "Pixel_skin3", "Pixel_level" };


    public static void Save()
    {
        PlayerPrefs.SetInt(_keys[0], MoneyToSave);
        PlayerPrefs.SetString(_keys[1], StateItem[0]);
        PlayerPrefs.SetString(_keys[2], StateItem[1]); 
        PlayerPrefs.SetString(_keys[3], StateItem[2]);
        PlayerPrefs.SetInt(_keys[4], LevelToSave);
        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        Load();
        GameManager.CountMoney = MoneyToSave;
        MenuManager.StateOfPurchase.Add(Convert.ToBoolean(StateItem[0])); 
        MenuManager.StateOfPurchase.Add(Convert.ToBoolean(StateItem[1])); 
        MenuManager.StateOfPurchase.Add(Convert.ToBoolean(StateItem[2]));
        GameManager.Level = LevelToSave;
    }

    private static void Load()
    {
        if (PlayerPrefs.HasKey(_keys[0]))
        {
            if (PlayerPrefs.GetString(_keys[1]) == String.Empty)
            {
                MoneyToSave = PlayerPrefs.GetInt(_keys[0]);
                PlayerPrefs.SetString(_keys[1], "false");
                PlayerPrefs.SetString(_keys[2], "false");
                PlayerPrefs.SetString(_keys[3], "false");
                LevelToSave = PlayerPrefs.GetInt(_keys[4]);
            }

            else
            {
                MoneyToSave = PlayerPrefs.GetInt(_keys[0]);
                StateItem[0] = PlayerPrefs.GetString(_keys[1]);
                StateItem[1] = PlayerPrefs.GetString(_keys[2]); 
                StateItem[2] = PlayerPrefs.GetString(_keys[3]);
                LevelToSave = PlayerPrefs.GetInt(_keys[4]);
            }
            
        }
    }
}