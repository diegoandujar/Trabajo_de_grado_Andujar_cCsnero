using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoTrigger : MonoBehaviour
{

    private Rigidbody2D rgb;
    private BoxCollider2D box;

    private void Start()
    {
        rgb = GetComponentInParent<Rigidbody2D>();

    }

}
