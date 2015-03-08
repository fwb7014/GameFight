﻿using UnityEngine;
using System.Collections;

public class CommonClass  {


}

public class Tags{
	public  const string FLOOR = "Floor";
	public  const string PLAYER = "Player";
}

public class Layers{
	public const int PlayerWeapon = 8;
	public const int Enemy = 9;
	public const int EnemyWeapon = 10;
}


public class HashIds{
	public static int IdleState = Animator.StringToHash("Base Layer.Idle");
	public static int MoveState = Animator.StringToHash("Base Layer.Move");
	public static int Skillid = Animator.StringToHash("skillid");
	public static int Speed = Animator.StringToHash("speed"); 
}
