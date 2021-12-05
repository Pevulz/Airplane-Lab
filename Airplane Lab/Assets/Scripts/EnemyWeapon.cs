using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
	[SerializeField] GameObject weapon;
    [SerializeField] float timer = 2000f;
	
    void Start() {
        
    }
	// Update is called once per frame
	void Update () {

			Shoot();
	}

	void Shoot ()
	{
        timer -= Time.deltaTime;
        if (timer <= 0) {
		    Instantiate(weapon, firePoint.position, firePoint.rotation);
        }
	}
}
