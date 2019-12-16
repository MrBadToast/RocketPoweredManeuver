using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject StartGround;
    public GameObject GroundPrefab;
    public GameObject MainCamera;
    public int GenerateCount = 10;

    public int spaceMin = 1;
    public int spaceMax = 5;

    public int yMin = -8;
    public int yMax = -6;

    public int widthMin = 1;
    public int widthMax = 10;
    public int height = 10;

    float GenerateDistance = 100f;

    public List<GameObject> groundList;
    int Seed;

    private void Awake()
    {
        groundList = new List<GameObject>();

        Seed = System.DateTime.Now.Millisecond;
        Random.InitState(Seed);
        Debug.Log("Random Seed : " + Seed);
        groundList.Add(StartGround);
    }

    private void Start()
    {
        for(int i = 0; i < GenerateCount; i++)
        {
            GenerateGround(GroundPrefab);
        }
    }

    private void Update()
    {
        if(groundList[groundList.Count-1].transform.position.x < MainCamera.transform.position.x + GenerateDistance)
        {
            GenerateGround(GroundPrefab);
        }
    }

    public void ResetGround()
    {
        for(int i = 1; i < groundList.Count; i++)
            Destroy(groundList[i]);
        groundList.Clear();
        groundList.Add(StartGround);
    }

    GameObject GenerateGround(GameObject groundObject)
    {
        Transform t_lastGround = groundList[groundList.Count - 1].transform;
        GameObject newGround = InstanciateGround(
            groundObject,
            t_lastGround.position + new Vector3(t_lastGround.localScale.x / 2 + Random.Range(spaceMin, spaceMax), 0f),
            new Vector3(Random.Range(widthMin, widthMax), height)
            );

        newGround.transform.position += new Vector3(newGround.transform.localScale.x / 2, 0f);
        newGround.transform.position = new Vector3(newGround.transform.position.x, Random.Range(yMin, yMax));

        groundList.Add(newGround);

        return newGround;
    }

    GameObject InstanciateGround(GameObject groundObject ,Vector2 pos, Vector2 size)
    {
        GameObject newGround;
        newGround = Instantiate(groundObject, pos, Quaternion.identity);
        newGround.transform.localScale = size;

        return newGround;
    }
}

