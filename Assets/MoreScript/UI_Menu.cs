using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//конечно тоже можно было писать класс чтобы от него наследоваться и не писать кнопки, но для этого нужно было думать
public class UI_Menu : MonoBehaviour
{
    public Text textApple;
    public Text textReccord;
    void Start()
    {
        Vibration.Init();
        SaveGame.StartNewGame();
        textApple.text += SaveGame.GetApple();
        textReccord.text += SaveGame.GetRecord();
    }
    public void bt_Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void bt_Shop()
    {       
        SceneManager.LoadScene("Shop");        
    }

    
}
