using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    private int fpsCap = 60;
    // Start is called before the first frame update
    private void Awake()
    {
        Application.targetFrameRate = fpsCap;
    }
    void Start()
    {
        Application.targetFrameRate = fpsCap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
