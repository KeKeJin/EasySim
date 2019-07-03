using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerView : MonoBehaviour {

    public Transform followed;

	// Use this for initialization

	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = followed.position + new Vector3(-5, 23, 0);

	}
}
