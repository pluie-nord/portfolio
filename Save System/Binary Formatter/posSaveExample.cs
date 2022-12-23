using SAP2D;
using System;
using UnityEngine;

public class posSaveExample : MonoBehaviour, ISaveable
{
  [SerializeField]
  private float posX;
  [SerializeField]
  private float posY;
  [SerializeField]
  private float posZ;
  [SerializeField]
  private bool SAPCanMove;
  [SerializeField]
  private int SAPDirNum;

  public object CaptureState()
  {
    if (this.name == "Jared")
      MonoBehaviour.print((object) this.name);
    return (object) new posSaveExample.SaveData()
    {
      posX = this.posX,
      posY = this.posY,
      posZ = this.posZ,
      SAPCanMove = this.SAPCanMove,
      SAPDirNum = this.SAPDirNum
    };
  }

  public void RestoreState(object state)
  {
    posSaveExample.SaveData saveData = (posSaveExample.SaveData) state;
    this.posX = saveData.posX;
    this.posY = saveData.posY;
    this.posZ = saveData.posZ;
    this.SAPCanMove = saveData.SAPCanMove;
    this.SAPDirNum = saveData.SAPDirNum;
    if ((UnityEngine.Object) UnityEngine.Object.FindObjectOfType<sapDirsSave>().getDir(this.SAPDirNum) == (UnityEngine.Object) null)
      this.SAPCanMove = false;
    this.GetComponent<Transform>().position = new Vector3(this.posX, this.posY, this.posZ);
    this.GetComponent<SAP2DAgent>().CanMove = this.SAPCanMove;
    this.GetComponent<SAP2DAgent>().Target = UnityEngine.Object.FindObjectOfType<sapDirsSave>().getDir(this.SAPDirNum);
  }

  private void FixedUpdate()
  {
    this.posX = this.GetComponent<Transform>().position.x;
    this.posY = this.GetComponent<Transform>().position.y;
    this.posZ = this.GetComponent<Transform>().position.z;
    this.SAPCanMove = this.GetComponent<SAP2DAgent>().CanMove;
    this.SAPDirNum = UnityEngine.Object.FindObjectOfType<sapDirsSave>().getDirNum(this.GetComponent<SAP2DAgent>().Target);
  }

  [Serializable]
  private struct SaveData
  {
    public float posX;
    public float posY;
    public float posZ;
    public bool SAPCanMove;
    public int SAPDirNum;
  }
}
