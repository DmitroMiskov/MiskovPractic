using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MenuUI : MonoBehaviour
{
    private const string sceneGame = "SampleScene";

    [Header("Atributos anexos Inspector")]
    [SerializeField] private Button btnPlay;


    void Awake()
    {
        btnPlay.onClick.AddListener(() => OnButtonPlayClick());
    }
    void PlayGame()
    {
        SceneManager.LoadScene(sceneGame);
    }

    void OnDisable()
    {
        btnPlay.onClick.RemoveAllListeners();
    }

    void OnButtonPlayClick()
    {
        PlayGame();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
