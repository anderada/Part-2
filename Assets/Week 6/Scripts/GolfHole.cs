using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolfHole : MonoBehaviour
{
    public void OnTriggerEnter2D(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int newSceneIndex = currentSceneIndex + 1;
        newSceneIndex %= SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(newSceneIndex);
    } 
}
