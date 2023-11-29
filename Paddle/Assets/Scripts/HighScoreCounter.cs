using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI highScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScoreLabel.text = "High Score: " + GameManager.instance.highScore.ToString();
    }
}
