using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    public TMP_Text highscoreText; // R�f�rence au composant TextMeshProUGUI pour afficher le meilleur score

    void Start()
    {
        // V�rifier si le composant TextMeshProUGUI est assign�
        if (highscoreText == null)
        {
            Debug.LogError("Le composant TextMeshProUGUI n'est pas assign� dans le script HighscoreDisplay !");
            return;
        }

        // R�cup�rer le meilleur score depuis PlayerPrefs en utilisant la constante highscoreKey
        int highscore = PlayerPrefs.GetInt(ScoreManager.highscoreKey, 0);

        // Mettre � jour le texte avec le meilleur score
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
}
