using System.Collections;
using UnityEngine;

public class AmbientZone : MonoBehaviour
{
    public AudioSource audioSource; 
    public float fadeDuration = 2f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //Debug.LogWarning("wchodzi");
            StartCoroutine(FadeIn(audioSource, fadeDuration)); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //Debug.LogWarning("wychodzi");
            StartCoroutine(FadeOut(audioSource, fadeDuration));
        }
    }

    
    private IEnumerator FadeIn(AudioSource source, float duration)
    {
        float startVolume = 0f;
        source.volume = startVolume;
        source.Play();

        while (source.volume < 1f)
        {
            source.volume += Time.deltaTime / duration;
            yield return null;
        }

        source.volume = 1f; 
    }

    
    private IEnumerator FadeOut(AudioSource source, float duration)
    {
        float startVolume = source.volume;

        while (source.volume > 0f)
        {
            source.volume -= Time.deltaTime / duration;
            yield return null;
        }

        source.Stop();
        source.volume = startVolume; 
    }
}