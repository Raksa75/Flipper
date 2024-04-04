using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    public TMP_Text highscoreText; // Référence au composant TextMeshProUGUI pour afficher le meilleur score

    void Start()
    {
        // Vérifier si le composant TextMeshProUGUI est assigné
        if (highscoreText == null)
        {
            Debug.LogError("Le composant TextMeshProUGUI n'est pas assigné dans le script HighscoreDisplay !");
            return;
        }

        // Récupérer le meilleur score depuis PlayerPrefs en utilisant la constante highscoreKey
        int highscore = PlayerPrefs.GetInt(ScoreManager.highscoreKey, 0);

        // Mettre à jour le texte avec le meilleur score
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
