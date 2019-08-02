using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] players;
    private int num;
    private bool intialSetUp;
    public Canvas m_Canvas;
    public Camera[] myCameras;
    public GameObject handleMenu;
    // Start is called before the first frame update
    void Start()
    {
        num = players.Length;

        
    }
    private void Update()
    {
      if (Time.frameCount < 5)
        {
            Debug.Log("turn off everyone");
            SwitchPlayer(0);
        }
    }
    public void SwitchPlayer(int index)
    {
        for (int i = 0; i < num; ++i)
        {
            if (i!=index)
            {
                players[i].SetActive(false);
            }
            else
            {
                players[i].SetActive(true);
            }
        }
        m_Canvas.worldCamera = myCameras[index];
        handleMenu.GetComponent<HandleMenuVR>().index = index;
    }
}
