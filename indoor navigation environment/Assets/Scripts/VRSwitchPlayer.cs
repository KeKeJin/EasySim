using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Valve.VR;

public class VRSwitchPlayer : MonoBehaviour
{
    public int currentPlayer;
    public GameObject playerController;
    public SteamVR_Action_Boolean m_Grip = null;
    public SteamVR_Action_Boolean m_Menu = null;
    private VRController m_VRController = null;
    private bool controllerEnabled = false;
    public GameObject menu;
    private NavMeshAgent m_navMesh;
    private bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        m_VRController = GetComponent<VRController>();
        m_VRController.enabled = false;
        m_navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
        OpenMenu();
    }
    void SwitchPlayer()
    {
        if (m_Grip.GetStateUp(SteamVR_Input_Sources.Any))
        {
            Debug.Log("switching to player" + currentPlayer + 1);
            playerController.GetComponent<PlayerController>().SwitchPlayer(currentPlayer + 1);
        }
    }
    public void EnableController()
    {
            Debug.Log("enabling controller");
        controllerEnabled = !controllerEnabled;
        m_VRController.enabled = controllerEnabled;
            m_navMesh.isStopped = controllerEnabled;
    }
    void OpenMenu()
    {
        if (m_Menu.GetStateUp(SteamVR_Input_Sources.Any))
        {
            menuOpen = !menuOpen;
            menu.SetActive(menuOpen);
            m_navMesh.isStopped = menuOpen || controllerEnabled;
        }
    }
}
