using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;
    private Vector3 velo2 = Vector3.zero;
    private float maxSpeed;

    //The amount of time it will take to reach the target speed(1 is v fast, slow speed is 3)
    private float timeToReachSpeed = 3f;
    //The speed that we want the character to reach after a certain amount of time
    private float targetSpeed = 2f;
    private float deacceleration;
    private float acceleration;
    private float acceltime;

    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
        deacceleration = acceleration - 10;
    }

    private void Update()
    {
        velocity += acceleration * transform.up * Time.deltaTime;
        velo2 += acceleration * transform.right * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        enemyMove();

    }

    public void enemyMove()
    {
       if (Input.GetKeyUp(KeyCode.W))
        {

            transform.position -= deacceleration * velocity.normalized * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position -= deacceleration * velocity.normalized * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position -= deacceleration * velocity.normalized * Time.deltaTime;

        }

    }

}
