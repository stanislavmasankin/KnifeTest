using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Shop : MonoBehaviour
{
    public Text apple;
    public GameObject panelBuy;
    public GameObject panelPlay;

    public Text BuyText;

    public Text PlayText;


    GameObject lastImagaActive;
    int lastCircleId;

    private void Start()
    {
        
        apple.text ="Apple: "+ SaveGame.GetApple();
    }
    public void bt_SelectItem(GameObject Bt)
    {
        //желтый фон off
        if(lastImagaActive!=null)
            lastImagaActive.SetActive(false);
        lastImagaActive = Bt.transform.GetChild(0).gameObject;
        lastImagaActive.SetActive(true);

        lastCircleId = Convert.ToInt32(Bt.name);
        if (SaveGame.IsBuyCircle(lastCircleId))
        {
            panelPlay.SetActive(true);
            panelBuy.SetActive(false);
            SaveGame.SetCircle(lastCircleId);
            UpdatePanelPlay();
        }
        else {
            panelPlay.SetActive(false);
            panelBuy.SetActive(true);
            UpdatePanelBuy();
        }


    }
    
    public void bt_Buy()
    {
        int colApple = SaveGame.GetApple();
        CircleData cd = Resources.Load("CircleObject/" + lastCircleId) as CircleData;
        if (colApple >= cd.appleBuy)
        {
            colApple = colApple - cd.appleBuy;
            SaveGame.SetApple(colApple);
            SaveGame.AddNewCircle(lastCircleId);

            SaveGame.SetCircle(lastCircleId);

            panelPlay.SetActive(true);
            panelBuy.SetActive(false);
            UpdatePanelPlay();
            apple.text = "Apple: " + SaveGame.GetApple();
        }
        else {
            Vibration.Vibrate(200);
        }
    }
    public void bt_Game()
    {
        
        SceneManager.LoadScene("Game");
    }
    public void bt_Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    void UpdatePanelBuy()
    {
        CircleData cd = Resources.Load("CircleObject/" + lastCircleId) as CircleData;
        BuyText.text = "Id: " + cd.id+"" +
            "\nШанс яблока: " + cd.apple+"" +
            "\nЦена: " + cd.appleBuy;

    }
    void UpdatePanelPlay()
    {
        CircleData cd = Resources.Load("CircleObject/" + lastCircleId) as CircleData;
        PlayText.text = "Id: " + cd.id + "" +
            "\nШанс яблока: " + cd.apple;

    }


}
