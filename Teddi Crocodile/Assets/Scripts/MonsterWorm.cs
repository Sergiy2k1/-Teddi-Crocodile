using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWorm : MonoBehaviour
{
    

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("wormUp");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            animator.SetTrigger("wormDown");
        }
    }
}
