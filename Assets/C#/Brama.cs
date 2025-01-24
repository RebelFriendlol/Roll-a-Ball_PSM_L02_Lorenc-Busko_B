using UnityEngine;

public class AnimationClipTrigger : MonoBehaviour
{
    public Animation firstObjectAnimation; 
    public Animation secondObjectAnimation;

    public AnimationClip firstAnimationClip; 
    public AnimationClip secondAnimationClip; 

    public AudioSource firstObjectAudio;    
    public AudioSource secondObjectAudio;   

    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && !_isTriggered)
        {
            _isTriggered = true;

            
            firstObjectAnimation.clip = firstAnimationClip;
            firstObjectAnimation.Play();
            firstObjectAudio?.Play(); 

         
            StartCoroutine(PlaySecondAnimationAfterFirst());
        }
    }

    private System.Collections.IEnumerator PlaySecondAnimationAfterFirst()
    {
       
        yield return new WaitForSeconds(firstAnimationClip.length);

 
        secondObjectAnimation.clip = secondAnimationClip;
        secondObjectAnimation.Play();
        secondObjectAudio?.Play(); 
    }
}
