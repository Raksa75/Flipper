using UnityEngine;
using TMPro;

public class ScoreDisplayOnDeath : MonoBehaviour
{
    public TMP_Text scoreText; // Référence au composant TextMeshProUGUI pour afficher le score

    void Start()
    {
        // Vérifier si le composant TextMeshProUGUI est assigné
        if (scoreText == null)
        {
            Debug.LogError("Le composant TextMeshProUGUI n'est pas assigné dans le script ScoreDisplayOnDeath !");
            return;
        }

        // Récupérer le score du joueur depuis les PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);

        // Mettre à jour le texte avec le score récupéré
        scoreText.text = "Score: " + score.ToString();
    }
}
