using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private LevelSO levelSO;
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private LevelItemUI levelItemUIPrefab;
    [SerializeField] private Button btnBackMainMenu;

    private void OnEnable()
    {
        ClearGridLayoutGroup();
        PopUpManager.Ins.listReward.Clear();
        for(int i=0;i< levelSO.listLevelItem.Count; i++)
        {
            LevelItemUI levelItemUI = Instantiate(levelItemUIPrefab, gridLayoutGroup);
            levelItemUI.SetLevelItemUI(levelSO.listLevelItem[i], OnLevelItemUIClickHandle);
            PopUpManager.Ins.listReward.Add(levelSO.listLevelItem[i].reward);
        }
    }
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        UIManager.Ins.countLevel = levelSO.listLevelItem.Count;
        btnBackMainMenu.onClick.AddListener(()=> {
            UIManager.Ins.pnlLevel.SetActive(false);
            UIManager.Ins.pnlMainMenu.SetActive(true);

        });

    }
    
    private void OnLevelItemUIClickHandle(int index,int reward)
    {
        HeaderUIManager.Ins.btnPauseGame.gameObject.SetActive(true);
        UIManager.Ins.indexCurrentMap = index;
        UIManager.Ins.SpawnMap(UIManager.Ins.indexCurrentMap);
    }
  

    private void ClearGridLayoutGroup()
    {
        foreach (Transform child in gridLayoutGroup)
        {
            Destroy(child.gameObject);
        }
    }
}
