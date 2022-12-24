using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class DrawGoal : Goal
{
    public int ImageID { get; set; }

    //�����������
    public DrawGoal(Quest quest, int imageID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ImageID = imageID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        DrawEvent.OnPictureDrawn += DrawPicture;
    }

    void DrawPicture(IPicture picture)
    {
        if (picture.ID == this.ImageID)
        {
            Debug.Log("��������� ��������");
            CurrentAmount++;
            Evaluate();
        }
    }
}
