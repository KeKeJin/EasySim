using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        public float sensitivity;
        Rigidbody m_Rigidbody;
        public Toggle myToggle;
        private bool cruise = false;
        private CarController m_Car;
        private Steering s;

        private void Awake()
        {
            m_Car = GetComponent<CarController>();
            m_Rigidbody = GetComponent<Rigidbody>();
            s = new Steering();
            s.Start();
        }
        void Start()
        {
            myToggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(myToggle);
            });
        }
        private void FixedUpdate()
        {
            // get toggle value
            if (cruise)
            {
                s.UpdateValues();
                m_Car.Move(s.H, s.V, s.V, 0f);

            }


        }
        void ToggleValueChanged(Toggle change)
        {
            if (myToggle.isOn)
            {
                cruise = true;
            }
            else
            {
                cruise = false;
            }
        }
    }
}
