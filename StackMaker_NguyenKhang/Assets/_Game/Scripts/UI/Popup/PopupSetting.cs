using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : MonoBehaviour
{
    [SerializeField] private Button btnCloseSetting;

    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnCloseSetting.onClick.AddListener(() => {
            UIManager.Ins.pnlSetting.SetActive(false);
        });
        
    }
}
