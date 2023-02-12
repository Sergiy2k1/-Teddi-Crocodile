using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCloud : MonoBehaviour
{
    public GameObject[] cloud;
    private float[] positions = { 4.13f, 2.65f };
    private float[] positions2 = { 1.29f, 0f };
    private void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(
                cloud[Random.Range(0, cloud.Length)],
                new Vector3(12f, positions[Random.Range(0, positions.Length)], 0f),
                Quaternion.Euler(new Vector3(0, 0, 0))

                );
            yield return new WaitForSeconds(Random.Range(4.1f, 5.5f));
           Instantiate(
                cloud[Random.Range(0, cloud.Length)],
                new Vector3(12f, positions2[Random.Range(0, positions.Length)], 0f),
                Quaternion.Euler(new Vector3(0, 0, 0))

                );
            yield return new WaitForSeconds(Random.Range(4f, 5.7f));

            



        }

    }
}
