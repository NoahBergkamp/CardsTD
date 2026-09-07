using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public float speed = 20f;
    public bool shooting;
    private float AttackDuration = 0.333f;
    Rigidbody2D rb;



    void Start()
    {
        shooting = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shooting == true)
        {
            shootBullet();
        }
        else
        {
            Destroy(gameObject);
        }


    }
    void shootBullet()
    {
        
        rb.linearVelocity = transform.up * speed;

        AttackDuration -= Time.deltaTime;
        if (AttackDuration < 0 )
        {
            shooting = false;
        }
    }
}
