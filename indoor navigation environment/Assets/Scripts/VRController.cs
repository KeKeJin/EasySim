using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System.IO;
using System;

public class VRController : MonoBehaviour
{
    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;
    //public GameEnding gameEnding;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    private CharacterController m_CharacterController = null;
    private float m_Speed = 0f;
    public Transform m_CameraRig = null;
    public Transform m_Head = null;
    private string path = "./text.txt";


    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
       // m_CameraRig = SteamVR_Render.Top().origin;
       // m_Head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    private void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateRotation();

    }

    private void HandleHead()
    {
        Vector3 oldPosition = m_CameraRig.position;
        Quaternion oldRotation = m_CameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_Head.rotation.eulerAngles.y, 0.0f);

        m_CameraRig.position = oldPosition;
        m_CameraRig.rotation = oldRotation;
    }

    private void HandleHeight()
    {
        float headHeight = Mathf.Clamp(m_Head.localPosition.y, 1, 2);
        m_CharacterController.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        newCenter.x = m_Head.localPosition.x;
        newCenter.z = m_Head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;
        m_CharacterController.center = newCenter;
    }

    private void CalculateRotation()
    {
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_Speed = 0;
        }
        if (m_MovePress.state)
        {
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }
        m_CharacterController.Move(movement);
    }
    /*void Log()
    {
        StreamWriter writer = new StreamWriter(path, true);
       writer.WriteLine(DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
        writer.WriteLine("  :");
        Vector3 playerPos = m_Head.localPosition;
        Vector3 playerRot = m_Head.forward;
        writer.WriteLine( $"headset position is: {playerPos}");
       writer.WriteLine( $"headset rotation is: {playerRot}");
        Ray interactionRay = new Ray(playerPos, playerRot);
        RaycastHit rayHit;
        bool hit = Physics.Raycast(interactionRay, out rayHit);
        if (hit)
        {
            GameObject hitObj = rayHit.transform.gameObject;
            Transform hitPos = rayHit.transform;
            writer.WriteLine($"detecting an object {hitObj.name} in front");
            writer.WriteLine($"distance is {Vector3.Distance(hitPos.position,playerPos)}");

        }
        writer.WriteLine("-------------------------------");
        writer.Close();
       writer.WriteLine("Test");
        writer.Close();
    }*/

}