using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 7f;

    [SerializeField] private bool leftshooting = false;
    [SerializeField] private bool righshooting = false;

    private void FixedUpdate()
    {
        BulletMove();

    }
    private void Update()
    {
        Destroy(gameObject, 2.5f);
    }


    private void BulletMove()
    {
        if (leftshooting)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(righshooting)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider)
        {
            Destroy(gameObject);
        }
    }
   
}
