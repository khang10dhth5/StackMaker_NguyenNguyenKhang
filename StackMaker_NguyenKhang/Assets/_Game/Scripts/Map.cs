using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform startPoint;

    private void Start()
    {
        Player player = Instantiate(playerPrefab, startPoint.position, Quaternion.identity);
        CameraFollow.Ins.target = player.transform;
        UIManager.Ins.pnlLevel.SetActive(false);
    }

}
