﻿using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public int level;
	
	public void levelManager () {
		Application.LoadLevel (level); 	
		
	}
	
	void Update() 
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
			
		} 
		
	} 
}
