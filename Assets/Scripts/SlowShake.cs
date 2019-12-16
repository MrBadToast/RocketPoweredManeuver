using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShake : MonoBehaviour
{
    public Vector2 ShakeRange;
    public float Scale = 1.0f;
    public float SpeedScale = 1.0f;

    Vector2 LegacyPosition;

    private void OnEnable()
    {
        LegacyPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localPosition = LegacyPosition;
        LegacyPosition = transform.localPosition;
        transform.localPosition += new Vector3(Mathf.PerlinNoise(Time.time*SpeedScale, 0f) * ShakeRange.x * Scale, Mathf.PerlinNoise(0f, Time.time*SpeedScale) * ShakeRange.y * Scale);
    }
}
