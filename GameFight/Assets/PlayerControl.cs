using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	private Rigidbody myRigidbody;
	private Animator anim;
	private Transform mytransform;

	private PlayerStatus status;

	//移动相关
	private float speedFadeFactor = 0.62f;
	private float moveSpeed;   //移动速度
	private Vector3 moveDir;   //移动方向
	private Vector3 movePos;   //移动的目的地 

	//状态
	private int animState;

	//攻击相关
	private GameObject target;


	//攻击先关
	private Vector3 attackVector;
	private float magnitude_attackdir;
	private float attackDot;

	void Awake(){
		mytransform = transform;
		myRigidbody = transform.GetComponent<Rigidbody> ();
		anim = transform.GetComponent<Animator> ();

		status = GetComponent<PlayerStatus> ();
		moveSpeed = 0f;

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
				if(rayHit.collider.gameObject.tag == Tags.FLOOR){//碰到地板
					Vector3 newPos = rayHit.point;
					Debug.Log ("碰到地板"+newPos);
					moveSpeed = status.moveSpeed;
					movePos = rayHit.point;
					target = null;
				}
			}
		}
		if (movePos != Vector3.zero) {
			float leftDistance = Vector3.SqrMagnitude(mytransform.position-movePos);
			if(leftDistance<5f){
				if(moveSpeed>0.3f){
					moveSpeed -=Time.deltaTime*speedFadeFactor*status.moveSpeed;
				}
				Debug.Log ("leftDistance="+leftDistance);
				if(leftDistance<0.15f){
					moveSpeed = 0f;
					movePos = Vector3.zero;
				}
			}
		}

		if (target == null && moveSpeed > 0) {
			moveDir =(movePos-mytransform.position).normalized;
			mytransform.rotation = Quaternion.LookRotation(moveDir);
			anim.SetInteger(HashIds.Skillid,1);
		}
		if (target == null && moveSpeed == 0) {
			anim.SetInteger(HashIds.Skillid,0);
		}
		if (target != null && moveSpeed == 0) {
			anim.SetInteger(HashIds.Skillid,2);		
		}

		anim.SetFloat (HashIds.Speed, Mathf.Min(moveSpeed*3f,6f));
		transform.position += moveDir * Time.deltaTime * moveSpeed;

	}



	public void AttackOn(GameObject target)
	{
		Vector3 monpos = target.transform.position;
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
				//myCollider.enabled = true;
				return;
			}
		}
		else
		{
			if (this.attackDot < -0.2f)
			{
				//this.chamovestat = 17;
				//myCollider.enabled = true;
				return;
			}
		}
		this.target = target;
		this.movePos = Vector3.zero;
		this.moveSpeed = 0f;
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
