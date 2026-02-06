using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollsisonHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2.0f;
    [SerializeField] AudioClip successSFX;
    [SerializeField] AudioClip crashSFX;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;

    AudioSource audioSource;
    bool isControllable = true;
    bool isCollidable = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable || !isCollidable) return;
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Everything is good !");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void LoadNextLevel()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;
        int _nextScene = _currentScene + 1;

        if(_nextScene == SceneManager.sceneCountInBuildSettings)
        {
            _nextScene = 1;
        }

        SceneManager.LoadScene(_nextScene);
    }

    void ReloadLevel()
    {
        int _currentScene = SceneManager.GetActiveScene().buildIndex;//Active Scene
        SceneManager.LoadScene(_currentScene);// Load the first scene ( File/build profile/scene manager)
    }

    void StartCrashSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isControllable = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void RespondToDebugKeys()
    {
        if(Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else
        {
            if (Keyboard.current.cKey.wasPressedThisFrame)//just one time
            {
                isCollidable = !isCollidable;
            }
        }
    }
}
