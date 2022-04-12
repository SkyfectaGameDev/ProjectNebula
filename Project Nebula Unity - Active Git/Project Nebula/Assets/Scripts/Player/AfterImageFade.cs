using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageFade : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.32f);
    }
}
