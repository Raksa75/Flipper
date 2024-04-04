using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Vitesse initiale de la balle
    public float ejectorSpeed = 2f; // Vitesse d'éjection de l'éjecteur
    public float flipperSpeed = 2f; //Vitesse d'éjection des palettes

    public int initialLives = 3; // Nombre de vies initial
    public Transform respawnPoint; // Point de réapparition de la balle
    public int ejectorPoints = 100; // Points gagnés en touchant un ejector
    public int targetPoints = 50; // Points gagnés en touchant une cible

    private Rigidbody2D rb;
    public Animator ejectorAnimator; //animation des ejector

    private bool isTouchingFlipper = false; // Indique si la balle est en contact avec les palettes
    public int lives; // Nombre de vies restantes

    // Score de la balle
    public int Score { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Appliquer une force initiale à la balle pour la faire bouger
        // rb.velocity = Vector2.up * speed;

        // Initialiser le score à zéro
        Score = 0;

        // Initialiser le nombre de vies
        lives = initialLives;
    }

    void FixedUpdate()
    {
        if (isTouchingFlipper && Input.GetKey(KeyCode.Space))
        {
            // Appliquer une force d'éjection vers le haut
            rb.velocity += Vector2.up * flipperSpeed * Time.fixedDeltaTime;
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

        else if (collision.gameObject.CompareTag("Ejector"))
        {
            // Calculer la direction de l'éjection
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            // Appliquer une force d'éjection en utilisant Time.fixedDeltaTime
            rb.velocity = direction * speed * ejectorSpeed * Time.fixedDeltaTime;
            Debug.Log("Ejection joué");

            // Déclencher l'animation de l'ejector

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
        else if (collision.gameObject.CompareTag("DeathZone")) // Interaction avec la zone de mort
        {
            // Réduire une vie
            LoseLife();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flipper")) // Quand la balle quitte la zone des palettes
        {
            isTouchingFlipper = false;
        }
    }

    // Méthode pour réduire une vie
    void LoseLife()
    {
        lives--;

        // Si le joueur n'a plus de vies, relancer la scène 
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            // Réapparition de la balle au point de respawn
            transform.position = respawnPoint.position;
            rb.velocity = Vector2.zero; // Réinitialiser la vitesse de la balle
        }
    }
}
