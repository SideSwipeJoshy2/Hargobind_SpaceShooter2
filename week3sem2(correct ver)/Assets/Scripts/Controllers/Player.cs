using System.Collections;
using System.Collections.Generic;
using Codice.Client.Common.GameUI;
using Codice.CM.Client.Differences;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;


    public float radius;
    public List<int> circlePoints = new List<int>() { 0, 45, 90, 135, 180, 270, 360 };
    private int currentCirclePoint;
    public Vector3 offset;
    public float updateFrequency;

    private float timeSinceLastUpdate = 0f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 velo2 = Vector3.zero;
    private float maxSpeed;


    //The amount of time it will take to reach the target speed(1 is v fast, slow speed is 3)
    private float timeToReachSpeed = 30f;
    //The speed that we want the character to reach after a certain amount of time
    private float targetSpeed = 2f;
    private float deacceleration;
    private float acceleration;
    private float acceltime;
    private List<string> words = new List<string>();


    private void Start()
    {
        acceleration = targetSpeed / timeToReachSpeed;
        deacceleration = acceleration - 5;
    }
    void Update()
    {
        velocity += acceleration * transform.up * Time.deltaTime;
        velo2 += acceleration * transform.right * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        playerMove();
        enemyRadar();

        words.Add("Cat");
        words.Add("Dog");

        words.Add("Log");
        words.Add("Car");


        words.Insert(2, "Log");
        words.Remove("Dog");
        Debug.Log("Box is currently at the index: " + words.IndexOf("Box"));

        for (int i = 0; i < words.Count; i++)//both work
        {
            Debug.Log(words[i]);
        }

        foreach (string word in words)
        {
            Debug.Log(word);
        }




    }

    public void playerMove()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            transform.position += acceleration * velocity.normalized * Time.deltaTime;
            //update velo instead of pos

        }

        else if (Input.GetKeyUp(KeyCode.UpArrow)) {

            acceleration = deacceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= acceleration * velocity.normalized * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= acceleration * velo2.normalized * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += acceleration * velo2.normalized * Time.deltaTime;

        }
    }

    public void spawnPowerUps(float radius, int numberOfPowerUps)
    {
        Vector3 test = new Vector3(0, 2);

        numberOfPowerUps = 4;

        if (radius ==1 )
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



   

