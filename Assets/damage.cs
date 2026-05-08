using UnityEngine;

public class damage : MonoBehaviour
{
    public float Damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        collision.GetComponent<PlayerHealth>().AddDamage(Damage);
    }
}
