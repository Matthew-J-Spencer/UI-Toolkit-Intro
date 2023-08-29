using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private float _targetScale = 1;
    private Vector3 _scaleVel;
    private Quaternion _targetRotation;

    private void OnEnable()
    {
        MainMenuScreen.ScaleChanged += OnScaleChanged;
        MainMenuScreen.SpinClicked += OnSpinClicked;
    }

    private void OnDisable()
    {
        MainMenuScreen.ScaleChanged -= OnScaleChanged;
        MainMenuScreen.SpinClicked -= OnSpinClicked;
    }

    private void OnScaleChanged(float newScale)
    {
        _targetScale = newScale;
    }

    private void OnSpinClicked()
    {
        _targetRotation = transform.rotation * Quaternion.Euler(Random.insideUnitSphere * 360);
    }
    
    private void Update()
    {
        transform.localScale =
            Vector3.SmoothDamp(transform.localScale,
                _targetScale * Vector3.one, ref _scaleVel, 0.15f);

        transform.rotation = Quaternion.Slerp(transform.rotation,
            _targetRotation, Time.deltaTime * 5);
    }
}