using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody2D Chr_rbody;

    TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        textMesh.text = ((int)Chr_rbody.velocity.x*2).ToString();
    }
}
