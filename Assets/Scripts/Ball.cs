using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Vitesse initiale de la balle
    public float EjectorSpeed = 2f; //vitesse d'ejection de l'ejector

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Appliquer une force initiale à la balle pour la faire bouger
        //rb.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Flipper"))
        {
            // Si la balle touche un mur ou une palette, inversez sa direction verticale
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflectedVelocity;
        }
        else if (collision.gameObject.CompareTag("Ejector"))
        {
            // Si la balle touche un cercle d'éjection, lui donner une force d'éjection
            rb.velocity = (transform.position - collision.transform.position).normalized * speed * EjectorSpeed;
        }
        else if (collision.gameObject.CompareTag("Target"))
        {
            // Si la balle touche une cible, détruisez la cible
            Destroy(collision.gameObject);
        }
    }
}
