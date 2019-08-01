using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class switchPlayer : MonoBehaviour
{
    public GameObject[] players;
    private int num;
    private int currentPlayer = 0;
    private bool vrControl = false;
    // Start is called before the first frame update
    void Start()
    {
        num = players.Length;
        ActivatePlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(currentPlayer < num - 1)
            {
                currentPlayer += 1;
            }
            else
            {
                currentPlayer = 0;
            }
            Debug.Log("space key pressed");
            ActivatePlayer(currentPlayer);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            players[currentPlayer].GetComponent<NavMeshAgent>().isStopped = !vrControl;
            players[currentPlayer].GetComponent<VRController>().enabled = !vrControl;
            vrControl = !vrControl;
        }
    }
    void ActivatePlayer(int index)
    {
        for (int i = 0; i < num; ++i)
        {
            if (i != index)
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
