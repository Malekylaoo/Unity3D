using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private float _timeTurnVolume;

    private AudioSource _audioSource;

    public void PlayAudio()
    {
        Debug.Log("Я дошел до PlayAudio");
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public IEnumerator ChangeVolumeUp()
    {
        Debug.Log("Я дошел до Up");
        while (_audioSource.volume < 1)
        {
            _audioSource.volume += Mathf.MoveTowards(0, 1, Time.deltaTime / _timeTurnVolume);
            yield return null;
        }
        _audioSource.loop = true;
    }

    public IEnumerator ChangeVolumeDown()
    {
        Debug.Log("Я дошел до Down");
        while (_audioSource.volume > 0)
        {
            _audioSource.volume -= Mathf.MoveTowards(0, 1, Time.deltaTime / _timeTurnVolume);
            yield return null;
        }
        _audioSource.loop = false;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }
}
