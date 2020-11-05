using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float movementSpeed;

    Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Default Gravity
        if (GetComponent<CircularGravity>().enabled == false)
        {
            playerRB.gravityScale = 1;
        }
        else
        {
            playerRB.gravityScale = 0;
        }

        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.right, Color.red);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            GetComponent<CircularGravity>().enabled = true;
            GetComponent<DragNShoot>().enabled = true;
            GetComponent<TrajectoryLine>().enabled = true;
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            GetComponent<CircularGravity>().enabled = false;
            GetComponent<DragNShoot>().enabled = false;
            GetComponent<TrajectoryLine>().enabled = false;
            this.transform.parent = null;
        }
    }
}
