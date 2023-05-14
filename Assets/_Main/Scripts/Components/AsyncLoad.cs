using djastas;
using System.Collections;
using System.Collections.Generic;
using BrainyJunior.MyGame.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad: MonoBehaviour
{

    AsyncOperation AsyncOperation;
    public string DzinId;

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
        BackgroundMusicManager.Instance.PlayAudioById(DzinId);
        yield return new WaitForSeconds(2);
        AsyncOperation.allowSceneActivation = true;
    }
}
