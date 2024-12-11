using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    public static int isLandSize = 30;
    [SerializeField] List<Island> islandPrefabs = new();

    private void Start()
    {
        foreach (Island islandPrefab in islandPrefabs)
        {
            Island island = Instantiate(islandPrefab,
                new Vector3(islandPrefab.islandSO.position.x * isLandSize,
                    islandPrefab.islandSO.position.y * isLandSize),
                Quaternion.identity);
            SceneManager.MoveGameObjectToScene(island.gameObject, WorldLoader.Instance.GameplayScene.LoadedScene);
        }
    }
}