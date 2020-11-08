using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFaceToDestinationComponent : MonoBehaviour
{
    [SerializeField] public bool shouldTrackMouse;
    [SerializeField] public Transform destination { get; set; }

    private Vector3 position;
    private Vector2 direction;

    private void Update()
    {
        LookAt();
    }

    private void LookAt()
    {
        if (shouldTrackMouse) position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
        {
            if (!destination)
            {
                //Debug.LogError("TrackingComponent destination was not found");
                return;
            }
            position = destination.position;
        }

        direction = new Vector2(
            position.x - transform.position.x,
            position.y - transform.position.y
            );

        transform.up = direction;
    }

    public void ResetDestination ()
    {
        destination = null;
    }

    public bool GetShouldTrackMouse()
    {
        return shouldTrackMouse;
    }
    public void SetShouldTrackMouse(bool shouldTrackMouse)
    {
        this.shouldTrackMouse = shouldTrackMouse;
    }
}
