using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnClick()
    {
        //
        ScoreManager.ResetScore();
        // Charger la sc�ne
        SceneManager.LoadScene("Game");
    }
}