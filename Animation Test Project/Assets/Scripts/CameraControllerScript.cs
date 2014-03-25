using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = character.transform.position.x;
		float y = character.transform.position.y;
		transform.position = new Vector3(x,y,-10);
	}
}
