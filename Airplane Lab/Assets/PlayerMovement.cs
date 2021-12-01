using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementH;
    [SerializeField] float movementV;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 5.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool isObject = false;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame; best for user input
    void Update()
    {
        movementH = Input.GetAxis("Horizontal");
        movementV = Input.GetAxis("Vertical");
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movementV * speed, rigid.velocity.y); //vertical movement
        rigid.velocity = new Vector2(movementH * speed, rigid.velocity.x); //horizontal movement
        if (movementH < 0 && isFacingRight || movementH > 0 && !isFacingRight)
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
        if (collision.gameObject.tag == "Wall")
            isObject = true;
    }


}