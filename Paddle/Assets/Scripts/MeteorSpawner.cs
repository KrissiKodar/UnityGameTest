using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject Ball;
    

    public Camera cam;
    public static float yLevelBound;
    public static float xLevelBound;

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

            if (randomNumber < 0.05) {
                // 5% chance to spawn 8 meteorites
                for (int i = 0; i < 8; i++) {
                    Instantiate(Ball);
                }
            } else if (randomNumber < 0.15) {
                // Additional 10% chance (total 15% - previous 5%) to spawn 4 meteorites
                for (int i = 0; i < 4; i++) {
                    Instantiate(Ball);
                }
            } else if (randomNumber < 0.35) {
                // Additional 20% chance (total 35% - previous 15%) to spawn 2 meteorites
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
