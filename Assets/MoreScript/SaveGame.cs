using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SaveGame 
{

    public static void StartNewGame() {

        if (PlayerPrefs.GetString("isFirst") != "false") { 
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("record", 0);
            PlayerPrefs.SetInt("apple", 0);


            CircleBuy circleBuy = new CircleBuy();
            circleBuy.id.Add(1);
            PlayerPrefs.SetString("circleBuy", JsonUtility.ToJson(circleBuy));

            PlayerPrefs.SetInt("circle", 1);

            PlayerPrefs.SetString("isFirst", "false");
        }
        
        

        
    }
    public static void SaveResultGame(int record,int apple) {
        int recordLast = PlayerPrefs.GetInt("record");
        if (recordLast < record || recordLast == 0) {
            PlayerPrefs.SetInt("record", record);
        }
        int appleCol = PlayerPrefs.GetInt("apple");
        PlayerPrefs.SetInt("apple", appleCol+ apple);
    }
    public static void AddNewCircle(int idCircle) {
        CircleBuy circleBuy = GetCircleList();
        circleBuy.id.Add(idCircle);
        PlayerPrefs.SetString("circleBuy", JsonUtility.ToJson(circleBuy));
    }
    static CircleBuy GetCircleList() {

        CircleBuy circleBuy = JsonUtility.FromJson<CircleBuy>(PlayerPrefs.GetString("circleBuy"));
        return circleBuy;
    }
    public static bool IsBuyCircle(int idCircle) {
        CircleBuy circleBuy = GetCircleList();
        foreach (int a in circleBuy.id) {
            if (a == idCircle) {
                return true;
            }
        }
        return false;
    }
    public static int GetRecord()
    {
         return   PlayerPrefs.GetInt("record");        
    }
    public static int GetApple()
    {
        return PlayerPrefs.GetInt("apple");
    }
    public static void SetApple(int apple)
    {
        PlayerPrefs.SetInt("apple",apple);
    }

    public static int GetCircle()
    {
        return PlayerPrefs.GetInt("circle");
    }
    public static void SetCircle(int circleId)
    {
        PlayerPrefs.SetInt("circle", circleId);
    }

}

[Serializable]
public class CircleBuy
{
    public List<int> id;

    public CircleBuy()
    {
        id = new List<int>();
    }
}
