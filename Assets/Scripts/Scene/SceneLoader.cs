using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Update()
    {
        if (SceneCubesInfo.Instance.Distance < 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
