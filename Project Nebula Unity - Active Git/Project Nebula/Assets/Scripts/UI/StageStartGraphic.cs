using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStartGraphic : MonoBehaviour
{
    public int state;

    void Start()
    {
        state = 0;
    }
    
    void Update()
    {
        if (state == 1)
            Destroy(this.gameObject);
    }
}
