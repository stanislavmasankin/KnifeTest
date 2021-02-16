using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New CircleData", menuName = "Circle Data", order = 51)]
public class CircleData : ScriptableObject
{
    [SerializeField]
    public int id;

    [SerializeField]
    public float apple;

    [SerializeField]
    public Sprite sprite;

    [SerializeField]
    public int appleBuy;

}
