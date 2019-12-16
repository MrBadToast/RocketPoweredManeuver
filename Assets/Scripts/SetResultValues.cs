using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResultValues : MonoBehaviour
{
    public ResultValueIndicator distance;
    public ResultValueIndicator speed;
    public ResultValueIndicator score;

    public AvgSpeedMeter avgspeedmeter;
    public Transform Character;

    public void SetValues()
    {
        distance.value = (int)Character.position.x;
        speed.value = (int)avgspeedmeter.AvgSpeed;
        score.value = (int)Character.position.x * (int)avgspeedmeter.AvgSpeed;
    }

}
