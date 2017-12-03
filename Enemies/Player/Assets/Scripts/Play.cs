using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Play : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

	public void LoadDemo()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressText.text = progress * 100 + "%";
            slider.value = progress;

            yield return null;
        }
    }
}
