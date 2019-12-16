using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGameManager : MonoBehaviour
{
    public static GeneralGameManager Instance;

    public GameObject Character;
    public GroundManager GroundManagerScript;
    public AvgSpeedMeter Avgmeter;
    public GameObject fallLine;

    public Vector3 InitialCharacterPosition;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        if(InitialCharacterPosition == Vector3.zero)
        {
            InitialCharacterPosition = Character.transform.position;
        }
    }

    public void ResetGame()
    {
        Character.transform.position = InitialCharacterPosition;
        GroundManagerScript.ResetGround();
        Avgmeter.ResetMeter();
        fallLine.SetActive(true);
    }
}
