using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractUI : MonoBehaviour
{
   [SerializeField] private GameObject containerGameObject;
   public PlayerInteract playerInteract;
   public GameObject player;


    private void Awake()
    {
        if (containerGameObject == null)
        {
            containerGameObject = GameObject.FindGameObjectWithTag("InteractButton");
            containerGameObject.SetActive(false);
        }
    }

    private void Update()
   {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerInteract = player.GetComponent<PlayerInteract>();
        }
        if (playerInteract.getInteractableObject() != null  ||playerInteract.getInteractableObject2() != null  ) 
        {
            Show();
        }
        else
        {
            Hide();
        }
   }

   private void Show()
   {
        containerGameObject.SetActive(true);
   }

   private void Hide()
   {
        containerGameObject.SetActive(false);
   }

}
