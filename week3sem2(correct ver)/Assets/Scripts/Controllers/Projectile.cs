using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
using JetBrains.Annotations;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float turnSpeed = 90;
    public float smoothTime = 0.3f;
    float angle;
    public float moveSpeed = 10;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//gets mouse input and converts it into a usable vector 
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        
        Vector3 targetRotation = new Vector3(0, 0, angle);//makes turning and the like possible
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);
        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        Destroy(projectile, 5f);
         if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(projectile, Vector3.zero, Quaternion.identity);//spawns new projectiles in
           
        }

    }

    
   
}
