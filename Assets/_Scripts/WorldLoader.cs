using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldLoader : MonoBehaviour
{
    public static WorldLoader Instance { get; private set; }
    [SerializeField] private Camera cameraPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCameraPrefab;
    [SerializeField] private PlayerMovement playerMovementPrefab;
    [field: SerializeField] public SceneReference UIScene { get; private set; }
    [field: SerializeField] public SceneReference GameplayScene { get; private set; }

    private void Start()
    {
        Instance = this;
        SceneManager.LoadSceneAsync(UIScene.Name, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(GameplayScene.Name, LoadSceneMode.Additive)!.completed +=
            OnCompletedLoadGameplayScene;
    }

    private void OnCompletedLoadGameplayScene(AsyncOperation obj)
    {
        Instantiate(cameraPrefab);
        CinemachineVirtualCamera virtualCameraObject = Instantiate(virtualCameraPrefab);

        PlayerMovement playerObject = Instantiate(playerMovementPrefab);
        SceneManager.MoveGameObjectToScene(playerObject.gameObject, GameplayScene.LoadedScene);

        virtualCameraObject.Follow = playerObject.transform;
    }
}