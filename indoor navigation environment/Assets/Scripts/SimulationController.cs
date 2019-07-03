using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour {

    // Use this for initialization
    public GameObject depthcamera;
    public GameObject rightCamera;
    public GameObject leftCamera;
    public GameObject groundTruthCamera;

    public Toggle depthcameraToggle;
    public Toggle sideCameraToggle;
    public Toggle groundTruthCameraToggle;

    // TODO: segamentation, lidar, 
    void Start () {
		// todo: get toggle data
	}
	
	// Update is called once per frame
	void Update () {
		if (depthcameraToggle.isActiveAndEnabled)
        {
            depthcamera.SetActive(true);
        }
        else
        {
            depthcamera.SetActive(false);
        }
        if (sideCameraToggle.isActiveAndEnabled)
        {
            rightCamera.SetActive(true);
            leftCamera.SetActive(true);
        }
        else
        {
            rightCamera.SetActive(false);
            leftCamera.SetActive(false);
        }
        
        if (groundTruthCameraToggle.isActiveAndEnabled)
        {
            groundTruthCamera.SetActive(true);
        }
        else
        {
            groundTruthCamera.SetActive(false);
        }
    }
}
