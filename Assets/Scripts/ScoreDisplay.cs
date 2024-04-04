using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText; // R�f�rence au composant TextMeshProUGUI pour afficher le score

    void Update()
    {
        // Mettre � jour le texte du score avec la valeur actuelle du score du ScoreManager
        if (scoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.Score.ToString();
        }
    }
}
