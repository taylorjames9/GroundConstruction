using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam_Feet : MonoBehaviour {
	public Camera myCam;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(myCam.transform.position.x, 0, myCam.transform.position.z+0.5f);
	}
}
