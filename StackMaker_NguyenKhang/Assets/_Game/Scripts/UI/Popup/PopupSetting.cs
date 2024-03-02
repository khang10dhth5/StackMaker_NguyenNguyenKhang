using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : MonoBehaviour
{
    [SerializeField] private Button btnCloseSetting;
    [SerializeField] private Button btnSound;
    [SerializeField] private Sprite sound;
    [SerializeField] private Sprite unsound;
    private bool isSound;
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnCloseSetting.onClick.AddListener(() => {
            UIManager.Ins.pnlSetting.SetActive(false);
        });
        btnSound.onClick.AddListener(() => {
            SetSound();
        });
    }

    private void SetSound()
    {
        if(isSound)
        {
            btnSound.image.sprite = unsound;
            isSound = false;
        }
        else
        {
            btnSound.image.sprite = sound;
            isSound = true;
        }
    }
}
