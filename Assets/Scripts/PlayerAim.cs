using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    private Vector2 aimInput;
    void Update()
    {
        
    }


    private void OnAim(InputValue value)
    {
        aimInput = value.Get<Vector2>();
    }
}
