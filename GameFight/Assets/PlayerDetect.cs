using UnityEngine;
using System.Collections;
//英雄自动检测目标
public class PlayerDetect : MonoBehaviour {
	public PlayerControl playerControl;
	private SphereCollider myCollider;
	private Animator anim;
	// Use this for initialization
	void Awake(){
		playerControl = transform.root.GetComponent<PlayerControl> ();
		anim = transform.root.GetComponent<Animator> ();
		myCollider = GetComponent<SphereCollider> ();
	}

	void Update(){
		if (anim.GetInteger (HashIds.Skillid) <= 1) {
			myCollider.enabled = true;		
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.layer == Layers.Enemy) {
			myCollider.enabled = false;
			playerControl.AttackOn(other.gameObject);
		}
	}
}
