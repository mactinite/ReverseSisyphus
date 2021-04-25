using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public string GoalTag = "Goal";
    [Scene]
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GoalTag))
        {
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

    }

}
