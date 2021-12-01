using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 5.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        if (enemy == null) 
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame; best for user input
    void Update()
    {
      
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-speed, rigid.velocity.y); //horizontal movement
        if (speed < 0 && isFacingRight || speed > 0 && !isFacingRight)
            Flip();

        
    }

    private void Flip()
    {
        //Vector3 playerScale = transform.localScale;
        //playerScale.x = playerScale.x * -1;
        //transform.localScale = playerScale;

        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    //when we collide with the ground (here our ramp), we want to note that Mario is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Destroy(enemy);
    }
}
