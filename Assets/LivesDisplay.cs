using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public Ball ball; // R�f�rence � l'objet Ball qui contient les vies

    private TMP_Text livesText; // R�f�rence au composant TextMeshPro pour afficher les vies

    void Start()
    {
        // R�cup�rer le composant TextMeshPro
        livesText = GetComponent<TMP_Text>();

        // V�rifier si la r�f�rence � l'objet Ball est d�finie
        if (ball != null)
        {
            // Mettre � jour le texte avec le nombre de vies initial
            UpdateLivesDisplay();
        }
        else
        {
            // Afficher un message d'erreur si la r�f�rence � l'objet Ball est manquante
            Debug.LogError("La r�f�rence � l'objet Ball est manquante !");
        }
    }

    void Update()
    {
        // Mettre � jour le texte avec le nombre de vies restantes � chaque frame
        UpdateLivesDisplay();
    }

    // M�thode pour mettre � jour le texte avec le nombre de vies restantes
    void UpdateLivesDisplay()
    {
        if (livesText != null && ball != null)
        {
            // Mettre � jour le texte avec le nombre de vies restantes
            livesText.text = "Vies : " + ball.lives.ToString();
        }
    }
}
