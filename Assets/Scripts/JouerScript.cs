using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnClick()
    {
        //
        ScoreManager.ResetScore();
        // Charger la scène
        SceneManager.LoadScene("Game");
    }
}