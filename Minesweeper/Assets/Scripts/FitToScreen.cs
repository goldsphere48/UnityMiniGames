using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FitToScreen : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _executeInPlayMode;

    public void Start()
    {
        FitToScreenMethod();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (_executeInPlayMode || !Application.isPlaying)
        {
            FitToScreenMethod();
        }
    }
#endif

    private void FitToScreenMethod()
    {
        float height = 2f * _camera.orthographicSize;
        float width = height * _camera.aspect;
        transform.localScale = new Vector3(width, height, 1);
    }
}
