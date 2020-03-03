using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    public void LoadMenu(float delay)
    {
        StartCoroutine(LoadAfterDelay("Menu", delay, false));
    }

    public void StartGame(float delay)
    {
        StartCoroutine(LoadAfterDelay("Level_1", delay, true));
    }

    public void LoadLevel(int level, float delay)
    {
        StartCoroutine(LoadAfterDelay("Level_" + level, delay, true));
    }

    public void LoadGameOver(float delay)
    {
        StartCoroutine(LoadAfterDelay("Game Over", delay, false));
    }

    private IEnumerator LoadAfterDelay(string scene, float delay, bool reset)
    {
        yield return new WaitForSeconds(delay);
        if (reset) {
            GameSession.Reset();
        }
        SceneManager.LoadScene(scene);
    }
}
