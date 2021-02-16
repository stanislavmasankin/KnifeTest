using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    float speed = 0;
    float speed1 = 0;
    float speed2 = 0;


    CircleData data;
    GameObject Knifs;
    public bool CanDestroy = false;
    public Vector2 knifePos = new Vector2(0, 1.4f);
    public Vector2 applePos = new Vector2(0, 0.65f);


    
    public GameObject oskLeft;
    public GameObject oskRigt;

    Animator _animator;
    private void Start()
    {
        //конечно с аниматором работать через скорости глупо, но она всего 1, и так сойдет
        _animator = GetComponent<Animator>();
        _animator.speed = 0;
        knifePos = new Vector2(0, 1.4f);
    }
    float sum = 0;
    void Move() {
        
        if (speed2 != 0) {
            sum += Time.fixedDeltaTime;
            speed = speed1 + Mathf.Sin(sum * speed2) * speed1;
        }            
        transform.Rotate(Vector3.forward, Time.fixedDeltaTime * speed);
    }
    void FixedUpdate()
    {
        Move();

        //удалиться когда кончиться анимация
        //очень тупо конечно, нужно через event делать, но это тестовое...
        if (CanDestroy) {
            Destroy(gameObject);
            //когда удалиться заного заспавниться круг
            GameObject.Find("Lvl_Info").GetComponent<Lvl>().SpawnNewLvl();
        }  
    }
    //нужно вызвать когда удаляешь круг
    public void DestroyCircle() {
        transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
        _animator.speed = 1;

        speed = 0;
        speed1 = 0;
        speed2 = 0;


        for (int i=0;i<Knifs.transform.childCount;i++) {
            if (Knifs.transform.GetChild(i).gameObject.tag != "Apple")
                Knifs.transform.GetChild(i).gameObject.GetComponent<Knife>().DestroyA();
            else
                Destroy(Knifs.transform.GetChild(i).gameObject);
        }
    }
    //нужно вызвать когда добавляешь нож
    public void AddKnife(GameObject knife)
    {
        knife.transform.SetParent(Knifs.transform);
    }

    //задает скорости и кол-во ножей и яблок
    public void SetCircle(LvlData lvlData,int circleId) {

        speed = lvlData.speed1;
        speed1 =  lvlData.speed1;
        speed2 = lvlData.speed2;
        SpawnCircleAndApple(lvlData.knifeInCircle,lvlData.apple);

        //тут изи скрипт обжекта перется спрайты
        CircleData cd =  Resources.Load("CircleObject/" + circleId) as CircleData;
        oskLeft.GetComponent<SpriteRenderer>().sprite = cd.sprite;
        oskRigt.GetComponent<SpriteRenderer>().sprite = cd.sprite;
    }
    void SpawnCircleAndApple(int col,int colApple) {
        Knifs = new GameObject();
        Knifs.transform.SetParent(gameObject.transform);
        Knifs.transform.localPosition = new Vector3(0, 0, 0);
        Knifs.name = "Knifs";

        for (int i = 0; i < col; i++) {
            Vector2 pos = Quaternion.AngleAxis((360 / (col+ colApple)) * i, Vector3.forward) * ((Vector2)transform.position - knifePos);
            pos += (Vector2)transform.position;
            GameObject knife =  Instantiate(Resources.Load("knife") as GameObject, pos, Quaternion.identity);
            knife.GetComponent<Knife>().SetKnife(0,false);
            
            knife.transform.rotation = Quaternion.Euler(0,0, (360 / (col+ colApple)) * i-180);
            knife.name = "knife_Block";
            AddKnife(knife);
            
        }        
        if (colApple != 0)
        {
            for (int i = col; i < col + colApple; i++)
            {
                Vector2 pos = Quaternion.AngleAxis((360 / (col + colApple)) * (i), Vector3.forward) * ((Vector2)transform.position - applePos);
                pos += (Vector2)transform.position;
                GameObject apple = Instantiate(Resources.Load("apple") as GameObject, pos, Quaternion.identity);

                apple.transform.rotation = Quaternion.Euler(0, 0, (360 / (col + colApple)) * (i) );
                apple.name = "apple_Block";
                AddKnife(apple);

            }
           
        }


    }







}
