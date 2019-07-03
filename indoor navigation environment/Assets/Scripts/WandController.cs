using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WandController: MonoBehaviour
{
    public float m_Sensitivity = 0.1f;
    public float m_MaxSpeed = 1.0f;
    public float turnSpeed = 20f;
    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;
    private CharacterController m_CharacterController = null;
    private float m_Speed_x = 0f;
    private float m_Speed_y = 0f;
    private Transform m_CameraRig = null;
    private Transform m_Head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_CameraRig = SteamVR_Render.Top().origin;
        m_Head = SteamVR_Render.Top().head;
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
        Vector3 movement = Vector3.zero;
        Vector3 orientationEuler = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        orientationEuler = orientationEuler.normalized;
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            m_Speed_x = 0;
            m_Speed_y = 0;
        }
        if (m_MovePress.state)
        {
            m_Speed_x = m_MoveValue.axis.x*m_Sensitivity;
            m_Speed_y = m_MoveValue.axis.y* m_Sensitivity;
            movement.Set(m_Speed_x, 0, m_Speed_y);
            Vector3 desiredForwad = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
            orientation = Quaternion.LookRotation(desiredForwad);
            float m_Speed = Mathf.Sqrt(m_Speed_y * m_Speed_y + m_Speed_x * m_Speed_x);
            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;

        }
        m_CharacterController.Move(movement);
    }
}