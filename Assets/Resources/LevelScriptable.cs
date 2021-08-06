using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects")]
public class LevelScriptable : ScriptableObject
{
    public int grid_width;
    public int grid_height;
    public int level_num;
    public int move_count;
    public ColorType[] colors;

}

