using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AvgSpeedMeter : MonoBehaviour
{
    public Rigidbody2D Chr_rbody;
    public float AvgSpeed = 0.0f;

    TextMeshPro textMesh;

    float TimeElapsed = 0.1f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        if(Chr_rbody.velocity.x > 0.1f)
        {
            TimeElapsed += Time.deltaTime;
        }

        AvgSpeed = (Chr_rbody.transform.position.x * 2 / TimeElapsed);

        textMesh.text = ((int)AvgSpeed).ToString();
    }

    public void ResetMeter()
    {
        TimeElapsed = 0.1f;    
    }
}
