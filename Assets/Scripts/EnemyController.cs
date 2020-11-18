using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    public float enemyJump;
    public float maxJumpTime;

    public Transform target;
    private Rigidbody2D enemyRB;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
        
        if (timer > maxJumpTime)
        {
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
