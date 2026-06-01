using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneName);
    }

}
