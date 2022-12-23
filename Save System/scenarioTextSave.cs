using System;
using UnityEngine;

public class scenarioTextSave : MonoBehaviour, ISaveable
{
  private string savedGetState;

  public object CaptureState() => (object) new scenarioTextSave.SaveData()
  {
    savedGetState = this.savedGetState
  };

  public void RestoreState(object state)
  {
    this.savedGetState = ((scenarioTextSave.SaveData) state).savedGetState;
    this.GetComponent<scenarioText>().firstState = UnityEngine.Object.FindObjectOfType<dialogueStateArr>().GetState(this.savedGetState);
  }

  private void Update() => this.savedGetState = this.GetComponent<scenarioText>().firstState.name;

  [Serializable]
  private struct SaveData
  {
    public string savedGetState;
  }
}
