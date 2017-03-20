using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotScript : MonoBehaviour {


	private Transform tf;
	private Renderer rend;
	private Material mat;
	private Color clr;

	void OnEnable(){
		tf = transform.GetChild(0);
		rend = tf.GetComponent<MeshRenderer>();
		mat = rend.materials[0];
		clr = mat.color;
		//newCLR = new Color(clr.r, clr.g, clr.b, 0);
		//tf.GetComponent<MeshRenderer>().materials[0].color = clr;
		Debug.Log("my color alpha set to "+tf.GetComponent<MeshRenderer>().materials[0].color );
		SetAlpha();
	}

	void OnTriggerEnter(Collider other_col){
		Debug.Log("Hit a trigger");
		if(other_col.tag.Equals("feet")){
			StartCoroutine(Rise());
		}
	}

	void OnTriggerExit(Collider other_col){
		Debug.Log("Leaving a trigger");
		if(other_col.tag.Equals("feet")){
			StartCoroutine(Fall());
		}
	}

	IEnumerator Rise(){
		while(tf.position.y < 0){
			MoveUp();
			SetAlpha();
			yield return 0;
		}
		yield return null;
	}

	IEnumerator Fall(){
		while(tf.position.y > -1.0f){
			MoveDown();
			SetAlpha();
			yield return 0;
		}
		yield return null;
	}

	void MoveUp(){
		tf.position = new Vector3(tf.position.x, tf.position.y+0.1f, tf.position.z);
	}

	void MoveDown(){
		tf.position = new Vector3(tf.position.x, tf.position.y-0.1f, tf.position.z);
	}

	void SetAlpha(){
		float alpha = Mathf.Abs(1+tf.position.y);
		//Debug.Log("New alpha set to: "+alpha);
		clr = new Color(clr.r, clr.g, clr.b, alpha);
		tf.GetComponent<Renderer>().material.color = clr;
	}
}
