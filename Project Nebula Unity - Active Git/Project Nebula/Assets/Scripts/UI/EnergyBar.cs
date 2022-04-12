using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private GameObject player;
    public float uiEnergy;
    public Image energyBarBack;
    public Image energyBarFront;

    void Start()
    {
        player = GameObject.Find("Player Ship");
    }

    void Update()
    {
        uiEnergy = player.GetComponent<PlayerController>().energy * 0.01f;
        energyBarBack.fillAmount = uiEnergy;

        if (uiEnergy > 0 && uiEnergy < 0.33)
            energyBarFront.fillAmount = 0;
        if (uiEnergy > 0.33 && uiEnergy < 0.66)
            energyBarFront.fillAmount = 0.34f;
        if (uiEnergy > 0.66 && uiEnergy < 1)
            energyBarFront.fillAmount = 0.67f;
        if (uiEnergy >= 0.99)
            energyBarFront.fillAmount = 1;
    }
}
