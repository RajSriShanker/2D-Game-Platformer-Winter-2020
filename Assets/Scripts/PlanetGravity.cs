using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 lookDirection;

    float lookAngle;

    [Header("Gravity")]

    // Distance where gravity works
    [Range(0.0f, 1000.0f)]
    public float maxGravDist = 150.0f;

    // Gravity force
    [Range(0.0f, 1000.0f)]
    public float maxGravity = 150.0f;

    // Your planet
    public GameObject planet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Distance to the planet
        float dist = Vector3.Distance(planet.transform.position, transform.position);

        // Gravity
        Vector3 v = planet.transform.position - transform.position;
        rb.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);

        // Rotating to the planet
        // The rotation forces object to face z=-90
        lookDirection = planet.transform.position - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle + 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlatformParent")
        { 
            planet = collision.collider.gameObject;
        }
    }
}
