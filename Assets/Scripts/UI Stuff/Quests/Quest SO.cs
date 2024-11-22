using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName ="ScriptableObjects/Quests")]
public class QuestSO : ScriptableObject
{
    public string Title;

    public string Description;

    public string Goal;

}
