using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;


public class Controls : MonoBehaviour
{
    public GameManager gameManager;
    public bool showMenu = false;

    public float speed = 5f;
    private Vector2 move;

    public GameObject managerHolder;

    private void Awake()
    {
        managerHolder = GameObject.FindGameObjectWithTag("GameController");
        gameManager = managerHolder.GetComponentInParent<GameManager>();
    }

    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        Vector3 offset = new Vector3(move.x, 0f, move.y);

        //offset = transform.TransformDirection(offset); changes direction to where looking pretty much

        transform.position += offset * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            showMenu = !showMenu;
            if (showMenu)
            {
                gameManager.UpdateGameState(GameManager.GameState.Menu);
            }
            if (!showMenu) 
            {
                gameManager.UpdateGameState(GameManager.GameState.Gameplay);
            }
        }
    }
    
}
