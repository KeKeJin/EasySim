using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour {

    // Use this for initialization
    Toggle myToggle;
    public GameObject myRendering;
	void Start () {
        myToggle = GetComponent<Toggle>();
        myToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(myToggle);
        });
        myRendering.SetActive(false);
    }
	

    void ToggleValueChanged(Toggle change)
    {
        myRendering.SetActive(myToggle.isOn);
    }
}
