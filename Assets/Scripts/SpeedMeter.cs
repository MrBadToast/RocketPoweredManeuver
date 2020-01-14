using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody2D Chr_rbody;
    public float MaxSpeed = 0.0f;

    TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        float CurrentSpeed = Mathf.Abs(Chr_rbody.velocity.x * 2);

        textMesh.text = ((int)CurrentSpeed).ToString();

        if (MaxSpeed < CurrentSpeed)
            MaxSpeed = CurrentSpeed;
    }
}
