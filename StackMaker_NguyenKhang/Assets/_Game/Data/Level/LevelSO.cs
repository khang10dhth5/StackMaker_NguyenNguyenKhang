using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/Level")]
public class LevelSO : ScriptableObject
{
    public List<LevelItem> listLevelItem;
}
