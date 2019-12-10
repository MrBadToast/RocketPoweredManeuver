using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Explosion;
    public float PropellantVelocity = 2.0f;
    public LayerMask Collidable;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rbody.velocity = transform.up * PropellantVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(Collidable.value & 1 << collision.gameObject.layer);
        Debug.Log(1 << collision.gameObject.layer);

        if ((Collidable.value & 1 << collision.gameObject.layer) == 1<<collision.gameObject.layer)
        {
            Blast();
        }
    }

    private void Blast()
    {
        Instantiate(Explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
