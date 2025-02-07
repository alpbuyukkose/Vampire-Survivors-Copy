using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float throwPower;
    public Rigidbody2D rb;
    public float rotateSpeed;

    private void Start()
    {
        rb.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(rb.velocity.x)));
    }
}
