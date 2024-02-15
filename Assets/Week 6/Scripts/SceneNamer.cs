using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SceneNamer : MonoBehaviour
{
    public TextMeshProUGUI sceneNameText;

    void Start()
    {
        sceneNameText.text = SceneManager.GetActiveScene().name;
    }
}
