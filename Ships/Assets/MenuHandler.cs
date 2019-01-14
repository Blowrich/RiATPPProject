﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSceneNumber(int number)
    {
        if(number < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(number);
    }

    public void Exit()
    {
        Application.Quit();
    }
}