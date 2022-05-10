using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorModeManager : MonoBehaviour
{
    [SerializeField] private bool lockCursor = true;

    private void Start()
    {
        HandleCursorMode();
    }

    private void HandleCursorMode()
    {
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
    }
}
