using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checker : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;
    private bool IsEntered = false;
    private event UnityAction SignalizationOn;

    private void OnEnable()
    {
        SignalizationOn += Signalization;
    }

    private void OnDisable()
    {
        SignalizationOn -= Signalization;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsEntered = true;
        SignalizationOn?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        IsEntered = false;
        SignalizationOn?.Invoke();
    }

    private void Signalization()
    {
        if(IsEntered)
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
