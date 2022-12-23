using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
  [SerializeField]
  private string id = string.Empty;

  public string Id => this.id;

  [ContextMenu("Generate Id")]
  private void GenerateId() => this.id = Guid.NewGuid().ToString();

  public object CaptureState()
  {
    Dictionary<string, object> dictionary = new Dictionary<string, object>();
    foreach (ISaveable component in this.GetComponents<ISaveable>())
      dictionary[component.GetType().ToString()] = component.CaptureState();
    return (object) dictionary;
  }

  public void RestoreState(object state)
  {
    Dictionary<string, object> dictionary = (Dictionary<string, object>) state;
    foreach (ISaveable component in this.GetComponents<ISaveable>())
    {
      string key = component.GetType().ToString();
      object state1;
      if (dictionary.TryGetValue(key, out state1))
        component.RestoreState(state1);
    }
  }
}
