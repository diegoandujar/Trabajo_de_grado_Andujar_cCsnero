using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationOnZ : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeReference] private float speed = 2f;    
    
    private void Update()     
    {         
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);     
    }
}
