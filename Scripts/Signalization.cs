using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float timeTurnVolume = 30;
    private AudioSource _audioSource;
    private bool isEntered = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter()
    {
        _audioSource.loop = true;
        PlayAudio();
        isEntered = true;
    }

    private void Update()
    {
        ChangeVolume();
    }

    private void OnTriggerExit()
    {
        _audioSource.loop = false;
        isEntered = false;
    }

    private void PlayAudio()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();     
    }

    private void ChangeVolume()
    {
        if (isEntered)
            _audioSource.volume += Mathf.MoveTowards(0, 1, Time.deltaTime / timeTurnVolume);
        else
            _audioSource.volume -= Mathf.MoveTowards(0, 1, Time.deltaTime / timeTurnVolume);
    }


}
