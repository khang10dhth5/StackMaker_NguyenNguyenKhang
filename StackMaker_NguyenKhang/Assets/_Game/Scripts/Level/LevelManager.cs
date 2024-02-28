using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private LevelItemUI levelItemUIPrefab;
    [SerializeField] private Button btnBackMainMenu;
    [SerializeField] private LevelSO levelSO;

    private Map currentMap;
    private void OnEnable()
    {
        ClearGridLayoutGroup();
        for(int i=0;i<levelSO.listLevelItem.Count;i++)
        {
            LevelItemUI levelItemUI = Instantiate(levelItemUIPrefab, gridLayoutGroup);
            levelItemUI.SetLevelItemUI(levelSO.listLevelItem[i], OnLevelItemUIClickHandle);
        }
    }
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnBackMainMenu.onClick.AddListener(()=> {
            UIManager.Ins.pnlLevel.SetActive(false);
            UIManager.Ins.pnlMainMenu.SetActive(true);

        });
    }
    public void DestroyCurrentMap()
    {
        Destroy(currentMap);
    }
    private void OnLevelItemUIClickHandle(string index)
    {
        Map mapPrefab= Resources.Load<Map>($"{PathConstant.MAP_PATH}{index}");
        currentMap = Instantiate(mapPrefab);
    }


    private void ClearGridLayoutGroup()
    {
        foreach (Transform child in gridLayoutGroup)
        {
            Destroy(child.gameObject);
        }
    }
}
