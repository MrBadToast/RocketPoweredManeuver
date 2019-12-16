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
    public float Friction = 1.0f;

    Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rbody.AddForce(Vector2.right * ControlSlider.value * HorForceFactor);
        if(Physics2D.Raycast(RCO_Foot.position,Vector2.down,0.1f))
        {
            rbody.AddForce(-Friction * rbody.velocity.normalized);
        }

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
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
