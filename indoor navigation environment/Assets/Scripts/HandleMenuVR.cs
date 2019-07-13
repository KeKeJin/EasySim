using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandleMenuVR : MonoBehaviour
{
    public GameObject ExitGameObject;
    public GameObject VRCamera;
    public GameObject Traffics;

    public void Show(Hand hand)
    {
        ExitGameObject.SetActive(true);
    }
    public void Exit( Hand hand)
    {
        ExitGameObject.SetActive(false);
    }
    public void SetTraffics(Hand hand)
    {
        Traffics.SetActive(true);
    }

    // todo: fix these

    private void Reload()
    {
        Destroy(VRCamera.GetComponent<GroundView>());
        Destroy(VRCamera.GetComponent<DepthSynthesis>());
        Destroy(VRCamera.GetComponent<ImageSynthesis>());

    }
    public void Depth(Hand hand)
    {
        // Reload();
        //VRCamera.AddComponent<DepthSynthesis>();
        VRCamera.GetComponent<DepthSynthesis>().enabled = true;
        VRCamera.GetComponent<GroundView>().enabled = false;
        VRCamera.GetComponent<ImageSynthesis>().enabled = false;

    }
    public void Segmantics(Hand hand)
    {
        // Reload();
        // VRCamera.AddComponent<ImageSynthesis>();
        VRCamera.GetComponent<DepthSynthesis>().enabled = false;
        VRCamera.GetComponent<GroundView>().enabled = false;
        VRCamera.GetComponent<ImageSynthesis>().enabled = true;
    }

    public void GroundTruth(Hand hand)
    {
        //  Reload();
        //  VRCamera.AddComponent<GroundView>();




        Debug.Log("ground view");
    }
}
