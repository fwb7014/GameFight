using UnityEngine;
using System.Collections;

public class Enmey1Ai : MonoBehaviour {
	private Transform player;
	private Transform mytransform;
	private Monster monster;


	private Transform hpbar;
	private float hpbar_height;
	private Hp_bar script_hpbar;
	private float maxhp;
	private float hp;

	private float height;
	private float moveSpeed;

	//状态
	private bool life;

	//战斗相关
	private float damagedCount;
	private Vector3 attackDir;
	private float magnitude_behitdir;
	private float attackforce;
	private float damage;


	void Awake(){
		life = true;
		maxhp = 100f;
		hp = 70f;
		height = 1.5f;
		mytransform = transform;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		monster = GameObject.FindWithTag("efs_mon").GetComponent<Monster>();
	}

	void Start () {

		hpbar = monster.CreatHpbar (new Vector2 (1f,0.2f), false, true);
		hpbar.position = this.mytransform.position;

		script_hpbar = this.hpbar.GetComponent<Hp_bar>();
		script_hpbar.Damaged((int)this.maxhp, (int)this.hp, this.mytransform,height, 0);
	}

//	void Damaged(Vector3 damageDir){
//		damagedCount = damageDir [1];
//		damageDir [1] = 0f;
//
//	}

	void OnTriggerEnter(Collider other){
		int layer = other.gameObject.layer;
		if (!life) {
			return ;		
		}

		attackDir = mytransform.position - other.transform.position;
		attackDir.y = 0f;
		magnitude_behitdir = attackDir.magnitude;
		if (magnitude_behitdir != 0f) {
			if(this.magnitude_behitdir<0.08f){
				attackDir = attackDir/magnitude_behitdir*1.6f;
			}else{
				this.attackDir/=magnitude_behitdir;
			}		
		}
		Debug.Log ("Layers.PlayerWeapon="+layer);
		if (layer == Layers.PlayerWeapon) {
			attackforce = 40f;
			damage = 10f;
			moveSpeed = 0f;
			rigidbody.AddForce(attackDir*attackforce);
			script_hpbar.Damaged((int)this.maxhp, (int)this.hp, this.mytransform,height, 0);
		}
	}


	void Update () {
		Vector3 newDir = player.position - transform.position;
		transform.rotation = Quaternion.LookRotation (newDir);
	}
}
