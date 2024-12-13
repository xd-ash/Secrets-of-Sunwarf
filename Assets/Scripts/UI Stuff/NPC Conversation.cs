using UnityEngine;
using XNode;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEditor;
using static GameManager;

public class NPCConversation : MonoBehaviour
{
    [SerializeField] private DialogueGraph dialogue;
    public Text spokenLineText;
    public Transform responseButtonPanel;
    public GameObject buttonPrefab;
    public GameObject canvas;
    public GameManager gameManager;
    [SerializeField] private GameManager.QuestState qState;
    public GameObject questUnlockedItem;
    public GameObject managerHolder;

    private void Awake()
    {
        managerHolder = GameObject.FindGameObjectWithTag("GameController");
        gameManager = managerHolder.GetComponentInParent<GameManager>();
        GameManager.OnQuestChange += OnQuestStateChange;
    }

    private void OnDestroy()
    {
        GameManager.OnQuestChange -= OnQuestStateChange;
    }
    void Start()
    {
        canvas.SetActive(false);
        
    }
    public void Interact()
    {
        canvas.SetActive(true);
        foreach (Node item in dialogue.nodes)
        {
            if(item is StartNode)
            {
                dialogue.current = item.GetPort("exit").Connection.node as DialogueNodeBase;
                break;
            }
        }
        ParseNode();

    }

    private void ParseNode()
    {
        if(dialogue.current == null || spokenLineText == null)
        {
            return;
        }

        switch(dialogue.current.GetDialogueType)
        {
            case "NPC" :
                spokenLineText.text = dialogue.current.dialogueSpoken;
                SpawnResponseButton();
                break;
            case "Response" :
                ClearAllResponseButtons();
                NextNode("exit");
                break;
            case "eNPC" :
                spokenLineText.text = dialogue.current.dialogueSpoken;
                SpawnResponseButton();
                canvas.SetActive(false);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
                break;
             case "qNPC" :
                spokenLineText.text = dialogue.current.dialogueSpoken;
                SpawnResponseButton();
                if (questUnlockedItem != null)
                {
                    questUnlockedItem.SetActive(true);
                }
                break;
            case "qeNPC":
                spokenLineText.text = dialogue.current.dialogueSpoken;
                SpawnResponseButton();
                canvas.SetActive(false);
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                UnityEngine.Cursor.visible = false;
                gameManager.UpdateQuestState(qState);
                break;
        }

    }

    public void NextNode (string fieldName)
    {
        foreach (NodePort port in dialogue.current.Ports)
        {
            if (port.fieldName == fieldName)
            {
                dialogue.current = port.Connection.node as DialogueNodeBase;
                break;
            }
        }

        ParseNode();
    }

    private void SpawnResponseButton()
    {
        foreach (NodePort port in dialogue.current.Ports)
        {
            if(port.Connection == null || port.IsInput)
            {
                continue;
            }
               
            if(port.Connection.node is ResponseDialogue)
            {
                ResponseDialogue rd = port.Connection.node as ResponseDialogue;

                Button b = Instantiate(buttonPrefab, responseButtonPanel).GetComponent<Button>();
                b.onClick.AddListener(() => NextNode(port.fieldName));
                b.GetComponentInChildren<Text>().text = rd.dialogueSpoken;
            }    
            
        }
    }

    private void ClearAllResponseButtons()
    {
        Transform[] children = responseButtonPanel.GetComponentsInChildren<Transform>();
        for(int i = children.Length -1; i > 0; i--)
        {
            if(children[i] != responseButtonPanel)
            {
                Destroy(children[i].gameObject);
            }
        }

    }

    public DialogueGraph dialogue1;
    public DialogueGraph dialogue2;
    public DialogueGraph dialogue3;
    public DialogueGraph dialogue4;
    public DialogueGraph dialogue5;
    public DialogueGraph dialogue6;
    public DialogueGraph dialogue7;
    public DialogueGraph dialogue8;
    public DialogueGraph dialogue9;
    public bool questStart1 = false;
    public bool questStart2 = false;
    public bool questStart3 = false;
    public bool questStart4 = false;
    public bool questStart5 = false;
    private GameManager.QuestState qState1 = GameManager.QuestState.Quest1Start; //Head Guard
    private GameManager.QuestState qState2 = GameManager.QuestState.Quest2Start; //Merchant1
    private GameManager.QuestState qState3 = GameManager.QuestState.Quest3Start; //Merchant2
    private GameManager.QuestState qState4 = GameManager.QuestState.Quest4Start; //Merchant3
    private GameManager.QuestState qState5 = GameManager.QuestState.Quest5Start; //Evil Dude


    private void OnQuestStateChange(QuestState state)
    {
        if (state == GameManager.QuestState.Intro)
        {
            if (dialogue1 != null)
            {
                dialogue = dialogue1;
            }

            if (questStart1)
            {
                qState = qState1;
            }
        }
        if (state == GameManager.QuestState.Quest1Start)
        {
            if (dialogue2 != null)
            {
                dialogue = dialogue2;
            }

        }
        if (state == GameManager.QuestState.Quest1Fin)
        {
            if (dialogue3 != null)
            { 
                dialogue = dialogue3;
            }
            if (questStart2)
            {
                qState = qState2;
            }

        }
        if (state == GameManager.QuestState.Quest2Start)
        {
            if (dialogue4 != null)
            {
                dialogue = dialogue4;
            }
        }
        if (state == GameManager.QuestState.Quest2Fin)
        {
            if (dialogue5 != null)
            {
                dialogue = dialogue5;
            }
            if (questStart3)
            {
                qState = qState3;
            }
        }
        if (state == GameManager.QuestState.Quest3Start)
        {
            if (dialogue6 != null)
            {
                dialogue = dialogue6;
            }
        }
        if (state == GameManager.QuestState.Quest3Fin)
        {
            if (dialogue7 != null)
            {
                dialogue = dialogue7;
            }
            if (questStart4)
            {
                qState = qState4;
            }
        }
        if (state == GameManager.QuestState.Quest4Start)
        {
            if (dialogue7 != null)
            {
                dialogue = dialogue7;
            }
        }
        if (state == GameManager.QuestState.Quest4Fin)
        {
            if (dialogue8 != null)
            {
                dialogue = dialogue8;
            }
            if (questStart5)
            {
                qState = qState5;
            }
        }
        if (state == GameManager.QuestState.Quest5Start)
        {
            if (dialogue9 != null)
            {
                dialogue = dialogue9;
            }
        }
    }


}
