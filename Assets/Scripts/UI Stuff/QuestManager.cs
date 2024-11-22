using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using System;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject Menu;

    private void Awake()
    {
        GameManager.OnStateChange += OnMenuStateChange;
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= OnMenuStateChange;
    }

    private void OnMenuStateChange(GameState state)
    {
        Menu.SetActive(state == GameState.Menu);    
    }
}
