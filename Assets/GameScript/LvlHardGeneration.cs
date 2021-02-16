using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LvlHardGeneration 
{
    //всего ножей может быть 18(максимум) - 3(чтобы можно было попасть)
    static int  maxKnife = 9;
    static float Speed1 = 55;
    static float maxSpeed1 = 250;

    public static LvlData Generatoin(int lvl,int circle,float appleShans)
    {
       // Debug.Log("lvl = "+ lvl+ " circle = "+ circle+ " appleShans = "+ appleShans);

        circle = 5 - circle;
        lvl--;
        LvlData lvlData = new LvlData();





        //скорости
        lvlData.speed1 = Speed1+ (circle + lvl * 5)*2f;
        if (lvlData.speed1 >= maxSpeed1)
            lvlData.speed1 = maxSpeed1;
        lvlData.speed2 = (circle*2+lvl*5);




        
        //ножи
        //каждый 5 лвл бос
        if (circle == 4)
        {
            lvlData.knife = maxKnife;
            if (lvl < 5) {
                lvlData.knifeInCircle = Random.Range(3, 6);
            }                
            else
            {
                lvlData.knifeInCircle = 6;
            }
            //дополнительное яблоко на босе
            appleShans++;
        }
        else {
            int kn = Random.Range(7, 10);
            lvlData.knifeInCircle = (kn/2 / 3) * (circle+lvl);
            lvlData.knife = kn - lvlData.knifeInCircle+2;
        }

        //Яблоки 
        //если передано значение 1.25 то сто процентов появиться одно я блоко + 25 процентов что появиться ещё одно
        while (appleShans > 1)
        {
            appleShans--;
            lvlData.apple++;
        }
        float aplleOne = Random.Range(0, 1f);        
        if (aplleOne < appleShans)
        {
            lvlData.apple++;
        }
        return lvlData;

    }
}
