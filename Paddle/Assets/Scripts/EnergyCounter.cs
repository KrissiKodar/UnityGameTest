using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class EnergyCounter : MonoBehaviour
{
    public TextMeshProUGUI energyLabel;
    private float roundedEnergy;

    private Gradient energyGradient;

    private void Start()
    {
        // Initialize the gradient
        energyGradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].color = Color.red;
        colorKeys[0].time = 0f; 
        colorKeys[1].color = Color.green;
        colorKeys[1].time = 1f; 
        energyGradient.colorKeys = colorKeys;
    }

    private void Update()
    {
        float energyPercentage = GameManager.instance.currentEnergy / GameManager.instance.maxEnergy; // Assuming maxEnergy is defined
        roundedEnergy = Mathf.Round(GameManager.instance.currentEnergy);

        // Update the color based on energy level
        Color energyColor = energyGradient.Evaluate(energyPercentage);

        energyLabel.text = "NRG: " + roundedEnergy.ToString();
        energyLabel.color = energyColor; // Apply the color to the label
    }
}