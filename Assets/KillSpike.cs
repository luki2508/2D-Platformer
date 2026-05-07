using UnityEngine;
using UnityEngine.SceneManagement;

public class KillSpike : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
