using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpened = false;
    [SerializeField] private Animator _animator;

    public void Open()
    {
        _isOpened = !_isOpened;
        _animator.SetBool("isOpened", _isOpened);
        if(_isOpened == true)
        {
            Debug.Log("Меня открыли!");
        }
        else
        {
            Debug.Log("Меня закрыли!");
        }
    }

    public bool GetIsOpened()
    {
        return _isOpened;
    }

}
