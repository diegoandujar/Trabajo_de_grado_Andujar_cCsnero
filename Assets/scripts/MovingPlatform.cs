using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int CurrentWayPoint = 0; //0 y 1 porque son dos waypoints por los que pasa la plataforma, en este caso

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(waypoints[CurrentWayPoint].transform.position, transform.position) < .1f)
        {
            CurrentWayPoint++;
            if (CurrentWayPoint >= waypoints.Length)
            {
                CurrentWayPoint = 0;
            }
        }

        // hace que se mueva una distancia X con respecto al frame
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentWayPoint].transform.position, Time.deltaTime * speed);

    }
}
