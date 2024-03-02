using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : Singleton<PopUpManager>
{
    public GameObject pnlSetting;
    public GameObject pnlPauseGame;
    public PopupReward pnlReward;

    [HideInInspector] public List<int> listReward;
    private void Start()
    {
        OnInit();
    }


    public void ShowPopUpReward()
    {
        pnlReward.setTextReward(listReward[GameManager.Ins.indexCurrentMap-1].ToString());
        pnlReward.gameObject.SetActive(true);
    }
    private void OnInit()
    {
        pnlReward.OnInit(OnNextLevel);
    }


    private void OnNextLevel()
    {
        GameManager.Ins.NextLevel();
    }
}
