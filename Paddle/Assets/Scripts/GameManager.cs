using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float timeElapsed;

    public float currentEnergy;
    public float maxEnergy;
    public float energyGainRate;
    public float energyDrainRate;
    

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentEnergy += energyGainRate*Time.deltaTime;
        currentEnergy = Mathf.Min(maxEnergy, currentEnergy);
        currentEnergy = Mathf.Max(0,currentEnergy);
        timeElapsed += Time.deltaTime;
    }
}
