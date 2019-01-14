using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {
    public Transform Target;
    public float LerpTime = 1f;
	// Use this for initialization
	void Start () {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(Target) transform.position = Vector3.Lerp(transform.position, Target.position, LerpTime);

        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}
}
