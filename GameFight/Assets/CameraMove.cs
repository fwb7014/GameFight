using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float moveSpeed = 5f;
	public Vector3 relVec;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
		relVec = transform.position -target.position ;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = Vector3.Lerp (transform.position,relVec+target.position,Time.deltaTime*moveSpeed);
		transform.position = newPos;
	}
}
