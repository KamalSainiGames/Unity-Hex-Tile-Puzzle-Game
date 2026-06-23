using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 10f;

    public LayerMask collisionMask;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (target == null) return;

        // Base desired position (behind player)
        Vector3 desiredPosition = target.position
                                - target.forward * distance
                                + Vector3.up * height;

        Vector3 direction = (desiredPosition - target.position).normalized;
        float maxDistance = Vector3.Distance(target.position, desiredPosition);

        RaycastHit hit;

        // 🔥 MAIN FIX
        if (Physics.Raycast(target.position, direction, out hit, maxDistance, collisionMask))
        {
            // Move camera in front of wall
            desiredPosition = hit.point + hit.normal * 0.5f;

            // 👇 EXTRA FIX: thoda upar shift karo
            desiredPosition += Vector3.up * 1.0f;

            // 👇 OPTIONAL: slight side offset (player visible rahe)
            desiredPosition += target.right * 0.5f;
        }

        // Smooth follow
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, 0.05f);

        // Always look at player (slightly above center)
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}