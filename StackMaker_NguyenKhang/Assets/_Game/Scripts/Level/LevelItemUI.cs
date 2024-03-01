using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    public int reward;

    [SerializeField] private Text txtLevelName;
    [SerializeField] private Image imgLevel;
    [SerializeField] private Button btnOnclick;

    public void SetLevelItemUI(LevelItem levelItem, Action<int,int> Onclick)
    {
        reward = levelItem.reward;
        txtLevelName.text = levelItem.levelIndex.ToString();
        imgLevel.sprite = levelItem.levelImage;
        btnOnclick.onClick.AddListener(()=>{
            Onclick.Invoke(levelItem.levelIndex,reward);
        });
    }
}
[Serializable]
public class LevelItem
{
    public int levelIndex;
    public Sprite levelImage;
    public int reward;
}
