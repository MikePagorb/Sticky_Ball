using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookAtBall : MonoBehaviour
{
    public GameObject ball;
    private Vector3 lookAtOffset;
    // Start is called before the first frame update
    void Start()
    {
        lookAtOffset = new Vector3(0, 1.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        //look at ball
        transform.LookAt(ball.transform.position + lookAtOffset);
    }
}
