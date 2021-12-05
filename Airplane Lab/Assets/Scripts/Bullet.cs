using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null) 
            bullet = GameObject.FindGameObjectWithTag("Bullet");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigid.velocity = new Vector2(2 * speed, rigid.velocity.y); //horizontal movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(bullet);
    }
}
