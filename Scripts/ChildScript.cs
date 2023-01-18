using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private bool isRight = true; //r
    private GameObject parent;
    private Rigidbody2D rb;
    public GameObject curPointHit;
    public bool playerHit = false;
    private GameObject pointObjs;

    void Start()
    {
        parent = GameObject.Find("Dial");
        rb = GetComponent<Rigidbody2D>();
        pointObjs = parent.GetComponent<Player>().pointObjs; // Compress the parent script into a variable later
    }

    void Update()
    {
        parent.GetComponent<Player>().Rotate(isRight);
        Movement();
    }


    void OnTriggerEnter2D(Collider2D other)
    { 
        curPointHit = other.gameObject;
        curPointHit.GetComponent<Point>().isHit = true;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        curPointHit.GetComponent<Point>().isHit = false;
    }

    void PickRandomPoint(GameObject lastPoint) 
    {
        // Exclude the last point
        int randomStart = Random.Range(0, pointObjs.Count);
        
    }

    void Movement()
    {
        if (Input.GetKeyDown("space"))
        {

            bool isPointHit = curPointHit == null ? false : curPointHit.GetComponent<Point>().isHit;

            if (isPointHit == true) // if both the player is pressing space and the point is being collided with then the player hit the point
            {
                int pointCollisions = curPointHit.GetComponent<Point>().collisions;
                playerHit = true;
                pointCollisions += 1; // collisions should only be incremented if the player hits space and they are colliding with each other
                isRight = pointCollisions == 1 ? !isRight : isRight;
                curPointHit.SetActive(false);
                // Destroy(curPointHit);
                PickRandomPoint(curPointHit); // then pick a random point to spawn in.
                curPointHit = null;
            }
        }
    }
}
