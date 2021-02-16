using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlData 
{
    public int knifeInCircle = 0;
    public int knife = 0;
    public int apple = 0;
    public float speed1 = 0;
    public float speed2 = 0;


    override
    public string ToString() {
        string res = "";

        res = "s1 = " + speed1 + "" +
            " s2 =" + speed2 + "" +
            " k = "+ knife+"" +
            " a = "+ apple+"" +
            " kIC = "+ knifeInCircle;
        return res;
    }
}
