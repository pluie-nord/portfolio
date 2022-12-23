using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
  [SerializeField]
  private Image progressBar;

  private void Start() => this.StartCoroutine(this.LoadAsyncOperation());

  private IEnumerator LoadAsyncOperation()
  {
    AsyncOperation gameLevel = SceneManager.LoadSceneAsync(SceneManagers.currentSceneIndex);
    while ((double) gameLevel.progress < 1.0)
    {
      this.progressBar.fillAmount = gameLevel.progress;
      yield return (object) new WaitForSeconds(1f);
    }
  }
}