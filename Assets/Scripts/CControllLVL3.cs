using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CControllLVL3 : MonoBehaviour
{
    public Transform player;
    private void Update()
    {
        if (player.position.x != transform.position.x && player.position.x > 0
        && player.position.x < 38f)
        {
            transform.position = Vector3.Lerp(transform.position,
            new Vector3(player.position.x, transform.position.y, 
            transform.position.z), 0.1f);
        }
    }
}
