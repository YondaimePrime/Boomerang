using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI tutorialTextField;

    private GameObject tutorialPanel;
    private GameObject reactor;

    private float counter = 0f;

    private string[,] tutorialText;

    private int tutorialStageIndex; //stage counter
    private int tutoriaTextlIndex; //which text is displayed

    private int tutorialChange = 1; //how many seconds for text change
    private int numberOfTexts = 6;
    private int tutorialStages = 3;

    private int maxShips;
    private GameObject[] enemies;

    private bool waitingToLeave = false;

    private bool destroyed = false;

    
    void Awake()
    {   
        tutorialPanel = GameObject.FindGameObjectWithTag("tutorialPanel");

        reactor = GameObject.FindGameObjectWithTag("reactor");
        reactor.gameObject.SetActive(false);

        tutorialStageIndex = 0;
        tutorialText = new string[tutorialStages,numberOfTexts];

        tutorialText[0,0] = "Welcome to the Tutorial";
        tutorialText[0,1] = "You may notice ships flying around you!";
        tutorialText[0,2] = "Those are enemies! You can see how many enemies are remaining in bottom right corner.";
        tutorialText[0,3] = "You can destroy them by throwing 'chakrams' at them.\nYou will find them strapped to your lower back.";
        tutorialText[0,4] = "You don't need to hit, they will return to you even if you miss.";
        tutorialText[0,5] = "Try to destroy an enemy by throwing 'chakram' at them!";

        tutorialText[1,0] = "Congratulations you destroyed ship!";
        tutorialText[1,1] = "You also may noticed that your 'chakram' didn't return to you after it destroyed enemy";
        tutorialText[1,2] = "Don't worry it just regenareted on your back.";
        tutorialText[1,3] = "This is tutorial so there's no danger of loosing here";
        tutorialText[1,4] = "But in real game this ships will try to destroy you";
        tutorialText[1,5] = "You of course don't want that. So you must destroy them faster then they destroy you!";

        tutorialText[2,0] = "Okay this is the last thing.";
        tutorialText[2,1] = "After you destroy all the enemies reactor spawns near you.";
        tutorialText[2,2] = "This is what we are after you need to destroy it at all cost.";
        tutorialText[2,3] = "In this tutorial we prepared one for you in front of you.";
        tutorialText[2,4] = "After you destroy it you will be taken back to menu. If you want you can destroy all the enemies first.";
        tutorialText[2,5] = "Destroy the reactor when you are ready.";
    }

    void Update()
    {   
        enemies =  GameObject.FindGameObjectsWithTag("enemy");

        counter += Time.deltaTime;

        tutoriaTextlIndex = (int)counter/tutorialChange;
       
        print("Stage: " + tutorialStageIndex + " Page: " + tutoriaTextlIndex);
        
        if(tutoriaTextlIndex == numberOfTexts)
        {
            counter = 0;
            tutoriaTextlIndex = 0;
            tutorialPanel.gameObject.SetActive(false);
            if(destroyed)
            {
                reactor.gameObject.SetActive(true);
                tutorialStageIndex += 1;
                waitingToLeave = true;
            }
        }

        if(waitingToLeave)
        {
            counter = 0;
        }

        if(enemies.Length>maxShips)
        {
            maxShips=enemies.Length;
        }

        if(enemies.Length<maxShips && !destroyed)
        {
            destroyed = true;
            counter = 0;
            tutorialStageIndex += 1;
            tutoriaTextlIndex = 0;
            tutorialPanel.gameObject.SetActive(true);
        }

        tutorialTextField.text = tutorialText[tutorialStageIndex,tutoriaTextlIndex];
    }
}
