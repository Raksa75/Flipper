using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public Ball ball; // Référence à l'objet Ball qui contient les vies

    private TMP_Text livesText; // Référence au composant TextMeshPro pour afficher les vies

    void Start()
    {
        // Récupérer le composant TextMeshPro
        livesText = GetComponent<TMP_Text>();

        // Vérifier si la référence à l'objet Ball est définie
        if (ball != null)
        {
            // Mettre à jour le texte avec le nombre de vies initial
            UpdateLivesDisplay();
        }
        else
        {
            // Afficher un message d'erreur si la référence à l'objet Ball est manquante
            Debug.LogError("La référence à l'objet Ball est manquante !");
        }
    }

    void Update()
    {
        // Mettre à jour le texte avec le nombre de vies restantes à chaque frame
        UpdateLivesDisplay();
    }

    // Méthode pour mettre à jour le texte avec le nombre de vies restantes
    void UpdateLivesDisplay()
    {
        if (livesText != null && ball != null)
        {
            // Mettre à jour le texte avec le nombre de vies restantes
            livesText.text = "Vies : " + ball.lives.ToString();
        }
    }
}
