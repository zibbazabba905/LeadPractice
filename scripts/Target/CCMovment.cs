using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CCMovment : MonoBehaviour
{
    CharacterController CharacterController;
    private Vector3 DesiredPosition { get; set; }
    private float MovementSpeed { get; set; }
    private float MinimumDistance { get; set; } = 0.01f;
    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        DesiredPosition = transform.position;
    }
    private void Update()
    {
        if (!MovementComplete())
            CharacterController.Move(TowardsDesiredPosition() * MovementSpeed * Time.deltaTime);
    }
    public void GoTo(Vector3 goalPosition, float speed)
    {
        DesiredPosition = goalPosition;
        MovementSpeed = speed;
    }
    private Vector3 TowardsDesiredPosition()
    {
        Debug.DrawRay(transform.position, DesiredPosition - transform.position);
        return (DesiredPosition - transform.position).normalized;
    }
    private bool MovementComplete()
    {
        return Vector3.Distance(DesiredPosition, transform.position) < MinimumDistance;
    }



}
