using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollower : MonoBehaviour
{
    [SerializeField] private float speed;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private float positionOfPatrol;
    [SerializeField] private Transform point;
    [SerializeField] bool moveingRight;

    Transform player;
    [SerializeField] private float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    private bool playeIsLife;



    void Start()

    {


        playeIsLife = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        CheakStan();
    }

    private void CheakStan()
    {

        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;

        }


        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
        }

    }

    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
            spriteRenderer.flipX = false;
        }

        if (moveingRight)
        {

            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);

        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        }
    }


    void Angry()
    {
        if (playeIsLife)
        {
            if (transform.position.x > player.position.x)
            {
                moveingRight = false;
                spriteRenderer.flipX = true;

            }
            else if (transform.position.x < player.position.x)
            {
                moveingRight = true;
                spriteRenderer.flipX = false;

            }
            if (moveingRight)
            {

                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                spriteRenderer.flipX = false;

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                spriteRenderer.flipX = true;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playeIsLife = false;
            Debug.Log("playerIsLife " + playeIsLife);
            Goback();
        }
    }

    void Goback()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }


}
