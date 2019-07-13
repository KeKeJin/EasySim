using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button menu;
    public Button exit;
    public Button traffic;
    public Button ground;
    public Button depth;
    public Button segmentation;
    public GameObject menuGB;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClicked(Button button)
    {
        if (button == exit)
        {
            menuGB.SetActive(false);
        }
        else if (button == menu)
        {
            menuGB.SetActive(true);
        }
    }
}
