using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Signalization _signalization;
    
    private bool _isOpened = false;
    private const string IsOpened = "isOpened";

    public void Open()
    {
        _isOpened = !_isOpened;
        _animator.SetBool(IsOpened, _isOpened);
        if (_isOpened)
        {
            _signalization.PlayAudio();
            StartCoroutine(_signalization.ChangeVolumeUp());
        }    
    }
}
