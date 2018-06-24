using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ButtunsFX : MonoBehaviour
{
    
    public AudioSource _audioSource;
    [SerializeField]
    private AudioClip clickFX;
    [SerializeField]
    private AudioClip selectFX;

    public void OnAwake()
    {
        btDownSound();
        btEnterSound();
    }

    public void btEnterSound()
    {
       
            _audioSource.PlayOneShot(selectFX);
        
    }
    public void btDownSound()
    {
        
            _audioSource.PlayOneShot(clickFX);
      
        
    }
}
