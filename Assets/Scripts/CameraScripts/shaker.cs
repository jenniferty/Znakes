using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaker : MonoBehaviour
{
    public float shakePower = 0.2f;
    public float shakeDuration = 1;
    public new Transform camera;
    public float slowDown = 1;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = camera.localPosition;
        initialDuration = shakeDuration;
    }

   
    void Update()
    {
        if (shouldShake)
        {
            if (shakeDuration >= 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * shakePower;
                shakeDuration -= Time.deltaTime * slowDown;
            }
            else
            {
                shouldShake = false;
                shakeDuration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }

    
}
