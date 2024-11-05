using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [Header("Atributos anexos Inspector")]
    [SerializeField] Button btnBackMenu;

    private const string sceneMenu = "Menu";

    private void Awake()
    {
        btnBackMenu.onClick.AddListener(OnButtonBackMenuClick);
    }
    private void OnButtonBackMenuClick()
    {
        SceneManager.LoadScene(sceneMenu);
    }
}
