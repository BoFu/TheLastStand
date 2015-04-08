﻿using UnityEngine;
using System.Collections;

public class Boss : GenericCharacter {
	Vector3 playerPosition, diff;
	float rotation;
	GameObject boss;

	// Update is called once per frame
	void Update () 
	{
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		
		if (currentTime >= fireRate) 
		{
			fireArrow("EnemyArrow");
			currentTime = 0;            
		}
		if (health <= 0) 
		{
			Destroy (gameObject);
			Debug.Log ("Boss is DEAD!!!!");
		}
	}
	
	//Rotate to face a player
	private void RotateToPlayer()
	{
		GameObject player = GameObject.Find("Player");
		Transform playerTransform = player.transform;
		// get player position
		playerPosition = playerTransform.position;
		playerPosition = new Vector3(playerPosition.x, playerPosition.y, 0);
		diff = playerPosition - transform.position;
		diff.Normalize();
		rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotation);
		
	}
	
	
	public void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "EnemyArrow") return;
		if (col.gameObject.tag.Equals("PlayerArrow")) 
		{
			health--;
			RePool(col.gameObject);
		}
	}
	
	
	
}