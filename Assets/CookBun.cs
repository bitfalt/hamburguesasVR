using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBun : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public AudioClip cookingSound; // Sonido mientras se cocina
    public float cookingSoundVolume = 1.0f; // Volumen del sonido de cocción

    private bool inContactWithOven = false;
    private float timer = 0f;
    private bool color1Applied = false;
    private bool color2Applied = false;
    private AudioSource audioSource; // Referencia al AudioSource

    private void Start()
    {
        // Obtener la referencia al AudioSource adjunto al mismo objeto
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("oven"))
        {
            inContactWithOven = true;
            // Start the timer when entering the oven
            timer = 0f;
            color1Applied = false;
            color2Applied = false;

            // Comenzar a reproducir el sonido de cocción
            PlayCookingSound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("oven"))
        {
            inContactWithOven = false;
            // Reset the timer when exiting the oven
            timer = 0f;
            color1Applied = false;
            color2Applied = false;

            // Detener el sonido de cocción
            StopCookingSound();

        }
    }

    private void Update()
    {
        // Only update the timer if in contact with the oven
        if (inContactWithOven)
        {
            timer += Time.deltaTime;

            // Check if 5 seconds have passed and color 1 hasn't been applied yet
            if (timer >= 5f && !color1Applied)
            {
                ApplyColor(material1);
                color1Applied = true;
            }

            // Check if 10 more seconds have passed and color 2 hasn't been applied yet
            if (timer >= 15f && !color2Applied)
            {
                ApplyColor(material2);
                color2Applied = true;
            }
        }
    }

    private void ApplyColor(Material material)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = material;
        }
    }

    private void PlayCookingSound()
    {
        if (audioSource != null && cookingSound != null)
        {
            audioSource.clip = cookingSound;
            audioSource.volume = cookingSoundVolume; // Set the desired volume
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void StopCookingSound()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
