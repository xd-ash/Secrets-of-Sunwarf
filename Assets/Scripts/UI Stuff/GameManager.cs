using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public GameObject questMenu;

    public static event Action<GameState> OnStateChange;
    public QuestState questState;
    public static event Action<QuestState> OnQuestChange;
    public GameObject questPanel;
    public GameObject mainQuestPanel;

    public string towerScene;
    public bool towerWarp = false;
    public string baseScene;
    public GameObject player;
    public GameObject interactButton;


    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        questPanel.SetActive(false);
        mainQuestPanel.SetActive(false);
        UpdateGameState(GameState.Gameplay);
        UpdateQuestState(QuestState.Intro);
        questMenu.SetActive(false);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateGameState(State);
        UpdateQuestState(questState);
        player = GameObject.FindGameObjectWithTag("Player");
        interactButton.SetActive(false);
        questMenu.SetActive(false);

        if (scene.name == towerScene)
        {
            towerWarp = true;
        }

        if (scene.name == baseScene && towerWarp)
        {
            player.transform.position = new Vector3(130, 2, 113);
            towerWarp = false;
        }
    }

    public void UpdateGameState(GameState newstate)
    {
        State = newstate;

        switch(newstate)
        {
            case GameState.Gameplay:
                break;
            case GameState.Menu:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newstate), newstate, null);
        }

        OnStateChange?.Invoke(newstate);

    }


    public enum GameState
    {
        Menu,
        Gameplay,
    }

    public void UpdateQuestState(QuestState qState)
    {
        questState = qState;

        switch (qState)
        {
            case QuestState.Intro:
                break;
            case QuestState.Quest1Start:
                mainQuestPanel.SetActive (true);
                break;
            case QuestState.Quest1Fin:
                break;
            case QuestState.Quest2Start:
                questPanel.SetActive (true);
                break;
            case QuestState.Quest2Fin:
                questPanel.SetActive(false);
                break;
            case QuestState.Quest3Start:
                questPanel.SetActive(true);
                break;
            case QuestState.Quest3Fin:
                questPanel.SetActive(false);
                break;
            case QuestState.Quest4Start:
                questPanel.SetActive(true);
                break;
            case QuestState.Quest4Fin:
                questPanel.SetActive(false);
                break;
            case QuestState.Quest5Start:
                questPanel.SetActive(true);
                break;
            case QuestState.Quest5Fin:
                questPanel.SetActive(false);
                mainQuestPanel.SetActive(false);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(qState), qState, null);
        }

        OnQuestChange?.Invoke(qState);

    }


    public enum QuestState
    {
        Intro,
        Quest1Start,
        Quest1Fin,
        Quest2Start,
        Quest2Fin,
        Quest3Start,
        Quest3Fin,
        Quest4Start,
        Quest4Fin,
        Quest5Start,
        Quest5Fin,
    }







}
