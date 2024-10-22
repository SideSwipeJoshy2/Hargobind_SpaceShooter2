using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomb : MonoBehaviour
{
    public float radius = 10;
    public float force = 100;
    ContactFilter2D contactFilter;
   Collider2D[] affectedColliders = new Collider2D[25];



    private void Update()
    {
        if(Input.GetKey(KeyCode.B))
        {
            StartCoroutine(bombExplode());
           
        }
    }
   
    void Boom()
    { //overlap circle just checks what is within the colider, just in a circle
        int numColliders = Physics2D.OverlapCircle(transform.position, radius, contactFilter, affectedColliders);

        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)//creates the force needed for the bomb
            {
                if (affectedColliders[i].gameObject.TryGetComponent(out Rigidbody2D rb))
                {
                    Vector3 forceDirection = rb.transform.position - transform.position;
                    float distanceModifier = 1 - (Mathf.Clamp(forceDirection.magnitude, 0, radius) / radius);

                    Vector2 forcePosition = affectedColliders[i].ClosestPoint(transform.position);
                    rb.AddForceAtPosition((forceDirection * force) * distanceModifier, forcePosition);
                }
            }
        }
    }

    IEnumerator bombExplode()//timer for bomb
    {
        yield return new WaitForSeconds(1f);
        Boom();
        yield return null;
    }






}

