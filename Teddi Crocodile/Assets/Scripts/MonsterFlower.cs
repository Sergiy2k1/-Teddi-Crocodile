using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFlower : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private GameObject bullet;


    private void Start()
    {
        StartCoroutine(createBullet());
    }

    IEnumerator createBullet()
    {
        while(true)
        {
            Instantiate(bullet, shootPosition.position, transform.rotation);
            yield return new WaitForSeconds(2f);
        }
        
    }


   
}
