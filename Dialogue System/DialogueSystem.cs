using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour, ITalk
{
    //������ �������, �������� ������� � ������ �������
    [SerializeField] DialogueState firstState;
    public DialogueState currentState;
    public bool ActiveDialogue;

    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] TextMeshProUGUI nameBox;
    [SerializeField] GameObject UIFolder;

    public TutorialQuest_1 QuestToSet;

    [SerializeField] private InventoryItemData[] startItem;
    public int[] startN;

    public string stateID { get; set; }

    private void StartInv(ITalk state)
    {
        if (state.stateID== "Tutorial_1_13") //��������, ���������
        {
            for(int i = 0; i<startItem.Length; i++)
            {
                for(int j = 0; j < startN[i]; j++)
                    FindObjectOfType<InventorySystem>().Add(startItem[i]);
            }

        }

    }

    void Start()
    {
        NewDialogue(firstState);
        TalkEvent.OnStateChanged+= StartInv;
    }

    //���������� ������ �� �����
    private void UpdateText()
    {
        textBox.text = currentState.Text;
        nameBox.text = currentState.Name;
    }

    public void NewDialogue(DialogueState newState)
    {
        ActiveDialogue = true;
        currentState = newState;
        UpdateText();
        UIFolder.SetActive(true);
        FindObjectOfType<Controller>().enabled = false;
    }

    void Update()
    {
        if(ActiveDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentState.NextState!=null) //�������� �� ��������� �������
                {
                    currentState=currentState.NextState;
                    UpdateText();
                }
                else
                {
                    stateID = currentState.name;
                    print(stateID);
                    TalkEvent.StateChanged(this);
                    UIFolder.SetActive(false);
                    ActiveDialogue = false;
                    FindObjectOfType<Controller>().enabled = true;
                    if (QuestToSet != null)
                    {
                        QuestToSet.SetQuest();
                    }
                }
            }
        }

    }
}
