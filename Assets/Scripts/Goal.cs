using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class Goal : MonoBehaviour
{
    public string GoalTag = "Goal";
    [Scene]
    public string nextScene;
    public UnityEvent OnGoalReached = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GoalTag))
        {
            StartCoroutine(GoalReached(other.transform, 0.5f));
        }
    }

    public IEnumerator GoalReached(Transform goalObject, float duration)
    {
        yield return new WaitForSeconds(0.25f);
        float t = 0.0f;
        Vector3 start = goalObject.localScale;
        OnGoalReached.Invoke();
        while (t < duration)
        {
            t += Time.deltaTime;
            goalObject.localScale = Vector3.Lerp(start, Vector3.zero, t / duration);
            yield return null;
        }
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);

    }

}
