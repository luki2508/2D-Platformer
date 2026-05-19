using UnityEngine;
using UnityEngine.SceneManagement;

public class KillSpike : MonoBehaviour
{
    public float damage = 25;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerHealth>().AddDamage(damage);
    }
}
