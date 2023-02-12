using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlife : MonoBehaviour
{
    private Animator animator;

    
    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            AudioManager.Instance.PlaySFX("DeathSound");
        }
        if(collision.gameObject.CompareTag("Wather"))
        {
            animator.SetTrigger("death");
            AudioManager.Instance.PlaySFX("WaterSound");
        }
    }
    private void Die()
    {
        animator.SetTrigger("death");   
    }
    private void RestartLvevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
