using UnityEngine;
using System.Collections;

public class Enmey1Ai : MonoBehaviour {
	private Transform player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newDir = player.position - transform.position;
		transform.rotation = Quaternion.LookRotation (newDir);
	}
}
