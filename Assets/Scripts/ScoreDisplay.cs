using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText; // Référence au composant TextMeshProUGUI pour afficher le score

    void Update()
    {
        // Mettre à jour le texte du score avec la valeur actuelle du score du ScoreManager
        if (scoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.Score.ToString();
        }
    }
}
