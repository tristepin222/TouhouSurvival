using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Edgar.Unity;
using Pathfinding;
public class SizeChangerPostProcess : DungeonGeneratorPostProcessingComponentGrid2D
{
    [SerializeField] Vector3 size;
    [SerializeField] AstarPath astarPath;
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        AstarPath.active.Scan();
    }
}
