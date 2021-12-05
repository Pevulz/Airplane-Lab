using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bullet;
    public HealthBar enemyHealthbar;
    public int hp = 10;
    public int currentHp;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] float fireRate = 1f;
    private float nextFire;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        enemyHealthbar.setMaxHealth(hp);
        
        if (enemy == null) 
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (bullet == null) 
            bullet = GameObject.FindGameObjectWithTag("Bullet");
        

        // Freeze the rotation
        rigid.freezeRotation = true;
        fireRate = 1f;
        nextFire = Time.time;
    }

    
    // Update is called once per frame; best for user input
    void Update()
    {
        Fire();
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-moveSpeed, rigid.velocity.y); //horizontal movement  
    }

    void Fire()
    {
        if (Time.time > nextFire) {
            Instantiate (bullet, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    void takeDmg(int damage) {
        currentHp -= damage;
        enemyHealthbar.setHealth(currentHp);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            takeDmg(2);
            if(currentHp <= 0) {
                Die();
            }
        }
    }

    void Die() 
    {
        Destroy(enemy);
    }
}
