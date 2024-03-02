using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderUIManager : Singleton<HeaderUIManager>
{
    public Text txtLevelName;
    public Text txtCoin;
    public Button btnPauseGame;

    [SerializeField] private Button btnSetting;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInit()
    {
        btnPauseGame.gameObject.SetActive(false);
        btnSetting.onClick.AddListener(()=> {
            SettingGame();
        });
        btnPauseGame.onClick.AddListener(()=> {
            Time.timeScale = 0;
            PopUpManager.Ins.pnlPauseGame.SetActive(true);
        });
        txtCoin.text = PlayerPrefs.GetInt(KeyConstant.KEY_COIN).ToString();
    }

    private void SettingGame()
    {
        UIManager.Ins.pnlSetting.SetActive(true);
    }
}
