using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timeLabel;
    float roundedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        roundedTime = GameManager.instance.timeElapsed;
        //roundedTime =  Mathf.Round(roundedTime * 10.0f) * 0.1f;
        roundedTime =  Mathf.Floor(roundedTime);
        timeLabel.text = "Time: " + roundedTime.ToString();
    }
}
