using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    [SerializeField] private MonsterFollower monsterFollower;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            transform.gameObject.tag = "DeathTrap";
            AudioManager.Instance.PlaySFX("KillEnemy");
            animator.SetTrigger("death");
            Destroy(gameObject, 3f);
            monsterFollower.enabled = false;
            rb.bodyType = RigidbodyType2D.Dynamic;

        }
    }
}
