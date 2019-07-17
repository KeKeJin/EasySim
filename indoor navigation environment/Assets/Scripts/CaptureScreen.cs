using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreen : MonoBehaviour
{
    public GroundView synth;
    int frameCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frameCount % 5 == 0)
        {
            synth.Save("image"+frameCount.ToString().PadLeft(5,'0'), 512, 512, "captures");
        }
        ++frameCount;
    }
}
