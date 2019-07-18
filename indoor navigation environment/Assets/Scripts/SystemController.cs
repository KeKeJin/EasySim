using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle[] allToggles;
    public GameObject car;
    private Vector3 oldPosition;
    public GameObject Traffics;
    public GameObject SideCameras;
    public GameObject GroundTruth;
    public GameObject Depth;
    public GameObject Semantics;
    public void ResetClicked()
    {
        for (int i = 0; i < allToggles.Length; ++i)
        {
            allToggles[i].isOn = false;
        }
        car.transform.position = oldPosition;
        car.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void Start()
    {
        oldPosition = car.transform.position;
        Traffics.SetActive(false);
        SideCameras.SetActive(false);
        GroundTruth.SetActive(false);
        Depth.SetActive(false);
        Semantics.SetActive(false);
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void EnableTraffics()
    {
        Traffics.SetActive(!Traffics.activeSelf);
    }
    public void EnableSideCameras()
    {
        SideCameras.SetActive(!SideCameras.activeSelf);
    }
    public void EnableGroundTruth()
    {
        GroundTruth.SetActive(!GroundTruth.activeSelf);
    }
    public void EnableDepth()
    {
        Depth.SetActive(!Depth.activeSelf);
    }
    public void EnableSemantics()
    {
        Semantics.SetActive(!Semantics.activeSelf);
    }
}
