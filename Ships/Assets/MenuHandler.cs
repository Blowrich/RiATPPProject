using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {
    public GameObject GameMenu;
	// Use this for initialization
	void Start () {
		
	}

    public void GameMenuOnOff()
    {
        GameMenu.SetActive(!GameMenu.activeSelf);
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
