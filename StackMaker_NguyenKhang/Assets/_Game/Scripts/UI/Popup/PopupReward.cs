using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupReward : MonoBehaviour
{
    public Text txtReward;

    [HideInInspector] public string reward;

    [SerializeField] private Button btnNextLevel;
    [SerializeField] private Button btnRetry;

    private void OnEnable()
    {
        txtReward.text = reward;
    }

    public void setTextReward(string reward)
    {
        this.reward = reward;
    }
    public void OnInit(Action action)
    {
        btnNextLevel.onClick.AddListener(() => {
            action.Invoke();
        });
        btnRetry.onClick.AddListener(() =>
        {
            UIManager.Ins.RetryGame();
            gameObject.SetActive(false);
        });
    }
}
