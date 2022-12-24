using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoQuest : Quest
{
    public void SetQuest()
    {
        QuestName = "������ � ���";
        Description = "������� ��� ����� ������� ���������� �� �������. �������-�����, � ������ ���������. �� �� �� ������� ������������ �������?";
        ItemReward = null;
        Goals.Add(new DrawGoal(this, 1, "���������� 1 ����", false, 0, 1));
        Goals.ForEach(g => g.Init());
        print("Quest setted");
    }

    
}
