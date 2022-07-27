using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DoorAnimation))]
public class Door : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;
   
    private DoorAnimation _doorAnimation;
    private event UnityAction SignalizationOn;
    private bool _isOpened = false; 

    public void Open()
    {
        _isOpened = !_isOpened;
        _doorAnimation.ChangeAnimation(_isOpened);
        SignalizationOn?.Invoke();
    }

    private void Start()
    {
        _doorAnimation = GetComponent<DoorAnimation>();
    }

    private void OnEnable()
    {
        SignalizationOn += Signalization;
    }

    private void OnDisable()
    {
        SignalizationOn -= Signalization;
    }

    private void Signalization()
    {
        if (_isOpened)
        {
            _signalization.PlayAudio();
            StartCoroutine(_signalization.ChangeVolumeUp());
        }
        else
        {
            _signalization.PlayAudio();
            StartCoroutine(_signalization.ChangeVolumeDown());
        }
    }
}
