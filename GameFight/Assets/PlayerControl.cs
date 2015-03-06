using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float speedFactorFade = 2.0f;

	private Rigidbody myRigidbody;
	private Animator anim;
	private SphereCollider myCollider;
	private Transform mytransform;

	private float speedFactor;
	private float moveSpeed;
	private float moveSpeedOrigin;
	private Vector3 moveDir;


	private int skillid;
	private int chamovestat;

	//攻击先关
	private Vector3 attackVector;
	private float magnitude_attackdir;
	private float attackDot;

	void Awake(){
		mytransform = transform.root;
		myRigidbody = transform.root.GetComponent<Rigidbody> ();
		anim = transform.root.GetComponent<Animator> ();
		myCollider = GetComponent<SphereCollider> ();
		moveSpeed = moveSpeedOrigin = 1.6f; 

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit;
			if(Physics.Raycast(ray,out rayHit,100f)){
				if(rayHit.collider.gameObject.tag == "Floor"){
					Vector3 newPos = rayHit.point;
					Vector3 newDir = new Vector3(newPos.x,mytransform.position.y,newPos.z)-mytransform.position;
					newDir = newDir.normalized;
					moveDir = newDir;
					mytransform.rotation = Quaternion.LookRotation(newDir);
					moveSpeed = moveSpeedOrigin;
					speedFactor = 6.5f;
					chamovestat = 1;
				}
			}
		}

		if(chamovestat==1){
			if(moveDir == Vector3.zero){
				anim.SetFloat("speed",0f);
				anim.SetInteger("skillid",0);
				myCollider.enabled = true;
			}else{
				if(speedFactor>0){
					speedFactor-=speedFactorFade*Time.deltaTime;
				}
				anim.SetInteger("skillid",1);
				anim.SetFloat("speed",speedFactor);

				if(speedFactor<3.5f){
					if(speedFactor>0.2f){
						moveSpeed = speedFactor/2f;
					}else{
						moveDir = Vector3.zero;
					}
				}  
				mytransform.position+=mytransform.forward*Time.deltaTime*moveSpeed;
			}
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.layer == Layers.Enemy) {
			myCollider.enabled = false;
			AttackOn(other.gameObject.transform.position);
		}
	}

	public void AttackOn(Vector3 monpos)
	{
		Debug.Log ("##############");
		this.attackVector = monpos - mytransform.position;
		//Debug.Log ("before attackVector="+attackVector);
		this.attackVector[1] = 0f;
		//Debug.Log ("after attackVector="+attackVector);
		this.magnitude_attackdir = this.attackVector.magnitude;
		this.attackVector /= this.magnitude_attackdir;
		//Debug.Log ("this.attackVector="+this.attackVector);
		this.attackDot = Vector3.Dot(this.attackVector, moveDir);
		//Debug.Log ("this.attackDot="+this.attackDot);
		if (this.magnitude_attackdir > 0.2f)
		{
			if (this.attackDot < 0.5f)
			{
				//this.chamovestat = 17;
				myCollider.enabled = true;
				return;
			}
		}
		else
		{
			if (this.attackDot < -0.2f)
			{
				//this.chamovestat = 17;
				myCollider.enabled = true;
				return;
			}
		}


		Debug.Log ("@@@@@@@@@@@@@@@@@@@");
		this.chamovestat = 19;
		//this.pressdelay = 0f;
		anim.SetInteger ("skillid",2);
//		this.ef_swingex1.localScale = Vector3.one * 2.4f;
//		this.ef_swingex1.localRotation = Quaternion.Euler(0f, 0f, 180f);
//		this.ef_swingex1.position = this.mytransform.position + Vector3.up * 0.055f;
//		this.script_swingex1.SwingOn(0.48f, 2, 2, 20, 1, 120);
		Debug.Log ("================================"+attackVector);
		this.myRigidbody.AddForce(this.attackVector * 110f);
		//this.curruntattack = this.attackkind_factor;
		//this.script_cam.ZoomIn(3, 22, 0.2f);


//		this.RndAtk(true);
//		this.speedfactor = 5.2f;
//		if (this.chamovestat == 3)
//		{
//			this.curruntattack = -1;
//			this.Invincibility(1f);
//		}
//		else
//		{
//			if (this.combotime > 0f)
//			{
//				this.curruntattack = (this.curruntattack + 1 - this.attackkind_factor) % 5 + this.attackkind_factor;
//			}
//			else
//			{
//				if (this.combotime <= 0f)
//				{
//					this.curruntattack = this.attackkind_factor;
//				}
//			}
//		}
//		int num = Random.Range(0, 5);
//		if (num < 2)
//		{
//			if (!this.general)
//			{
//				this.myaudio.clip = this.yell[num];
//			}
//			else
//			{
//				this.myaudio.clip = this.g_yell[num];
//			}
//			this.myaudio.Play();
//		}
//		this.mytransform.rotation = Quaternion.LookRotation(this.attackVector);
//		this.FogOn(0);
//		int num2 = this.curruntattack;
//		switch (num2 + 1)
//		{
//		case 0:
//			this.chamovestat = 19;
//			this.pressdelay = 0f;
//			this.myanimation.Play("dash_attack");
//			this.temp_attack = this.myanimation.PlayQueued("1t", QueueMode.CompleteOthers);
//			this.temp_attack.speed = 0.24f;
//			this.temp_attack.layer = 1;
//			this.ef_swingex1.localScale = Vector3.one * 2.4f;
//			this.ef_swingex1.localRotation = Quaternion.Euler(0f, 0f, 180f);
//			this.ef_swingex1.position = this.mytransform.position + Vector3.up * 0.055f;
//			this.script_swingex1.SwingOn(0.48f, 2, 2, 20, 1, 120);
//			this.myrigidbody.AddForce(this.attackVector * 50f);
//			this.curruntattack = this.attackkind_factor;
//			this.script_cam.ZoomIn(3, 22, 0.2f);
//			break;
//		case 1:
//		}
	}

}
