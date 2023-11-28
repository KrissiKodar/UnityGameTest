using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject Ball;
    public int lower_waiting;
    public int higher_waiting;

    public Camera cam;
    public static float yLevelBound;
    public static float xLevelBound;
    void Awake()
    {
        yLevelBound = cam.orthographicSize;
        xLevelBound = yLevelBound * cam.aspect;
    }
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

            Instantiate(Ball);
            yield return new WaitForSeconds(Random.Range(lower_waiting,higher_waiting));
        }
    }
}
