using System.Collections;
using UnityEngine;

public class menuUIFading : MonoBehaviour
{
  private float r;
  private float b;
  private float g;

  private void Awake()
  {
    this.r = this.GetComponent<SpriteRenderer>().color.r;
    this.b = this.GetComponent<SpriteRenderer>().color.b;
    this.g = this.GetComponent<SpriteRenderer>().color.g;
  }

  public void StartingFading()
  {
    this.GetComponent<SpriteRenderer>().color = new Color(this.r, this.g, this.b, 0.0f);
    this.StartCoroutine(this.StartingFading(0.0f));
  }

  private IEnumerator StartingFading(float alphaLevel)
  {
    menuUIFading menuUiFading = this;
    yield return (object) new WaitForSeconds(0.6f);
    while ((double) alphaLevel < 1.0)
    {
      menuUiFading.GetComponent<SpriteRenderer>().color = new Color(menuUiFading.r, menuUiFading.g, menuUiFading.b, alphaLevel);
      alphaLevel += 0.01f;
      yield return (object) null;
    }
  }

  public void EndingFading() => this.StartCoroutine(this.EndingFading(1f));

  private IEnumerator EndingFading(float alphaLevel)
  {
    menuUIFading menuUiFading = this;
    while ((double) alphaLevel > 0.0)
    {
      menuUiFading.GetComponent<SpriteRenderer>().color = new Color(menuUiFading.r, menuUiFading.g, menuUiFading.b, alphaLevel);
      alphaLevel -= 0.04f;
      yield return (object) null;
    }
  }
}