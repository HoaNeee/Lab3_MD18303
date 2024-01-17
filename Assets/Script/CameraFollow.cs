using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    public float minX, maxX;
    void Start()
    {
        player = GameObject.Find("Character").transform;
    }

    void Update()
    {
        if(player != null)
        {
            Vector3 vector3 = transform.position;
            vector3.x = player.position.x;

            if(vector3.x < minX)
            {
                vector3.x = minX;
            } if(vector3.x > maxX)
            {
                vector3.x = maxX;
            }
            transform.position = vector3;
        }
    }
}

