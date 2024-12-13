using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ItemInteract : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private GameManager.QuestState qStateChange;
    public GameObject test;

    private void Update()
    {
        if (gameManager == null)
        {
            test = GameObject.FindGameObjectWithTag("GameController");
            gameManager = test.GetComponentInParent<GameManager>(); 
        }
        else
        {
            return;
        }
    }

    public void Interact() 
    {   
        Debug.Log("Interactable!");
        gameManager.UpdateQuestState(qStateChange);
    }



}
