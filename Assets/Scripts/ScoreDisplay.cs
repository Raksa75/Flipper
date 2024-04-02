using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public Ball ball; // R�f�rence au script de la balle
    public TMP_Text scoreText; // R�f�rence au composant TextMeshProUGUI pour afficher le score

    void Update()
    {
        // Mettre � jour le texte du score avec la valeur actuelle du score de la balle
        if (scoreText != null && ball != null)
        {
            scoreText.text = "Score: " + ball.Score.ToString();
        }
    }
}
