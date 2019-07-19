using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class HandleMenuVR : MonoBehaviour
{
    public GameObject ExitGameObject;
    public GameObject VRCamera;
    public GameObject Traffics;
    private bool trafficEnabled;
    public GameObject currentPlayer;

    public void Show(Hand hand)
    {
        ExitGameObject.SetActive(true);
    }
    public void Exit( Hand hand)
    {
        ExitGameObject.SetActive(false);
    }
    public void BackToMain(Hand hand)
    {
        Destroy(currentPlayer);

        SceneManager.LoadScene(0);
    }
    public void SetTraffics(Hand hand)
    {
        if (trafficEnabled)
        {
            Traffics.SetActive(false);
            trafficEnabled = false;
        }
        else
        {
            Traffics.SetActive(true);
            trafficEnabled = true;
        }

    }

    public void Depth(Hand hand)
    {
        VRCamera.GetComponent<GroundView>().depthRender = true;
        VRCamera.GetComponent<GroundView>().groundRender = false;
        VRCamera.GetComponent<GroundView>().semanticsRender = false;
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
