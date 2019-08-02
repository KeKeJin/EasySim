using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchingCanvasCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Canvas myCanvas;
    public Camera[] myCameras;
    void Start()
    {
        myCanvas = GetComponent<Canvas>();
    }

    public void SwitchCanvasCameras(int index)
    {
        Debug.Log("Switching cameras");
        myCanvas.worldCamera = myCameras[index];
    }
}
