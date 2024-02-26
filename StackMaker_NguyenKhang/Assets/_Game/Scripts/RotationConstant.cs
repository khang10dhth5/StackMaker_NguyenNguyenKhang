using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationConstant 
{
    public const int ROTATION_UP = 0;
    public const int ROTATION_DOWN = 180;
    public const int ROTATION_LEFT = -90;
    public const int ROTATION_RIGHT= 90;


}
public class RaycastConstant
{

    public static Vector3 RIGHT_RAYCAST = Vector3.right;
    public static Vector3 LEFT_RAYCAST = Vector3.left;
    public static Vector3 UP_RAYCAST = Vector3.forward;
    public static Vector3 DOWN_RAYCAST = new Vector3(0, 0, -1);

}

public class PathConstant
{
    public const string MAP_PATH = "Map/Map_";
}
public enum GameTag
{
    Brick,
    Player
}
public enum GameState
{
    StartGame,
    PlayGame
}
public enum BrickState
{
    New,
    Collected,
}