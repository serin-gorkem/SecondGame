using System;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    [SerializeField] float thrustForce = 1100f;
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem Left_EngineParticles;
    [SerializeField] ParticleSystem RightEngineParticles;
    [SerializeField] ParticleSystem Engine1Particles;
    [SerializeField] ParticleSystem Engine2Particles;
    [SerializeField] ParticleSystem Engine3Particles;
    [SerializeField] ParticleSystem Engine4Particles;

    Rigidbody rb;
    AudioSource sound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();

    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else if (Input.GetKey(KeyCode.X))
        {
            SlowerThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    void ProcessRotation()
    {
        SideThrusters();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);

        if (!sound.isPlaying)
        {
            sound.PlayOneShot(mainEngine);
        }
        if (!Engine1Particles.isPlaying)
        {
            Engine1Particles.Play();
        }
        if (!Engine2Particles.isPlaying)
        {
            Engine2Particles.Play();
        }
        if (!Engine3Particles.isPlaying)
        {
            Engine3Particles.Play();
        }
        if (!Engine4Particles.isPlaying)
        {
            Engine4Particles.Play();
        }
    }
    void SlowerThrusting()
    {
        rb.AddRelativeForce(Vector3.up * -thrustForce * Time.deltaTime);

             if (!sound.isPlaying)
        {
            sound.PlayOneShot(mainEngine);
        }
        if (!Engine1Particles.isPlaying)
        {
            Engine1Particles.Play();
        }
        if (!Engine2Particles.isPlaying)
        {
            Engine2Particles.Play();
        }
        if (!Engine3Particles.isPlaying)
        {
            Engine3Particles.Play();
        }
        if (!Engine4Particles.isPlaying)
        {
            Engine4Particles.Play();
        }   
    }
    private void StopThrusting()
    {
        sound.Stop();
        Engine1Particles.Stop();
        Engine2Particles.Stop();
        Engine3Particles.Stop();
        Engine4Particles.Stop();
    }
    private void SideThrusters()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateRight();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateLeft();
        }
        else
        {
            StopParticles();
        }
    }
    private void RotateRight()
    {
        if (!RightEngineParticles.isPlaying)
        {
            RightEngineParticles.Play();
        }
        ApplyRotation(turnSpeed);
    }
    private void RotateLeft()
    {
        if (!Left_EngineParticles.isPlaying)
        {
            Left_EngineParticles.Play();
        }
        ApplyRotation(-turnSpeed);
    }

    private void StopParticles()
    {
        Left_EngineParticles.Stop();
        RightEngineParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;// We are unfreezing so we can control normal
    }
}