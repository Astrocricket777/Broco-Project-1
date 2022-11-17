using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public GameObject LoadingScreen;

    public Slider slider;

    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    IEnumerator LoadAsynchronously (int SceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScreen.SetActive(true);

        while (!Operation.isDone)
        {
            float Progress = Mathf.Clamp01(Operation.progress / .9f);
            
            slider.value = Progress;

            yield return null;
        }
    }
}
