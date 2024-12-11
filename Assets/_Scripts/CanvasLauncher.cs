using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLauncher : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image blackBackgroundImagePrefab;

    void Start()
    {
        Instantiate(blackBackgroundImagePrefab, transform);
    }
}