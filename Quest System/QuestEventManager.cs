using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEventManager : MonoBehaviour
{
    [SerializeField] DioAgent[] dioAgents;

    [SerializeField] DialogueState[] triggerStates;

    public bool[] funcStatus = new bool[2] { false, false };

    private void Start()
    {
        QuestEvent.OnQuestCompleted += SetTriggeredState;
    }

    void SetTriggeredState(IQuest questID)
    {
        if(questID.ID<dioAgents.Length)
        {
            dioAgents[questID.ID].State = triggerStates[questID.ID];
            dioAgents[questID.ID].thisQuest = null;
            if(questID.ID==1)
            {
                funcStatus[0] = true;
            }
        }

    }

}
