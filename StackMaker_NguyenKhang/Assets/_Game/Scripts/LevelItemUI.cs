using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    [SerializeField] private Text txtLevelName;
    [SerializeField] private Image imgLevel;
    [SerializeField] private Button btnOnclick;

    public void SetLevelItemUI(LevelItem levelItem, Action<string> Onclick)
    {
        txtLevelName.text = levelItem.levelIndex.ToString();
        imgLevel.sprite = levelItem.levelImage;
        btnOnclick.onClick.AddListener(()=>{
            Onclick.Invoke(txtLevelName.text);
        });
    }
}
[Serializable]
public class LevelItem
{
    public int levelIndex;
    public Sprite levelImage;
}
