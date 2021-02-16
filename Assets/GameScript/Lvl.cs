using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class Lvl : MonoBehaviour
{
    
    

    int apple = 0;
    int knife = 0;
    int lvl = 0;
    int circle = 0;

    int knifeStat = 0;
    int appleStat = 0;
    

    float speedKnife;

    GameObject circleGO;

    public Vector2 posCircle;
    public Vector2 posKnife;

    void Start()
    {
        
        apple = SaveGame.GetApple();
        SpawnNewLvl();
    }
    //вызывается когда нож собирает яблоко
    public void AddApple() {
        appleStat++;
        apple++;

        UpdateAllText();
    }

    //вызывается когда нож попал в круг
    public void MinusKnife(bool isEnd)
    {
        if (isEnd == false)
        {
            knife--;
            knifeStat++;
            if (knife == 0)
            {
                DestroyCircle();
            }
            else
            {
                KnifeSpawn();
            }
            UpdateAllText();
        }
        else {
            Invoke("Final", 0.3f);
            SaveGame.SaveResultGame(lvl, appleStat);

        }

    }
    //когда все ножи воткнуты нужно их удалить
    void DestroyCircle()
    {
        circle--;
        circleGO.GetComponent<Circle>().DestroyCircle();
    }

    //спавнит нож
    //ну тут кончено нужно было сделать пул, но я не захотел тратить много времени
    void KnifeSpawn() {

        GameObject knifeGb = Instantiate(Resources.Load("knife") as GameObject, posKnife, Quaternion.identity);
        knifeGb.GetComponent<Knife>().SetKnife(speedKnife, true);
    }
    //спавнит круг
    //ну тут кончено нужно было сделать пул, но я не захотел тратить много времени
    void CircleSpawn() {
        if (circleGO != null) {
            GameObject gb = circleGO;
            Destroy(circleGO);
        }
        circleGO = Instantiate(Resources.Load("circle") as GameObject,posCircle,Quaternion.identity);
        //тут изи скрипт обжекта берется шанс
        CircleData cd = Resources.Load("CircleObject/" + SaveGame.GetCircle()) as CircleData;
        LvlData lvlData =  LvlHardGeneration.Generatoin(lvl,circle, cd.apple);
        //в зависимоти он лвл будет выбирать скрипт обжект и по нему выбираться кол-во ножей?
        speedKnife = lvlData.speed1;
        knife = lvlData.knife;
        circleGO.GetComponent<Circle>().SetCircle(lvlData, SaveGame.GetCircle());

    }


    //создать новый уровень после того как был пройден бос
    public void SpawnNewLvl()
    {
        if (circle == 0) {
            circle = 5;
            lvl++;
        }        
        CircleSpawn();
        KnifeSpawn();
        UpdateAllText();
    }

    void UpdateAllText()
    {
        GetComponent<UI_game>().UpdatePanel(lvl,knife,circle,apple);
    }
    void Final()
    {
        GetComponent<UI_game>().UpdatePanel2(lvl,appleStat,knifeStat);
    }




}
