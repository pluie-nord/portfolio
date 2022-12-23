using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadExample : MonoBehaviour
{
  [ContextMenu("Save")]
  public void Save(string SaveNum)
  {
    string SavePath = Application.persistentDataPath + "/" + SaveNum + ".txt";
    Dictionary<string, object> state = new Dictionary<string, object>();
    this.CaptureState(state);
    this.SaveFile((object) state, SavePath, SaveNum);
  }

  [ContextMenu("Load")]
  public void Load(string SaveNum) => this.StartCoroutine(this.LoadDelay(Application.persistentDataPath + "/" + SaveNum + ".txt"));

  private IEnumerator LoadDelay(string SavePath)
  {
    yield return (object) new WaitForSeconds(3f);
    this.RestorState(this.LoadFile(SavePath));
    pauseManager.IsInMenu = false;
  }

  private Dictionary<string, object> LoadFile(string SavePath)
  {
    if (!File.Exists(SavePath))
      return new Dictionary<string, object>();
    using (FileStream serializationStream = File.Open(SavePath, FileMode.Open))
      return (Dictionary<string, object>) new BinaryFormatter().Deserialize((Stream) serializationStream);
  }

  private void SaveFile(object state, string SavePath, string SaveNum)
  {
    using (FileStream serializationStream = File.Open(SavePath, FileMode.Create))
      new BinaryFormatter().Serialize((Stream) serializationStream, state);
    Object.FindObjectOfType<SaveSlotText>().SetSaveData(SaveNum);
  }

  private void CaptureState(Dictionary<string, object> state)
  {
    foreach (SaveableEntity saveableEntity in Object.FindObjectsOfType<SaveableEntity>())
      state[saveableEntity.Id] = saveableEntity.CaptureState();
  }

  private void RestorState(Dictionary<string, object> state)
  {
    foreach (SaveableEntity saveableEntity in Object.FindObjectsOfType<SaveableEntity>())
    {
      object state1;
      if (state.TryGetValue(saveableEntity.Id, out state1))
        saveableEntity.RestoreState(state1);
    }
  }
}