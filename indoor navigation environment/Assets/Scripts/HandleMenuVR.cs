using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class HandleMenuVR : MonoBehaviour
{
    public GameObject ExitGameObject;
    public GameObject[] VRCameras;
    public GameObject Traffics;
    private bool trafficEnabled;
    public GameObject[] currentPlayers;
    public int index;
    private bool controllerEnabled = false;

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
        Destroy(currentPlayers[index]);

        SceneManager.LoadScene(0);
    }
    public void SetTraffics(Hand hand)
    {
        Debug.Log("traffics");
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
        VRCameras[index].GetComponent<GroundView>().depthRender = true;
        VRCameras[index].GetComponent<GroundView>().groundRender = false;
        VRCameras[index].GetComponent<GroundView>().semanticsRender = false;
    }
    public void Segmantics(Hand hand)
    {
        VRCameras[index].GetComponent<GroundView>().depthRender = false;
        VRCameras[index].GetComponent<GroundView>().groundRender = false;
        VRCameras[index].GetComponent<GroundView>().semanticsRender = true;
    }

    public void GroundTruth(Hand hand)
    {
        VRCameras[index].GetComponent<GroundView>().depthRender = false;
        VRCameras[index].GetComponent<GroundView>().groundRender = true;
        VRCameras[index].GetComponent<GroundView>().semanticsRender = false;


    }
    public void CruiseControl()
    {
        controllerEnabled = !controllerEnabled;
        currentPlayers[index].GetComponent<VRController>().enabled = controllerEnabled;
        currentPlayers[index].GetComponent<NavMeshAgent>().isStopped = controllerEnabled;
        Debug.Log("controller enabled");
    }
}
