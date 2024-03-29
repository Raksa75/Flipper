using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Vitesse initiale de la balle
    public float ejectorSpeed = 2f; // Vitesse d'�jection de l'�jecteur

    private Rigidbody2D rb;
    private bool isTouchingFlipper = false; // Indique si la balle est en contact avec les palettes

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Appliquer une force initiale � la balle pour la faire bouger
        // rb.velocity = Vector2.up * speed;
    }

    void Update()
    {
        if (isTouchingFlipper && Input.GetKey(KeyCode.Space))
        {
            // Si la touche espace est enfonc�e et que la balle est en contact avec les palettes,
            // appliquer une force d'�jection vers le haut
            rb.velocity += Vector2.up * speed * ejectorSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Flipper")) // Interaction avec le mur ou les palettes
        {
            // Si la balle touche un mur ou une palette, inversez sa direction verticale
            Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
            rb.velocity = reflectedVelocity;

            // Mettre � jour l'�tat de contact avec les palettes
            if (collision.gameObject.CompareTag("Flipper"))
            {
                isTouchingFlipper = true;
            }
        }
        else if (collision.gameObject.CompareTag("Ejector")) // Interaction avec l'�jecteur
        {
            // Si la balle touche un cercle d'�jection, lui donner une force d'�jection
            rb.velocity = (transform.position - collision.transform.position).normalized * speed * ejectorSpeed;
        }
        else if (collision.gameObject.CompareTag("Target")) // Interaction avec les cibles
        {
            // D�truire la cible
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flipper")) // Quand la balle quitte la zone des palettes
        {
            isTouchingFlipper = false;
        }
    }
}