using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    private int nextScene = 1;
    //start at 0 (menu)
  public void SceneChange()
    {
        StartCoroutine(LoadMySceneAsync());
    }
    public IEnumerator LoadMySceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01((float)asyncLoad.progress/0.9f);
            LoadScreen.instance.loadScreen.SetActive(true);
            LoadScreen.instance.loadBar.value = progress;
            LoadScreen.instance.progressText.text = Mathf.Round(progress * 100f) + "%";
            yield return null;
        }
        yield return new WaitForSeconds(5f);
    }
}
