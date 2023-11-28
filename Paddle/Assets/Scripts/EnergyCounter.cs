using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI energyLabel;
    float roundedEnergy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundedEnergy = GameManager.instance.currentEnergy;
        //roundedTime =  Mathf.Round(roundedTime * 10.0f) * 0.1f;
        roundedEnergy =  Mathf.Round(roundedEnergy);
        energyLabel.text =  roundedEnergy.ToString();
    }
}
