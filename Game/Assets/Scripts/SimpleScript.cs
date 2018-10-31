using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScript : MonoBehaviour {

    public int Temp=0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Temp++;
        if (Temp == 1337)
            Temp = 0;
	}
}
