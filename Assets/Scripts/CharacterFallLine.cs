using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CharacterFallLine : MonoBehaviour
{
    public Transform Character;
    public PlayableDirector GameEnd;

    private void Update()
    {
        if(Character.position.y < transform.position.y)
        {
            GameEnd.Play();
            gameObject.SetActive(false);
        }
    }
}
