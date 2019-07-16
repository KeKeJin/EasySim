using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandleMenuVR : MonoBehaviour
{
    public GameObject ExitGameObject;
    public GameObject VRCamera;
    public GameObject depth;
    public GameObject semantics;
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

    public void Depth(Hand hand)
    {

        VRCamera.GetComponent<GroundView>().depthRender = true;
        VRCamera.GetComponent<GroundView>().groundRender = false;
        VRCamera.GetComponent<GroundView>().semanticsRender = false;
        Debug.Log("depth clicked");
    }
    public void Segmantics(Hand hand)
    {

        VRCamera.GetComponent<GroundView>().depthRender = false;
        VRCamera.GetComponent<GroundView>().groundRender = false;
        VRCamera.GetComponent<GroundView>().semanticsRender = true;
    }

    public void GroundTruth(Hand hand)
    {
        VRCamera.GetComponent<GroundView>().depthRender = false;
        VRCamera.GetComponent<GroundView>().groundRender = true;
        VRCamera.GetComponent<GroundView>().semanticsRender = false;


    }
}
