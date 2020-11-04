using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularGravity : MonoBehaviour
{
    public float massOfEarth;
    public Transform centerOfEarth;
    public float gravity;
    
    float massOfPlayer;
    float distance;
    float forceValue;

    Vector3 forceDirection;
    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        massOfPlayer = playerRB.mass;
        distance = Vector3.Distance(centerOfEarth.position, transform.position);
        forceValue = gravity * (massOfEarth * massOfPlayer) / (distance * distance);
    }

    // Update is called once per frame
    void Update()
    {
        forceDirection = (centerOfEarth.position - transform.position).normalized;
        playerRB.AddForce(forceValue * forceDirection);
    }
}
