using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public GameObject camera;
    private Vector3 originalPos;
    public float shakeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = camera.transform.position;
        //invoke the shake function
        Shake(shakeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake(float shakeTimeVar)
    {
        InvokeRepeating("StartShake", 0, 0.01f);
        Invoke("StopShake", shakeTimeVar);
    }

    void StartShake()
    {
        if (shakeTime > 0)
        {
            float quakeAmount = Random.value * 0.1f - 0.05f;
            Vector3 pp = camera.transform.position;
            pp.y += quakeAmount;
            camera.transform.position = pp;
        }
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        camera.transform.position = originalPos;
    }
}
