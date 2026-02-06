using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button playButton;
    void Start()
    {
        playButton.onClick.AddListener(OpenTutoLevel);
    }

    private void OpenTutoLevel()
    {
        int _tutoLevelInt = 1;
        SceneManager.LoadScene(_tutoLevelInt);
    }

   
}
