using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{
    [Scene]
    public string FirstLevel;
    public void StartGame()
    {
        SceneManager.LoadScene(FirstLevel, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
