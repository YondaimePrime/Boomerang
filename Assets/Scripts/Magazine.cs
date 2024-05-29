using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magazine : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI magazineRounds;

    [SerializeField]
    private GameObject chakramObject;
    private int currentChakrams = 1;
    private float maxChakrams = 3f;

    private float timeUntilSpawn;
   

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
   { 
        
        if(currentChakrams < maxChakrams)
        {
            timeUntilSpawn -= Time.deltaTime;

            if(timeUntilSpawn <= 0)
            {   
                
                Instantiate(chakramObject, transform.position = new Vector3 (
                    transform.position.x,
                    transform.position.y,
                    transform.position.z
                ), 
                Quaternion.identity);
                SetTimeUntilSpawn();
            }

            
        }
        magazineRounds.text = "Ammo: " + currentChakrams.ToString() + "/3";
        currentChakrams = GameObject.FindGameObjectsWithTag("chakram").Length;
    }

    private void SetTimeUntilSpawn(){
        timeUntilSpawn = 3f;
    }

    
}
