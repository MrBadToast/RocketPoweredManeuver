using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterController : MonoBehaviour
{
    public UnityEngine.UI.Slider ControlSlider;
    public GameObject ProjectileObject;
    public Transform RCO_Foot;
    public float HorForceFactor = 1f;
    public float Friction = 0.5f;

    Rigidbody2D rbody;
    Animator animator;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rbody.AddForce(Vector2.right * ControlSlider.value * HorForceFactor);

        if(Physics2D.Raycast(RCO_Foot.position,Vector2.down,0.1f))
        {
            animator.SetBool("Grounded", true);
            rbody.AddForce( -Friction * rbody.velocity.normalized);
        }
        else
            animator.SetBool("Grounded", false);

        animator.SetFloat("HorizontalInput", Mathf.Abs(ControlSlider.value));
        animator.SetFloat("VerticalSpeed", rbody.velocity.y);

    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectileToDown();
        }
#endif

    }

    public void FireProjectileToDown()
    {
        FireProjectile(Quaternion.AngleAxis(180f, Vector3.forward));
    }

    //private void FireProjectile(Vector3 direction)
    //{
    //    Instantiate(ProjectileObject, transform.position,Quaternion.LookRotation(direction,Vector3.up));
    //}

    private void FireProjectile(Quaternion direction)
    {
        Instantiate(ProjectileObject, transform.position, direction);
    }


}
