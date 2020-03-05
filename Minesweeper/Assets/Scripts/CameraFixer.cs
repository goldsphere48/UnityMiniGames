using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFixer : MonoBehaviour
{
    [SerializeField] private float width = 8f;
    [SerializeField] private Camera _camera;
    [SerializeField] private bool _executeInPlayMode;

#if !UNITY_EDITOR
    void Start() 
    {
        FixCameraWidth();
    }
#else
    void Update()
    {
        FixCameraWidth();
    }
#endif

    private void FixCameraWidth()
    {
        float aspect = _camera.aspect;
        float newSize = width / (2 * aspect);
        Camera.main.orthographicSize = newSize;
    }
}
