using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float damage = 5;
    private float timer;
  
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");


        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().AddDamage(damage);
            Destroy(gameObject);
        }
    }
}
