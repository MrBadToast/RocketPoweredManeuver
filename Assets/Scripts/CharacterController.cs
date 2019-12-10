using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public UnityEngine.UI.Slider ControlSlider;
    public float HorForceFactor = 1f;

    Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rbody.AddForce(Vector2.right * ControlSlider.value * HorForceFactor);
    }

    void FireProjectile(Vector2 direction)
    {

    }

}
