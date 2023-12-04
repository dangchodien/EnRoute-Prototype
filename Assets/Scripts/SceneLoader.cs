using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change the scene. The sceneName parameter is the name of the scene you want to load.
    public void ChangeScene(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
}
