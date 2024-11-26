using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<PlayerController>().transform;
        target = PlayerHealthController.instance.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;

        if (hitCounter > 0f)
            hitCounter -= Time.deltaTime;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // The other game object that we collided to is have tag: "Player"
        if(collision.gameObject.tag == "Player" && hitCounter <= 0)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }

}
