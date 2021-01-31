using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void DoRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
