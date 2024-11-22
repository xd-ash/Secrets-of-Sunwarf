using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using static GameManager;

public class QuestPanel : MonoBehaviour
{
    [SerializeField] private QuestSO quest;
    public TMP_Text Title;
    public TMP_Text Description;
    public TMP_Text Goal;
    public bool mainQuest = false;
    private void Awake()
    {
        GameManager.OnQuestChange += OnQuestChange;
    }

    private void OnDestroy()
    {
        GameManager.OnQuestChange -= OnQuestChange;
    }

    private void Update()
    {
        Title.SetText(quest.Title);
        Description.SetText(quest.Description); 
        Goal.SetText(quest.Goal);
    }

    public QuestSO quest2;
    public QuestSO quest3;
    public QuestSO quest4;
    public QuestSO quest5;
    private void OnQuestChange(QuestState state)
    {
        if (!mainQuest)
        {
            if (state == QuestState.Quest2Start)
            {
                quest = quest2;
            }
            if (state == QuestState.Quest3Start)
            {
                quest = quest3;
            }
            if (state == QuestState.Quest4Start)
            {
                quest = quest4;
            }
            if (state == QuestState.Quest5Start)
            {
                quest = quest5;
            }
        }
    }
}
