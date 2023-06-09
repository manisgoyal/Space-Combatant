using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float maxX = 90, minX = -90;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if ((tempPos.x <= maxX) && (tempPos.x >= minX))
        {
            transform.position = tempPos;
        }
    }
}
