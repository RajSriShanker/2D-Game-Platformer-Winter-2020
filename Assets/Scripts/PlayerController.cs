using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    [Range(0.0f, 1000.0f)]
    public float playerSpeed;

    [Range(0.0f, 1000.0f)]
    public float jumpForce;

    bool isGrounded;

    bool rightHorizontalMovement = false;
    int rightButtonPress = 0;

    bool leftHorizontalMovement = false;
    int leftButtonPress = 0;

    Rigidbody2D playerRB;
    Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startingPosition;
        }

        if (transform.parent != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Movement
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            leftHorizontalMovement = false;
            leftButtonPress = 0;
            rightButtonPress++;
        }
        
        if (Input.GetKeyDown(KeyCode.D) && rightButtonPress == 2)
        {
            rightHorizontalMovement = true;
            rightButtonPress = 0;
        }

        if (isGrounded && rightHorizontalMovement)
        {
            transform.Translate(1 * playerSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rightHorizontalMovement = false;
            rightButtonPress = 0;
            leftButtonPress++;
        }
        
        if (Input.GetKeyDown(KeyCode.A) && leftButtonPress == 2)
        {
            leftHorizontalMovement = true;
            leftButtonPress = 0;
        }

        if (isGrounded && leftHorizontalMovement)
        {
            transform.Translate(-1 * playerSpeed * Time.deltaTime, 0, 0);
        }

        //Debug 
        Debug.Log(rightButtonPress);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformParent")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatformParent")
        {
            this.transform.parent = null;
        }
    }
}
