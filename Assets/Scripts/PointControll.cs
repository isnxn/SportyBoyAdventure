using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControll : MonoBehaviour
{
    public GameObject[] points;
    private int currentPointIndex = 0;

    public float speed = 2f;
    
    private void Update()
    {
        if (Vector2.Distance(points[currentPointIndex]
        .transform.position, transform.position) < .1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= points.Length)
            {
                currentPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex]
        .transform.position, Time.deltaTime * speed);
    }
}
