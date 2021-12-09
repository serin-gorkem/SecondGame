using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler1 : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip win;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem winParticles;
    Movement1 movement;
    AudioSource sound;
    bool isTransitioning = true;
    bool collisionDisabled = true;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
            switch (other.gameObject.tag)
            {
                case "Respawn":
                    break;
                case "Finish":
                    StartNextLevelSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        else if (isTransitioning == false) { return; }
    }

    void StartNextLevelSequence()
    {
        movement = GetComponent<Movement1>();
        movement.enabled = false;
        sound.Stop();
        sound.PlayOneShot(win);
        winParticles.Play();
        isTransitioning = true;
        Invoke(nameof(NextLevel), delay);
    }

    void StartCrashSequence()
    {
        crashParticles.Play();
        sound.Stop();
        sound.PlayOneShot(crash);
        movement = GetComponent<Movement1>();
        movement.enabled = false;
        isTransitioning = true;
        Invoke(nameof(ReloadLevel), delay);

    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
