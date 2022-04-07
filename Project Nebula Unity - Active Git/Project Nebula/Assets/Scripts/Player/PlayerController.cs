using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody body;
    public Transform localScale;
    public Vector3 gunLeft;
    public Vector3 gunRight;
    private Vector3 bulletSpawn;
    public GameObject bulletStandardPrefab;

    public int state;


    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
        gunLeft = new Vector3(-0.85f, -0.16f, 1.28f);
        gunRight = new Vector3(0.85f, -0.16f, 1.28f);
    }

    void Update()
    {
        anim.SetInteger("State", state);

        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(bulletStandardPrefab, gunLeft, localScale.rotation);
                Instantiate(bulletStandardPrefab, gunRight, localScale.rotation);
            }
        }
       
    }
}
