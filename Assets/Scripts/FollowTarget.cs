using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public bool FollowOnlyX = false;
    public bool FollowOnlyY = false;

    Vector3 legacyPos;

    void FixedUpdate()
    {
        transform.position = legacyPos;
        legacyPos = transform.position;

        if (!FollowOnlyX && !FollowOnlyY)
            transform.position = target.position + offset;
        else if (FollowOnlyX == true && !FollowOnlyY)
            transform.position = new Vector3(target.position.x, transform.position.y) + offset;
        else if (FollowOnlyY == true)
            transform.position = new Vector3(transform.position.x, target.position.y) + offset;

        
    }
}
