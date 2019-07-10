using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleReset : MonoBehaviour {

    // Use this for initialization
    Toggle myToggle;
    public Toggle[] allToggles;
    public GameObject car;
    private Vector3 oldPosition;
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        myToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(myToggle);
        });
        oldPosition = car.transform.position;

    }


    void ToggleValueChanged(Toggle change)
    {
        for (int i = 0; i < allToggles.Length; ++i)
        {
            allToggles[i].isOn = false;
        }
        myToggle.isOn = false;
        car.transform.position = oldPosition;
        car.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
