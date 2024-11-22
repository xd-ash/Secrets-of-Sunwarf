using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class ItemInteract : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private GameManager.QuestState qStateChange;

    public void Interact() 
    {   
        Debug.Log("Interactable!");
        gameManager.UpdateQuestState(qStateChange);
    }



}
