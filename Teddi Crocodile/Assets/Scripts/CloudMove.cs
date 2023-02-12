using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;


    private void Start()
    {
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        
        CloudRun();
    }

    private void CloudRun()
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);

        if (transform.position.x < -12f)
        {
            Destroy(gameObject);    
        }

    }
}
