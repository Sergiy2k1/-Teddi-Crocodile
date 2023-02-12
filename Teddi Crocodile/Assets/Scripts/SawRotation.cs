using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{
    [SerializeField] private float speedRotation = 1.4f;
   
    private void Update()
    {
        SawRotate(); 
      
    }
    private void SawRotate()
    {
        transform.Rotate(0, 0, 360 * speedRotation * Time.deltaTime);
    }

    
}
