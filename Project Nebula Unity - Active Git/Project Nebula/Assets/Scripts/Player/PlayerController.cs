using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;
    public Transform localScale;
    private GameObject shipBody;

    private int startBuffer;
    public int state;
    public int speed;

    public Transform gunLeft;
    public Transform gunRight;
    public int firerate;
    private int firerateBuffer;
    private int firepower;
    public GameObject bulletStandardPrefab;

    public GameObject afterImagePrefab;
    public GameObject shield;
    public float energy;
    private int energyCooldown;

    void Start()
    {
        shipBody = GameObject.Find("Ship Visual Controller");
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
            // ----- Moving -----
            body.velocity = new Vector3(HorizontalInput * speed, 0, VerticalInput * speed);

            // ----- Firing -----
            if (Input.GetKey(KeyCode.D) && firerateBuffer == firerate)
            {
                Instantiate(bulletStandardPrefab, gunLeft.position, localScale.rotation);
                Instantiate(bulletStandardPrefab, gunRight.position, localScale.rotation);
                firerateBuffer = 0;
            }

            // ----- Dashing -----
            if (Input.GetKeyDown(KeyCode.S) && energyCooldown == 0 && energy >= 34 && (HorizontalInput != 0 || VerticalInput != 0))
            {
                speed = 100;
                energyCooldown = 12;
                energy = energy - 33;
            }

            // ----- Energy Shield -----
            if (Input.GetKeyDown(KeyCode.A) && energyCooldown == 0 && energy >= 99)
            {
                shield.SetActive(true);
                energyCooldown = 80;
                energy = energy - 99;
            }

            // ----- Deactivate Abilities -----
            if (energyCooldown == 0)
            {
                shield.SetActive(false);
                speed = 20;
            }
        }
    }

    void FixedUpdate()
    {
        if (startBuffer > 0)
            startBuffer--;

        if (state == 1)
        {

            if (firerateBuffer < firerate)
                firerateBuffer++;

            if (energyCooldown > 0)
                energyCooldown--;
            if (energyCooldown == 10 || energyCooldown == 8 || energyCooldown == 6 || energyCooldown == 4 || energyCooldown == 2)
            {
                if (shield.activeSelf == false)
                    Instantiate(afterImagePrefab, localScale.position, localScale.rotation);
            }
                
            if (energy < 100)
                energy += 0.4f;
            if (energy > 100)
                energy = 100;
        }
    }
}
