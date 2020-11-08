using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardListenerComponent : MonoBehaviour
{
    // [0] left  &&  [1] - right
    // [2] up    &&  [3] - down
    [SerializeField] private List<KeyCode> moveKeys;
    [SerializeField] private List<UnityEngine.Events.UnityEvent> movementEvents;

    [SerializeField] private KeyCode pickUpKey;
    [SerializeField] private UnityEngine.Events.UnityEvent onPickUp;

    [SerializeField] private KeyCode switchWeaponKey;
    [SerializeField] private UnityEngine.Events.UnityEvent onSwitch;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            for (int i = 0; i < moveKeys.Count; i++)
            {
                if (Input.GetKey(moveKeys[i]))
                {
                    movementEvents[i]?.Invoke();
                }
            }

            if (Input.GetKeyDown(pickUpKey))
            {
                onPickUp?.Invoke();
            }
            
            if (Input.GetKeyDown(switchWeaponKey))
            {
                onSwitch?.Invoke();
            }
        }
    }
}
