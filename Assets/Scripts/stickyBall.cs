using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyBall : MonoBehaviour
{
    public float facingAngle = 0;
    private float x = 0;
    private float z = 0;
    private Vector2 unitV2;

    public GameObject cameraReference;
    private float distanceToCamera = 5;

    private float size = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //User Controls
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -100;
        z = Input.GetAxis("Vertical") * Time.deltaTime * 500;

        //Facing Angle
        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));

        // Apply Force behind the BAll
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 1.5f);

        //Set camera position behind the ball based on rotation
        cameraReference.transform.position =
            new Vector3(-unitV2.x * distanceToCamera, distanceToCamera, -unitV2.y * distanceToCamera) +
            this.transform.position;
    }

    // Pick ip Sticky Objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Sticky"))
        {

            // Grow the Sticky Ball
            transform.localScale += new Vector3(0.01f,0.01f,0.01f);
            size += 0.01f;
            distanceToCamera += 0.08f;
            other.enabled = false;

            //Becomes Child so it stays with the Sticky Ball
            other.transform.SetParent(this.transform);

        }
    }
}
