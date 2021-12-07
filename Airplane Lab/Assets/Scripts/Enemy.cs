using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource crash;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject bullet;
    public GameObject display;
    public HealthBar enemyHealthbar;
    public int hp = 10;
    public int currentHp;
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] int fireRate = 1;
    private float nextFire;
    private int direction = 1; //int direction where 0 is stay, 1 up, -1 down
    private int top = 3;
    private int bottom = -3;    
    public GameObject explosion;
    public Transform deathPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        enemyHealthbar.setMaxHealth(hp);
        
        if (display == null)
            display = GameObject.FindGameObjectWithTag("Display");
        if (enemy == null) 
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (bullet == null) 
            bullet = GameObject.FindGameObjectWithTag("Bullet");
        

        // Freeze the rotation
        rigid.freezeRotation = true;
        fireRate = 1;
        nextFire = Time.time;
    }

    
    // Update is called once per frame; best for user input
    void Update()
    {
        if (transform.position.y >= top)
            direction = -1;
        if (transform.position.y <= bottom)
            direction = 1;

        transform.Translate(0, moveSpeed * direction * Time.deltaTime, 0);
        
        Fire();
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
     
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
                display.GetComponent<Score>().AddPoints();
            }
        }
    }

    public void Die() 
    {
        Destroy(enemy);
        Instantiate(explosion, deathPoint.position, deathPoint.rotation = Quaternion.identity);
        AudioSource.PlayClipAtPoint(crash.clip, transform.position);
    }
}
