using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/IslandSO")]
public class IslandSO : ScriptableObject
{
    [field: SerializeField] public Vector2Int position { get; private set; }
}