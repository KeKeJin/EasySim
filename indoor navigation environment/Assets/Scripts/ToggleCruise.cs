using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleCruise : MonoBehaviour {

    // Use this for initialization
    Toggle myToggle;
    public GameObject disable;
    public GameObject enable;
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        myToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(myToggle);
        });
        enable.SetActive(false);
    }


    void ToggleValueChanged(Toggle change)
    {
        enable.SetActive(myToggle.isOn);
        disable.SetActive(!myToggle.isOn);
    }
}
