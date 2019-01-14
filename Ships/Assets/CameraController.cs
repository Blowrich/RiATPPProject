using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform Target;

	// Use this for initialization
	void Start () 
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () 
    {
        if(Target)
            transform.position = Vector3.Lerp(transform.position, Target.position, 0.125f);
	}
}
