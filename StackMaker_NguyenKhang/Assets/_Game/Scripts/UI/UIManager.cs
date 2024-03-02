using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject pnlLevel;
    public GameObject pnlMainMenu;
    public GameObject pnlSetting;

      
    [HideInInspector] public Map currentMap;
    [HideInInspector] public int indexCurrentMap;
    [HideInInspector] public int countLevel;

    [SerializeField] private Button btnPlay;

    private int coin;
    private void Start()
    {
        OnInit();
    }

    public void SaveCoin(int coin)
    {
        this.coin += coin;
        PlayerPrefs.SetInt(KeyConstant.KEY_COIN, this.coin);
        HeaderUIManager.Ins.txtCoin.text = this.coin.ToString();
    }
    public void SpawnMap(int index)
    {
        GameManager.Ins.gameState = GameState.StartGame;
        Map mapPrefab = Resources.Load<Map>($"{PathConstant.MAP_PATH}{index}");
        currentMap = Instantiate(mapPrefab);
        HeaderUIManager.Ins.txtLevelName.text = "Level " + index;
    }

    public void NextLevel()
    {
        if(indexCurrentMap+1>countLevel)
        {
            return;
        }
        else
        {
            indexCurrentMap++;
            DestroyCurrentMap();
            SpawnMap(indexCurrentMap);
            HeaderUIManager.Ins.txtLevelName.text = "Level " + indexCurrentMap;
            PopUpManager.Ins.pnlReward.gameObject.SetActive(false);
        }

    }
    public void RetryGame()
    {
        DestroyCurrentMap();
        SpawnMap(indexCurrentMap);
        HeaderUIManager.Ins.txtLevelName.text = "Level " + indexCurrentMap;
    }
    public void DestroyCurrentMap()
    {
        if (!currentMap)
        {
            return;
        }
        Destroy(currentMap.gameObject);
        Destroy(Player.Ins.gameObject, 0.2f);
    }

    private void OnInit()
    {
        btnPlay.onClick.AddListener(() => {
            pnlLevel.SetActive(true);
            pnlMainMenu.SetActive(false);
        });
        pnlLevel.SetActive(false);
        pnlMainMenu.SetActive(true);
        if(!PlayerPrefs.HasKey(KeyConstant.KEY_COIN))
        {
            PlayerPrefs.SetInt(KeyConstant.KEY_COIN,coin);
        }
        else
        {
            coin = PlayerPrefs.GetInt(KeyConstant.KEY_COIN);
        }
    }


}
