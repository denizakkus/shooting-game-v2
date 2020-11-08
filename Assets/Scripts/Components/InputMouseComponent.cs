using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseComponent : MonoBehaviour
{

    [SerializeField] private UnityEngine.Events.UnityEvent onM1Clicked;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            onM1Clicked?.Invoke();
        }
    }
}
