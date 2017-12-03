using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    bool loading = false;

    #region Play Button
    [Header("Play Button references")]
    public GameObject loadingScreen;
    public Text progressText;

    public void PlayGame()
    {
        if (loading == false)
            LoadFirstScene();
    }

    void LoadFirstScene()
    {
        loading = true;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(.3f);
        // Creates an operation so we can get information about the loading.
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        if (operation != null)
        {
            // While it's not done loading...
            while (!operation.isDone)
            {
                // Clamps the loading between a value of 0 and 1.
                float progress = Mathf.Clamp01(operation.progress / .9f);
                progressText.text = progress * 100 + "%"; // Turns it into a percentage by multiplying by 100.

                yield return null; // Not sure why, but it is required.

            }
        } else
        {
            Debug.Log("Scene does not exist.");
        }
    }
    #endregion

    #region Show credits Button
    [Header("Credits panel")]
    public GameObject creditsPanel;

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }
    #endregion

    #region Quit Button
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Hide Credits button
    [Header("Hide Credits references")]
    [SerializeField]
    Animator animator;

    public void HideCredits()
    {
        StartCoroutine(hideCr());
    }

    IEnumerator hideCr()
    {
        animator.SetTrigger("HideCredits");
        yield return new WaitForSeconds(.3f);
        creditsPanel.SetActive(false);
    }

    #endregion
}
