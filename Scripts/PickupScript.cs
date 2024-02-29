using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    [SerializeField] private float throwAmount; // The amount of force applied to the throw
    private Rigidbody CurrentObject;
    private Vector3 initialGrabPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
                initialGrabPosition = PickupTarget.position;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject.velocity = CalculateThrowVelocity();
                CurrentObject = null;
            }
        }
    }

    private Vector3 CalculateThrowVelocity()
    {
        Vector3 direction = (PickupTarget.position - PlayerCam.transform.position).normalized;
        float force = throwAmount;
        Vector3 velocity = direction * force;
        return velocity;
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 directionToPoint = PickupTarget.position - CurrentObject.position;
            float distanceToPoint = directionToPoint.magnitude;
            CurrentObject.velocity = directionToPoint * 12f * distanceToPoint;
        }
    }
}