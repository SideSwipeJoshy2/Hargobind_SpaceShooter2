using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.GameUI;
using Codice.CM.Client.Differences;
using JetBrains.Annotations;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public GameObject projectile;

    public float radius;
    public List<int> circlePoints = new List<int>() { 0, 45, 90, 135, 180, 270, 360 };
    private int currentCirclePoint;
    public Vector3 offset;
    public float updateFrequency;
    private float timeSinceLastUpdate = 0f;

    private Vector3 transformSpawn;
    //Basic character movement: velocity
    public float maxSpeed;
    private Vector3 currentVelocity;

    //Acceleration
    public float accelerationTime;
    private float acceleration;

    //Deceleration
    public float decelerationTime;
    private float deceleration;
    private List<string> words = new List<string>();


    private void Start()
    {
        deceleration = maxSpeed / decelerationTime;
        acceleration = maxSpeed / accelerationTime;
      


}

    void Update()
    {

        Vector3 playerToEnemy = enemyTransform.position - transform.position;
        Debug.DrawLine(Vector3.zero, playerToEnemy, Color.red);

        //spawns a bomb if b is pressed
        if (Input.GetKey(KeyCode.B))
        {
            SpawnBombAtOffset(playerToEnemy);
           

        }



        enemyRadar();

        Vector2 currentInput = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentInput += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentInput += Vector2.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentInput += Vector2.down;
        }

        if (currentInput.magnitude > 0)
        {
            //Our character is accelerating
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;

            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            //Our character is decelerating
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if (velocityDelta.magnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;
    }



    

    void SpawnBombAtOffset(Vector3 inOffset)
    {
       
        inOffset.x = 1;
        bombPrefab = Instantiate(bombPrefab, transform.position + inOffset, Quaternion.identity);
        
       //bomb spawner
    }
   
    


   
    public void spawnPowerUps(float radius, int numberOfPowerUps)
    {
        Vector3 test = new Vector3(0, 2);

        numberOfPowerUps = 4;

        if (radius == 1)
        {

            numberOfPowerUps = 1;
            Vector3 ls = Vector3.zero;
        }
    }

    public void enemyRadar()
    {
        float currentAngle = circlePoints[currentCirclePoint];
        Vector3 startP = Vector3.zero;
        float endPointX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float endPointY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        Vector3 endingPoint = (new Vector3(endPointX, endPointY)) * radius + offset;
        Debug.DrawLine(startP, endingPoint, Color.green);


        timeSinceLastUpdate += Time.deltaTime;


        if (timeSinceLastUpdate > updateFrequency)
        {
            timeSinceLastUpdate = 0f;
            currentCirclePoint++;

            if (currentCirclePoint >= circlePoints.Count)
            {
                currentCirclePoint = 0;
            }

        }
    }
}







   

