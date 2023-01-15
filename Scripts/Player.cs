using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    public List<GameObject> pointObjs = new List<GameObject>();
    private GameObject child;


    void Start()
    {
        /*
        pointLocations.Add(new Vector3(2f, 0f, 0f));
        pointLocations.Add(new Vector3(-2f, 0f, 0f));
        pointLocations.Add(new Vector3(0f, 2f, 0f));
        pointLocations.Add(new Vector3(0f, -2f, 0f));
        */
        pointObjs.Add(GameObject.Find("PointLeft"));
        pointObjs.Add(GameObject.Find("PointRight"));
        pointObjs.Add(GameObject.Find("PointUp"));
        pointObjs.Add(GameObject.Find("PointDown"));

        // Then Select one random gameobject to be displayed and set it as active
        int randomStart = Random.Range(0, pointObjs.Count);
        // System.Random rndInt = new System.Random();
        // int randNum = rndInt.Next(0, pointObjs.Count);

        print(randomStart);
        // print(pointObjs.Count);
        // print(randNum);
        // Make point send it in the opposite direction the lock is traveling (maybe try using negative ?)
        child = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate(bool hit) // bool isRight
    {
        int multiplier = hit ? -1 : 1;
        transform.Rotate(new Vector3(0, 0, rotationSpeed * multiplier) * Time.deltaTime);
    }
}
