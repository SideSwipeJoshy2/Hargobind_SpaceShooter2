using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 offset = Vector3.zero;
    // Start is called before the first frame update

public List<Transform> asteroidTransforms;
public Transform enemyTransform;
public GameObject bombPrefab;
public Transform bombsTransform;
public float maxDetectionRange;
public float radarLength;

void Update()
{
    DetectAsteroids(maxDetectionRange, asteroidTransforms);
}

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            float distanceToAsteroid = Vector3.Distance(asteroid.position, transform.position);
            if (distanceToAsteroid < inMaxRange)
            {
                //If we are in range of the current asteroid then we are supposed to draw a line here
                Vector3 startPoint = transform.position;
                Vector3 endPoint = (asteroid.position - transform.position).normalized * radarLength;

                Debug.DrawLine(startPoint, endPoint, Color.green);
            }

        }

    }   
    }