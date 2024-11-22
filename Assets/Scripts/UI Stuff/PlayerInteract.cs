using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
  private void Update() 
  {
    if(Input.GetKeyDown(KeyCode.E))
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCConversation npcInteract))
            {
              npcInteract.Interact();
              Cursor.lockState = CursorLockMode.None;
              Cursor.visible = true;
            }
        }
    }
    if(Input.GetKeyDown(KeyCode.E))
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out ItemInteract itemInteract))
            {
              itemInteract.Interact();
            }
            return;
        }
    }
  }

  public NPCConversation getInteractableObject()
  {
    float interactRange = 2f;
    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    foreach (Collider collider in colliderArray)
    {
      if(collider.TryGetComponent(out NPCConversation npcInteract))
      {
        return npcInteract;
      }
    }
    return null;
  }

  public ItemInteract getInteractableObject2()
  {
    float interactRange = 2f;
    Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
    foreach (Collider collider in colliderArray)
    {
      if(collider.TryGetComponent(out ItemInteract itemInteract))
      {
        return itemInteract;
      }
    }
    return null;
  }






}
