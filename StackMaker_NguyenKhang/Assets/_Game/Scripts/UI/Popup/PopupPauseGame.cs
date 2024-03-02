using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPauseGame : MonoBehaviour
{
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnQuit;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnClose.onClick.AddListener(()=> {
            ClosePanelPauseGame();
        });

        btnResume.onClick.AddListener(() => {
            ClosePanelPauseGame();
        });
        btnRetry.onClick.AddListener(() => {
            ClosePanelPauseGame();
            GameManager.Ins.RetryGame();
        });
        btnQuit.onClick.AddListener(() => {
            ClosePanelPauseGame();
            QuitGame();
        });

    }

    private void QuitGame()
    {
        GameManager.Ins.DestroyCurrentMap();
        UIManager.Ins.pnlLevel.SetActive(true);
        HeaderUIManager.Ins.btnPauseGame.gameObject.SetActive(false);
    }
    private void ClosePanelPauseGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
