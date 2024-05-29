using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   

    [SerializeField]
    private GameObject explosionEffect;

    private GameObject player;

    private float rotationSpeed = 10f;

    private float height;
    private float maxHeight = 25f;


    void Awake()
    {

        //spawn position
        transform.position = new Vector3(
            20,
            Random.Range(1,maxHeight), 
            0
        );

        //spawn rotation
        transform.eulerAngles = new Vector3(
            -90,
            0,
            180
        );

        player = GameObject.FindGameObjectWithTag("player");
    }
    
    void Update()
    {   
            height = transform.position.z;

            if(height > 1)
            {

            }            
            transform.RotateAround(player.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player" || other.gameObject.tag == "chakram")
        {
        
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 3);
        }
    }
}
