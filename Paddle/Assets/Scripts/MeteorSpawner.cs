using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject Ball;
    

    public Camera cam;
    public static float yLevelBound;
    public static float xLevelBound;

    public float spawn2Prob;
    public float spawn4Prob;
    public float spawn8Prob;

    // Start is called before the first frame update
    void Start()
    {
        yLevelBound = cam.orthographicSize;
        xLevelBound = yLevelBound * cam.aspect;
        StartCoroutine(SpawnMeteorites());
    }

    // Update is called once per frame
    void Update()
    {
        yLevelBound = cam.orthographicSize;
        xLevelBound = yLevelBound * cam.aspect;

    }

    IEnumerator SpawnMeteorites() {
        while (true) {
            float randomNumber = Random.value;

            if (randomNumber < spawn8Prob) {
                for (int i = 0; i < 8; i++) {
                    Instantiate(Ball);
                }
            } else if (randomNumber < spawn8Prob + spawn4Prob) {
                for (int i = 0; i < 4; i++) {
                    Instantiate(Ball);
                }
            } else if (randomNumber < spawn8Prob + spawn4Prob + spawn2Prob) {
                for (int i = 0; i < 2; i++) {
                    Instantiate(Ball);
                }
            } else if (randomNumber < 1.0) {
                Instantiate(Ball);
            }
            yield return new WaitForSeconds(Random.Range(GameManager.instance.lowerWaiting, GameManager.instance.higherWaiting));
        }
    }
}
