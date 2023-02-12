using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesAxe : MonoBehaviour
{
    private Rigidbody2D rb2;

    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb2.bodyType = RigidbodyType2D.Static;
        }
    }
}
