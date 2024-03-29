using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Vitesse initiale de la balle
    public float ejectorSpeed = 2f; // Vitesse d'éjection de l'éjecteur

    public int ejectorPoints = 100; // Points gagnés en touchant un ejector
    public int targetPoints = 50; // Points gagnés en touchant une cible

    private Rigidbody2D rb;
    private bool isTouchingFlipper = false; // Indique si la balle est en contact avec les palettes

    // Score de la balle
    public int Score { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Appliquer une force initiale à la balle pour la faire bouger
        // rb.velocity = Vector2.up * speed;

        // Initialiser le score à zéro
        Score = 0;
    }

    void Update()
    {
        if (isTouchingFlipper && Input.GetKey(KeyCode.Space))
        {
            // Si la touche espace est enfoncée et que la balle est en contact avec les palettes,
            // appliquer une force d'éjection vers le haut
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

            // Mettre à jour l'état de contact avec les palettes
            if (collision.gameObject.CompareTag("Flipper"))
            {
                isTouchingFlipper = true;
            }
        }
        else if (collision.gameObject.CompareTag("Ejector")) // Interaction avec l'éjecteur
        {
            // Si la balle touche un cercle d'éjection, lui donner une force d'éjection
            rb.velocity = (transform.position - collision.transform.position).normalized * speed * ejectorSpeed;

            // Augmenter le score
            Score += ejectorPoints; // Ajouter les points d'ejector
        }
        else if (collision.gameObject.CompareTag("Target")) // Interaction avec les cibles
        {
            // Détruire la cible
            Destroy(collision.gameObject);

            // Augmenter le score
            Score += targetPoints; // Ajouter les points de cible
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
