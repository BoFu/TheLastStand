﻿using UnityEngine;
using System.Collections;

public class PlayerCatch : MonoBehaviour {

	//get script from parent class (Player.cs)
	Player playerScript;
	Controls controlScript;
	GenericEnemy enemyScript;
	public GameObject controls;
	// Use this for initialization
	void Start () {
		renderer.enabled = false;//makes catch radius invisible
		playerScript = transform.parent.GetComponent<Player>();
		controlScript = controls.transform.GetComponent<Controls>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnTriggerStay2D(Collider2D col){
		if(playerScript.health > 0)//catches on "Fire2" press, which is right mouse button, spacebar, or gamepad button 1 (B on xbox 360 remote)
		{
			if (col.gameObject.tag.Equals("EnemyArrow")&&(controlScript.grab))//(Input.GetMouseButtonDown(1)||Input.GetKeyDown(KeyCode.LeftShift)))
			{
				if(playerScript.ammo < playerScript.ammoLimit )
				{
					ObjectPool.instance.PoolObject(col.gameObject);
					playerScript.ammo++;
					Debug.Log("Arrow Caught. New Ammo is :"+ playerScript.ammo);
				}
				else
				{
					Debug.Log("Ammo is full");
				}
			}
		}
	}
}
