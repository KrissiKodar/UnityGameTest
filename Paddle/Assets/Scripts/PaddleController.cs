using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float rotationSpeed;

    bool wantsToRotateCCW;
    bool wantsToRotateCW;

    bool wantsToRotateCCW_k;
    bool wantsToRotateCW_k;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wantsToRotateCCW = Input.GetMouseButton(0);
        wantsToRotateCW = Input.GetMouseButton(1);
        wantsToRotateCCW_k =  Input.GetKey("a");
        wantsToRotateCW_k = Input.GetKey("d");
        if (wantsToRotateCCW || wantsToRotateCCW_k || wantsToRotateCW || wantsToRotateCW_k)
        {
            GameManager.instance.currentEnergy -= GameManager.instance.energyDrainRate*Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        if (0 < GameManager.instance.currentEnergy)
        {
            if (wantsToRotateCCW || wantsToRotateCCW_k)
            {
                transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
            }
            else if (wantsToRotateCW || wantsToRotateCW_k)
            {
                transform.Rotate(0, 0, -rotationSpeed * Time.fixedDeltaTime);
            }
        }
        
        
    }

}
