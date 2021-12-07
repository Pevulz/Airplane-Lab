using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed = 5.0f;
    Player target;
    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null) 
            bullet = GameObject.FindGameObjectWithTag("EnemyBullet");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        //shoots where player is at 
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rigid.velocity = new Vector2 (moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(bullet);;
    }
}
