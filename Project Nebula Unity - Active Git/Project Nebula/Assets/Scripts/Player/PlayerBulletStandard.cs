using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletStandard : MonoBehaviour
{
    private Rigidbody body;
    private int power;
    public float speed;
    public int mode;
    public Vector3 vel;

    void Start()
    {
        Destroy(gameObject, 1.5f);
        body = GetComponent<Rigidbody>();
        vel = new Vector3 (0, 0, 60);
    }

    void FixedUpdate()
    {
        body.velocity = vel * speed;

    }

    void Update()
    {
        
    }
}
