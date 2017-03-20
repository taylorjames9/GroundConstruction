using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleSpot_Manager : MonoBehaviour {
	public int numRows;
	public int numColumns;

	public GameObject invisibleSpot_prefab;

	// Use this for initialization
	void Start () {
		for(float i=-numColumns/2;i<=numColumns/2; i+=0.5f){
			for(float j=-numRows/2; j<=numRows/2; j+=0.5f){
				GameObject i_spot =  Instantiate(invisibleSpot_prefab, new Vector3(j, 0, i), Quaternion.identity);
				float rand = Random.Range(0.02f, 0.8f); 
				i_spot.transform.SetParent(transform);
				i_spot.transform.GetChild(0).localScale = new Vector3(1, rand, 1);

			}
		}
	}
}
