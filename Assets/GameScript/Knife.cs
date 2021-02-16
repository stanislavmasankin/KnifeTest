using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField]
    float speed = 0;
    int startMove = 3;
    public bool CanDestroy = false;
    public GameObject partical;
    Animator _animator;

    public void SetKnife(float speed,bool move) {
        this.speed = speed;
        if (move)
            startMove = 0;
        else
            startMove = 3;
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (startMove == 0)
                startMove = 1;
        }
    }
    void FixedUpdate()
    {

        
        if (startMove == 1)
            transform.position = Vector2.MoveTowards(transform.position, Vector3.up * 5, Time.fixedDeltaTime * speed);
        //опять тупо
        if(CanDestroy)
            Destroy(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (startMove == 1)
        {
            //тут конечномонжон было сделать через интерфейсы, но когда обьекта всего три не страшно
            //да поиск обьекта по тегу конечно не самый хорший способ, но это тестовое
            Lvl info = GameObject.FindGameObjectWithTag("Info").GetComponent<Lvl>();
            if (collision.gameObject.tag == "Circle")
            {
                startMove = 3;
                gameObject.transform.position = collision.gameObject.GetComponent<Circle>().knifePos;

                collision.gameObject.GetComponent<Circle>().AddKnife(gameObject);
                info.MinusKnife(false);
                Vibration.Vibrate(100);
                partical.GetComponent<ParticleSystem>().Play();


            }
            else if (collision.gameObject.tag == "Apple")
            {
                info.AddApple();
                Destroy(collision.gameObject);
            }
            else
            {
                
                if (startMove == 1) {
                    startMove = 3;
                    DestroyA();
                    info.MinusKnife(true);
                    Vibration.Vibrate(200);
                }
                    
            }
        }
        
    }

    public void DestroyA() {
        _animator.speed = 1;
        
    }

}
