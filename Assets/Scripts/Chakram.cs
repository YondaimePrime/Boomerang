using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chakram : MonoBehaviour
{   
    
    private GameObject magazine;

    private float distanceBetweenObjects;

    [SerializeField]
    private float distanceOnReverse = 30f;

    private float velocity;

    private bool afloat;

    void Awake()
    {
        magazine = GameObject.FindGameObjectWithTag("magazine");
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.GetComponent<Rigidbody>().velocity.magnitude;

        distanceBetweenObjects = Vector3.Distance(transform.position, magazine.transform.position);

        if(distanceBetweenObjects >= distanceOnReverse){
            afloat = true;
            print(velocity);

        }

        if(distanceBetweenObjects < 0.1f)
        {
            afloat = false;
        }

        if(afloat)
        {
            if(velocity == 0f)
            {
                velocity = 0.005f;
            }
            transform.position = Vector3.MoveTowards(transform.position, magazine.transform.position, velocity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("magazine"))
        {
          transform.position = other.gameObject.transform.position;
        }

        if(other.gameObject.CompareTag("reactor"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
