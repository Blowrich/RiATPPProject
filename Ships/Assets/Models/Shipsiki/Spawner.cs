using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject PlPref;
    public GameObject AlPref;
    public GameObject EnPref;

    public List<GameObject> Allies;
    public List<GameObject> Enemies;
    public GameObject Player;

    public Transform[] Points;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClearGarbage();
		if(Player == null)
        {
            GameObject pl = Instantiate<GameObject>(PlPref, Points[Random.Range(0, Points.Length)].position, Quaternion.identity);
            Player = pl;
        }

        if (Allies.Count < 4)
        {
            GameObject al = Instantiate<GameObject>(AlPref, Points[Random.Range(0, Points.Length)].position, Quaternion.identity);
            Allies.Add(al);
        }

        if (Enemies.Count < 4)
        {
            GameObject el = Instantiate<GameObject>(EnPref, Points[Random.Range(0, Points.Length)].position, Quaternion.identity);
            Enemies.Add(el);
        }
    }

    public void ClearGarbage()
    {
        for (int i = 0; i < Allies.Count; i++)
        {
            if (Allies[i] == null)
                Allies.Remove(Allies[i]);
        }

        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] == null)
                Enemies.Remove(Enemies[i]);
        }
    }
}
