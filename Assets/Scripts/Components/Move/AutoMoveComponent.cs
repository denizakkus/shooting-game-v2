using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AutoMoveComponent : MonoBehaviour
{
    [SerializeField] private float movementVelocityMagnitude = 5;
    [SerializeField] public bool shouldMoveToDestination { get; set; } = false;
    [SerializeField] public Transform destinationTransform { get; set; }

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void ResetMove()
    {
        shouldMoveToDestination = false;
        destinationTransform = null;
    }

    private void Update()
    {
        if (shouldMoveToDestination)
        {
            if (!destinationTransform)
            {
                Debug.Log("I lost my destination");
                return;
            }

            Vector2 direction = destinationTransform.position - this.transform.position;
            direction.Normalize();
            rigidbody.velocity = direction * movementVelocityMagnitude;
        }
    }
}
