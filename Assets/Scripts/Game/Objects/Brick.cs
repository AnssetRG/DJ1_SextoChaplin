using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioSource audioSource;
    public float health = 70f;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>() == null)
        {
            return;
        }

        float damage = other.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10.0f;
        if (damage > 10)
        {
            audioSource.Play();
        }

        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
