using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float distance = -3f;
    public float height = 1f;
    public GameObject bowlingBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(bowlingBall == null){
            return;
        }
        Vector3 destination = bowlingBall.transform.position;
        destination.x = 0f;
        destination.y += height;
        destination.z += distance;

        transform.position = destination;
    }
}
