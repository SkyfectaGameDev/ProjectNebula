using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;
    public Transform localScale;
    private GameObject shipBody;

    public int startBuffer;
    public int state;
    public int speed;

    public Transform gunLeft;
    public Transform gunRight;
    public int firerate;
    private int firerateBuffer;
    private int firepower;
    public GameObject bulletStandardPrefab;

    void Start()
    {
        shipBody = GameObject.Find("Ship Body");
        body = GetComponent<Rigidbody>();
        anim = shipBody.GetComponent<Animator>();
        startBuffer = 220;
    }

    void Update()
    {
        if (startBuffer == 1)
            state = 1;

        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        anim.SetFloat("X Movement", body.velocity.x);

        if (state == 1)
        {
            body.velocity = new Vector3(HorizontalInput * speed, 0, VerticalInput * speed);

            if (Input.GetKey(KeyCode.Space) && firerateBuffer == firerate)
            {
                Instantiate(bulletStandardPrefab, gunLeft.position, localScale.rotation);
                Instantiate(bulletStandardPrefab, gunRight.position, localScale.rotation);
                firerateBuffer = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (startBuffer > 0)
            startBuffer--;

        if (firerateBuffer < firerate)
            firerateBuffer++;
    }
}
