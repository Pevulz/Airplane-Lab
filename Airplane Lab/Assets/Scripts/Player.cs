using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject player;
    public HealthBar healthbar;
    public int hp = 10;
    public int currentHp;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float dirX; //horizontal
    [SerializeField] float dirY; //vertical
    [SerializeField] bool isFacingRight = true;
    [SerializeField] Transform firePoint;
	[SerializeField] GameObject weapon;


    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        healthbar.setMaxHealth(hp);

        if (player == null) 
            player = GameObject.FindGameObjectWithTag("Player");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();   

        // Freeze the rotation
        rigid.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        dirX = Input.GetAxis ("Horizontal") * moveSpeed;
        dirY = Input.GetAxis ("Vertical") * moveSpeed;

        //shooting
        if (Input.GetButtonDown("Jump"))
		{
			Shoot();
		}
    }

    void FixedUpdate() 
    {
        //movement
        rigid.velocity = new Vector2 (dirX, dirY);
        if (dirX < 0 && isFacingRight || dirX > 0 && !isFacingRight)
            Flip();
    }

    void Shoot ()
	{
        //spawn bullet at player location
		Instantiate(weapon, firePoint.position, firePoint.rotation);
	}

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void takeDmg(int damage) {
        currentHp -= damage;
        healthbar.setHealth(currentHp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dies instantly if player touches enemies
        if (collision.gameObject.tag == "Enemy") {
            Destroy(player);
            SceneManager.LoadScene("Level 1");
        }

        //dies when player is out of hp from bullets
        if (collision.gameObject.tag == "EnemyBullet")
            takeDmg(3);
            if(currentHp <= 0) {
                Destroy(player);
                SceneManager.LoadScene("Level 1");
            }
    }
}
