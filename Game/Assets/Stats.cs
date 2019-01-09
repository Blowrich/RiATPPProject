using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public float HP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        HP = Mathf.Clamp(HP, 0, 100);
        //if (HP <= 0)
        //    Destroy(gameObject);
	}

    public void GetDamage(float Damage)
    {
        HP -= Damage;
    }
}
