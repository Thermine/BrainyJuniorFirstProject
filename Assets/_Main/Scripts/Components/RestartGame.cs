using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;


    public void LoadOtherScene()
    {
        SceneManager.LoadScene(_sceneNumber, LoadSceneMode.Single);
    }
}
