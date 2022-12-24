using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest_1 : Quest, IQuest
{
    public string questName;
    public string description;
    [SerializeField] InventoryItemData itemReward;
    public int rewardAmount = 1;
    public int[] itemID; 
    public string[] itemIDs; 
    public int goalsNumber;
    public string[] goalsDescription;
    public int[] itemsNumber;
    public int typeID; //1 - collect, 2 - draw, 3 - talk
    public int questID;

    public TutorialQuest_1 nextQuest;

    public int ID { get; set; }
    public void SetQuest()
    {
        ID = questID;

        CurrentQuest = this;
        NextQuest = nextQuest;
        QuestName = questName;
        Description = description;
        ItemReward = itemReward;
        ItemRewardAmount = rewardAmount;
        for (int i = 0; i < goalsNumber; i++)
        {
            switch (typeID)
            {
                case 1:
                    Goals.Add(new CollectGoal(this, itemID[i], goalsDescription[i], false, 0, itemsNumber[i]));
                    break;
                case 2:
                    Goals.Add(new DrawGoal(this, itemID[i], goalsDescription[i], false, 0, itemsNumber[i]));
                    break;
                case 3:
                    Goals.Add(new TalkGoal(this, itemIDs[i], goalsDescription[i], false, 0, itemsNumber[i]));
                    break;
                default:
                    break;
            }
        }

        Goals.ForEach(g => g.Init());
        FindObjectOfType<QuestsUIManager>().SetCurrentActiveQuest(questName, Description, goalsNumber, Goals, this);
    }
}
