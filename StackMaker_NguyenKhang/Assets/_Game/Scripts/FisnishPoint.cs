using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisnishPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftFirework;
    [SerializeField] private ParticleSystem rightFirework;
    [SerializeField] private GameObject closeCoffer;
    [SerializeField] private GameObject openCoffer;

    private void Start()
    {
        Onit();
    }
    private void Onit()
    {
        closeCoffer.SetActive(true);
        openCoffer.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(GameTag.Player.ToString()))
        {
            Player.Ins.ClearBrick();
            leftFirework.Play();
            rightFirework.Play();
            closeCoffer.SetActive(false);
            openCoffer.SetActive(true);
            Invoke("EndGame", 1f);
            Player.Ins.EndGame();
        }

    }
    private void EndGame()
    {
        GameManager.Ins.EndGame();
        PopUpManager.Ins.ShowPopUpReward();
        UIManager.Ins.SaveCoin(PopUpManager.Ins.listReward[UIManager.Ins.indexCurrentMap - 1]);
    }
}
