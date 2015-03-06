using UnityEngine;
using System.Collections;

public class WeaponDamage : MonoBehaviour {

	private float damage;

	private Transform mytransform;

	void Awake(){
		damage = 10f;
		mytransform = transform;
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("玩家武器碰到敌人"+other.gameObject.layer);
//		if (other.gameObject.layer == Layers.Enemy) {
//			var dir = new Vector3(mytransform.position.x,0f,mytransform.position.z);
//			other.gameObject.transform.root.SendMessage("Damaged",dir+(damage*Vector3.up));		
//		}
	}

}
