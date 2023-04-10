using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour
{

    AsyncOperation AsyncOperation;
    public AudioSource Dzin;

    public void AsyncLoading(int SceneIndex)
    {
        StartCoroutine(Async(SceneIndex));
        
    }

    IEnumerator Async(int SceneIndex)
    {        
        this.AsyncOperation = SceneManager.LoadSceneAsync(SceneIndex);
        this.AsyncOperation.allowSceneActivation = false;

        while (this.AsyncOperation.isDone)
        {
            continue;
        }
        Dzin.Play();
        yield return new WaitForSeconds(Dzin.clip.length);
        AsyncOperation.allowSceneActivation = true;
    }
}
