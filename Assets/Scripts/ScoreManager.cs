using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Cl�s pour les PlayerPrefs
    private const string scoreKey = "Score";
    public const string highscoreKey = "Highscore";

    // Score actuel et meilleur score
    public static int Score { get; private set; } = 0;
    public static int Highscore { get; private set; } = 0;

    private void Awake()
    {
        // Charger le meilleur score depuis PlayerPrefs
        Highscore = PlayerPrefs.GetInt(highscoreKey, 0);
        DontDestroyOnLoad(gameObject);
    }

    public static void AddToScore(int points)
    {
        // Ajouter les points au score actuel
        Score += points;

        // Mettre � jour le meilleur score si n�cessaire
        if (Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetInt(highscoreKey, Highscore);
            PlayerPrefs.Save();
        }
    }

    // R�initialiser le score � z�ro
    public static void ResetScore()
    {
        Score = 0;
    }
}
