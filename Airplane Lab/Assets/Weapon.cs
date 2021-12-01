using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
	[SerializeField] GameObject weapon;
	
    void Start() {
        
    }
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		Instantiate(weapon, firePoint.position, firePoint.rotation);
	}
}
