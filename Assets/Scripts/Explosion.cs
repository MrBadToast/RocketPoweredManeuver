using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public LayerMask Character;
    public float MaxRepulsiveForce = 10f;
    public float RepulsiveForceFactor = 1.0f;
    public float MinimumLift = 1.0f;
    public float Radius = 2f;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    private void OnEnable()
    {
        RaycastHit2D c;
        c = Physics2D.CircleCast(transform.position, Radius, Vector2.up, 1f, Character);
        if(c)
        {
            Debug.Log("character affected by explosion");
            GameObject c_obj = c.collider.gameObject;
            Rigidbody2D c_rbody = c.rigidbody;
            Vector2 CharacterForceRecieve =
                Vector2.ClampMagnitude(RepulsiveForceFactor*((c_obj.transform.position - this.transform.position).normalized * Radius / Vector2.Distance(c_obj.transform.position, this.transform.position)),MaxRepulsiveForce)
                + Vector2.up * MinimumLift * RepulsiveForceFactor;

            if (c_rbody.velocity.y < 0 && c_obj.transform.position.y > transform.position.y)
                CharacterForceRecieve += new Vector2(0f, c_rbody.velocity.y * 2);

            Debug.Log("CharacterForceRecieve : " + CharacterForceRecieve);
            c_obj.GetComponent<Rigidbody2D>().AddForce(CharacterForceRecieve);
        
        }
    }
}
