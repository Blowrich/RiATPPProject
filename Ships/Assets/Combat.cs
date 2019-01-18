using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
    public Transform LeftWeapons;
    public Renderer lAim;
    public Renderer rAim;
    public Transform RightWeapons;
    public GameObject BallPrefab;
    public float ShotForce = 100f;
    public bool CanShotRight = true;
    public bool CanShotLeft = true;
    public bool Player = false;
    public GameObject ps1;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void ShotRight()
    {
        if (CanShotRight)
            StartCoroutine(ShotDelayRight());
    }

    public void ShotLeft()
    {
        if (CanShotLeft)
            StartCoroutine(ShotDelayLeft());
    }

    IEnumerator ShotDelayRight()
    {
        CanShotRight = false;
        GameObject clone = Instantiate<GameObject>(BallPrefab, RightWeapons.position, transform.rotation);
        //if (Player)
        {
            clone.AddComponent<SpecialBullet>();
            clone.GetComponent<SpecialBullet>().MyHealth = GetComponentInChildren<HealthManager>();
            clone.GetComponent<SpecialBullet>().MyTag = gameObject.tag;
        }
        clone.GetComponent<Rigidbody>().AddForce(transform.right * ShotForce);
        GameObject lk = Instantiate<GameObject>(ps1, RightWeapons.position, transform.rotation);
        Destroy(lk, 2);
        Destroy(clone, 2f);
        yield return new WaitForSeconds(10);
        CanShotRight = true;
    }

    IEnumerator ShotDelayLeft()
    {
        CanShotLeft = false;
        GameObject clone = Instantiate<GameObject>(BallPrefab, LeftWeapons.position, transform.rotation);
        {
            clone.AddComponent<SpecialBullet>();
            clone.GetComponent<SpecialBullet>().MyHealth = GetComponentInChildren<HealthManager>();
            clone.GetComponent<SpecialBullet>().MyTag = gameObject.tag;
        }
        GameObject lk = Instantiate<GameObject>(ps1, LeftWeapons.position, transform.rotation);
        Destroy(lk, 2);
        clone.GetComponent<Rigidbody>().AddForce(-transform.right * ShotForce);
        Destroy(clone, 2f);
        yield return new WaitForSeconds(10);
        CanShotLeft = true;
    }
}
