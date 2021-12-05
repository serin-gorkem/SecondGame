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
    bool isTransitioning = false;
    bool collisionDisabled = true;
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    /*void Update()
    {
        DebugKeys();  
    }

    /*private void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartNextLevelSequence();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; //togle collision
        }
    }*/

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || collisionDisabled)
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
            else if(isTransitioning ==false){return;}

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
        movement = GetComponent<Movement1>();
        movement.enabled = false;
        sound.PlayOneShot(crash);
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
