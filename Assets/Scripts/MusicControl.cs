﻿using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
	Player playerScript;
	int health;
	public AudioSource levelMusic;
	public AudioSource lowHealthMusic;
	bool lowHealth = false;
	// Use this for initialization
	void Start () 
	{

		levelMusic.Play();
		playerScript = GameObject.Find("Player").GetComponent<Player>();
		health = (int)playerScript.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		health = (int)playerScript.health;
		if (health <= 2 && lowHealth == false) 
		{
			levelMusic.volume=0.4f;
			lowHealth = true;
			lowHealthMusic.Play();
		}
		else if (health > 2 && lowHealth == true) 
		{
			levelMusic.volume=1.0f;
			lowHealth = false;
			lowHealthMusic.Stop();
		
		}
	}
}