using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void NextScene(int changeSceneTo)
    {
        SceneManager.LoadScene(changeSceneTo);
    }

}
