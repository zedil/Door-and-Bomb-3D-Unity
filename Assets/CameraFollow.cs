using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float rotSpeed = 1;
    Vector3 offset;
    public Transform player;
    
    void Start()
    {
        offset = player.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position - offset;
        Quaternion rot = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*rotSpeed, Vector3.up);
        offset = rot* offset;

        //kameranın sürekli playera bakmasını istiyoruz.
        transform.LookAt(player.position);
    }
}
