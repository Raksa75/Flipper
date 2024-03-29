using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 10f; // Vitesse initiale de la balle
    public float ejectorSpeed = 2f; // Vitesse d'�jection de l'�jecteur

    public int initialLives = 3; // Nombre de vies initial
    public Transform respawnPoint; // Point de r�apparition de la balle
    public int ejectorPoints = 100; // Points gagn�s en touchant un ejector
    public int targetPoints = 50; // Points gagn�s en touchant une cible

    private Rigidbody2D rb;
    private bool isTouchingFlipper = false; // Indique si la balle est en contact avec les palettes
    public int lives; // Nombre de vies restantes

    // Score de la balle
    public int Score { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Appliquer une force initiale � la balle pour la faire bouger
        // rb.velocity = Vector2.up * speed;

        // Initialiser le score � z�ro
        Score = 0;

        // Initialiser le nombre de vies
        lives = initialLives;
    }

    void Update()
    {
        if (isTouchingFlipper && Input.GetKey(KeyCode.Space))
        {
            // Si la touche espace est enfonc�e et que la balle est en contact avec les palettes,
            // appliquer une force d'�jection vers le haut
            rb.velocity += Vector2.up * ejectorSpeed;
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

            // Augmenter le score
            Score += ejectorPoints; // Ajouter les points d'ejector
        }
        else if (collision.gameObject.CompareTag("Target")) // Interaction avec les cibles
        {
            // D�truire la cible
            Destroy(collision.gameObject);

            // Augmenter le score
            Score += targetPoints; // Ajouter les points de cible
        }
        else if (collision.gameObject.CompareTag("DeathZone")) // Interaction avec la zone de mort
        {
            // R�duire une vie
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

    // M�thode pour r�duire une vie
    void LoseLife()
    {
        lives--;

        // Si le joueur n'a plus de vies, relancer la sc�ne ou effectuer une action de fin de jeu
        if (lives <= 0)
        {
            // Vous pouvez ajouter d'autres actions ici, comme afficher un �cran de fin de jeu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Relancer la sc�ne actuelle
        }
        else
        {
            // R�apparition de la balle au point de respawn
            transform.position = respawnPoint.position;
            rb.velocity = Vector2.zero; // R�initialiser la vitesse de la balle
        }
    }
}
