using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interactable!");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
