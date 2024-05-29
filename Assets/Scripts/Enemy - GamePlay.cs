using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGame : MonoBehaviour
{   

    [SerializeField]
    private GameObject explosionEffect;

    private GameObject player;

    private float rotationSpeed = 10f;

    private float height;
    private float maxHeight = 25f;

    private float centeringSpeed;

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
        centeringSpeed = 0.1f * Time.deltaTime;
        height = transform.position.y;

        if(height > 1f)
        {
            transform.Translate(0,0,-centeringSpeed);
        }
        transform.RotateAround(player.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
        transform.Translate(centeringSpeed,0,0);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
        
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 3);

            print("You died");
            SceneManager.LoadScene("LooseScreen");
        }

        if(other.gameObject.tag == "chakram")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 3);

            print("Ship Destroyed");
        }
    }
}
