using UnityEngine;
using TMPro;

public class ScoreDisplayOnDeath : MonoBehaviour
{
    public TMP_Text scoreText; // R�f�rence au composant TextMeshProUGUI pour afficher le score

    void Start()
    {
        // V�rifier si le composant TextMeshProUGUI est assign�
        if (scoreText == null)
        {
            Debug.LogError("Le composant TextMeshProUGUI n'est pas assign� dans le script ScoreDisplayOnDeath !");
            return;
        }

        // R�cup�rer le score du joueur depuis les PlayerPrefs
        int score = PlayerPrefs.GetInt("Score", 0);

        // Mettre � jour le texte avec le score r�cup�r�
        scoreText.text = "Score: " + score.ToString();
    }
}
