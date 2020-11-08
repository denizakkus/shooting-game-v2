using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float movementVelocityMagnitude;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void MoveUp()
    {
        rigidbody.velocity = new Vector2(
            rigidbody.velocity.x,
            movementVelocityMagnitude
            ).normalized * movementVelocityMagnitude;
    }

    public void MoveDown()
    {
        rigidbody.velocity = new Vector2(
            rigidbody.velocity.x,
            -movementVelocityMagnitude
            ).normalized * movementVelocityMagnitude;
    }

    public void MoveRight()
    {
        rigidbody.velocity = new Vector2(
            movementVelocityMagnitude,
            rigidbody.velocity.y
            ).normalized * movementVelocityMagnitude;
    }
    public void MoveLeft()
    {
        rigidbody.velocity = new Vector2(
            -movementVelocityMagnitude,
            rigidbody.velocity.y
            ).normalized * movementVelocityMagnitude;
    }

}
