using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DoorAnimation))]
public class Door : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;
   
    private DoorAnimation _doorAnimation;
    private bool _isOpened = false; 

    public void Open()
    {
        _isOpened = !_isOpened;
        _doorAnimation.ChangeAnimation(_isOpened);
        Signalization();
    }

    private void Start()
    {
        _doorAnimation = GetComponent<DoorAnimation>();
    }

    private void Signalization()
    {
        if (_isOpened)
        {
            _signalization.SignalizationUp();
        }
        else
        {
            _signalization.SignalizationDown();
        }
    }
}
