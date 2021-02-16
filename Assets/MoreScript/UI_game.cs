using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_game : MonoBehaviour
{

    public GameObject panelKnife;
    public GameObject panelCircle;
    public Text lvlText;
    public Text appleText;


    public GameObject panel2;
    public Text lvlStatText;
    public Text appleStatText;
    public Text KnifeStatText;



    int knifeMax = 10;
    int circleMax = 5;

    public void UpdatePanel(int lvl,int knife,int circle,int apple)
    {

        lvlText.text = "Lvl: " + lvl;
        appleText.text = apple + "x";

        for (int i = 0; i < knifeMax; i++)
        {
            if (i >= knife)
                panelKnife.transform.GetChild(knifeMax - 1 - i).gameObject.SetActive(false);
            else
                panelKnife.transform.GetChild(knifeMax - 1 - i).gameObject.SetActive(true);
        }
        for (int i = 0; i < circleMax; i++)
        {
            if (i >= circle)
                panelCircle.transform.GetChild(circleMax - 1 - i).gameObject.SetActive(false);
            else
                panelCircle.transform.GetChild(circleMax - 1 - i).gameObject.SetActive(true);
        }

    }

    public void UpdatePanel2(int lvl,int appleStat,int knifeStat)
    {
        panel2.SetActive(true);
        lvlStatText.text += lvl;
        appleStatText.text += appleStat;
        KnifeStatText.text += knifeStat;

    }

    public void bt_Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void bt_Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
