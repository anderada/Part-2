using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneController : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene(3);
    }

    public void SixteenByNine(){
        Screen.SetResolution(1280, 720, false);
        Debug.Log("16:9");
    }

    public void FullHD(){
        Screen.SetResolution(1920, 1080, false);
        Debug.Log("Full HD");
    }
}
