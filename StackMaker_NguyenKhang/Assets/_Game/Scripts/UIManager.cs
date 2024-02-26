using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject pnlLevel;

    [SerializeField] private Button btnPlay;
    [SerializeField] private GameObject pnlMainMenu;
    
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnPlay.onClick.AddListener(() => {
            pnlLevel.SetActive(true);
            pnlMainMenu.SetActive(false);
        });
        pnlLevel.SetActive(false);
        pnlMainMenu.SetActive(true);

    }
}
