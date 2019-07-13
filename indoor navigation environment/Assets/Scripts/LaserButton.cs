using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class LaserButton : MonoBehaviour
{
    // Start is called before the first frame update
    SteamVR_LaserPointer laserPointer;

    void Start()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
