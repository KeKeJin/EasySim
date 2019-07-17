using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPredestrains : MonoBehaviour {

    private Vector3 spawnLocation;
    public GameObject[] m_Predestrains;
    public float density;
    public float traffic_Max = 10;
    private float traffic = 0;
    public GameObject directory;
    // Use this for initialization
    void Start()
    {
        spawnLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % density == 0 && traffic < traffic_Max)
        {
            CreatePredestrains();
            traffic += 1;
        } 
    }

    void CreatePredestrains()
    {
        // spawnLocation += new Vector3(Random.value *10, 0, Random.value*5);
        GameObject target = m_Predestrains[Random.Range(0, m_Predestrains.Length)];
        Vector3 targetLocation = target.transform.position;
        Quaternion targetRotation = target.transform.rotation;
        target.SetActive(true);
        GameObject spawn= Instantiate(target, targetLocation, targetRotation);
        spawn.transform.parent = directory.transform;
        spawn.SetActive(true);
        target.SetActive(false);
    }
}
