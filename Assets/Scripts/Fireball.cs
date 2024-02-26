using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;


    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }



    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);
        DestroyFireball();
    }


    public void DestroyFireball()
    {
        Destroy(gameObject);
    }


    public void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }


    public void DamageEnemy(Collision collision)
    {
        var EnemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (EnemyHealth != null)
        {
            EnemyHealth.DealDamage(damage);
        }
    }

}
