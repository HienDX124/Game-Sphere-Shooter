using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Transform player;
    private Transform camTransform;
    public float height = 12.5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        camTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        this.transform.position = new Vector3(player.position.x, height, player.position.z - 6);
    }
}
