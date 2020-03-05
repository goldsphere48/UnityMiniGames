using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string _sceneName = null;
    public SceneSwitcher Instance => _instance;

    private SceneSwitcher _instance;

    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OpenScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
