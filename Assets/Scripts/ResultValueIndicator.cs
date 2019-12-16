using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultValueIndicator : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    public float value = 0.0f;
    [Range(0.0f, 1.0f)]
    public float factor = 0.0001f;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        textMesh.text = ((int)(value*factor)).ToString();
    }
}
