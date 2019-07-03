using UnityEngine;

[ExecuteInEditMode]
public class PlayerMovement : MonoBehaviour
{
    public float sensitivity;
    Rigidbody m_Rigidbody;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + transform.forward*sensitivity);
    }
}