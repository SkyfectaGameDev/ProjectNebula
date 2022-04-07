using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletStandard : MonoBehaviour
{
    private Rigidbody body;
    private int lifeTime;
    private int bulletPower;
    public int mode;
    public Vector3 dir;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        dir = new Vector3 (0, 0, 60);
        lifeTime = 75;
    }

    void FixedUpdate()
    {
        body.velocity = dir;
        lifeTime--;
    }

    void Update()
    {
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
