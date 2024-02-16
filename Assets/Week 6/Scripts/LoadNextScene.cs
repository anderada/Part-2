using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void loadNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int newSceneIndex = currentSceneIndex + 1;
        newSceneIndex %= SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(newSceneIndex);
    } 

    public void loadSceneIndex(int index){
        SceneManager.LoadScene(index);
    }
}
