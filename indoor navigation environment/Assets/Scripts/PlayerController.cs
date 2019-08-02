using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] players;
    private int num;
    // Start is called before the first frame update
    void Start()
    {
        num = players.Length;
        SwitchPlayer(0);
    }

    // Update is called once per frame
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
    }
}
