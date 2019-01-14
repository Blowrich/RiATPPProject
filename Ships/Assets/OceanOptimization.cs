using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanOptimization : MonoBehaviour {
    public Transform[] tiles;
    public Transform Player;
    public Transform[] Waypoints;
    public float MinDistance = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if(Vector3.Distance(Player.position, tiles[i].position) < MinDistance)
            {
                //tiles[i].gameObject.SetActive
            }
        }
	}
}
