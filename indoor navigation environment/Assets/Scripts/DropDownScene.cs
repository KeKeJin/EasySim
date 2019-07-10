using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropDownScene : MonoBehaviour {
    List<string> scenes = new List<string>() { "Please select Scene", "Warehouse", "Haunted House", "School Corridor" };
    List<string> modes = new List<string>() { "Please select Mode", "VR mode", "Display mode" };
    public Dropdown sceneDropdown;
    public Dropdown modeDropDown;
    public Button start;
    private int selectScene;
    private int selectMode;
    public void SceneDropdown_IndexChanged(int index)
    {
        selectScene = index;
        ColorBlock cb = sceneDropdown.colors;
        if (index == 0)
        {
            
            cb.normalColor = Color.red;
            sceneDropdown.colors = cb;
        }
        else
        {
            cb.normalColor = Color.white;
            sceneDropdown.colors = cb;
        }
    }
    public void ModeDropdown_IndexChanged(int index)
    {
        selectMode = index;
        ColorBlock cb = sceneDropdown.colors;
        if (index == 0)
        {
            cb.normalColor = Color.red;
            modeDropDown.colors = cb;
        }
        else
        {
            cb.normalColor = Color.white;
            modeDropDown.colors = cb;
        }
    }
    // Use this for initialization
    void Start () {
        PopulateList();
	}
	
	// Update is called once per frame
	void PopulateList () {
        sceneDropdown.AddOptions(scenes);
        modeDropDown.AddOptions(modes);
	}

    public void ButtonClicked()
    {
        ColorBlock cbMode = modeDropDown.colors;
        ColorBlock cbScene = sceneDropdown.colors;
        if (selectMode != 0 && selectScene != 0)
        {
            Debug.Log(selectScene);
            SceneManager.LoadScene(selectScene);
        }
        if (selectMode == 0)
        {
            cbMode.normalColor = Color.red;
            modeDropDown.colors = cbMode;
        }
        if (selectScene == 0)
        {
            cbScene.normalColor = Color.red;
            sceneDropdown.colors = cbScene;
        }
    }
}
