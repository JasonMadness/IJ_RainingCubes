using UnityEngine;

public static class Explosion
{
    public static void Apply(Vector3 center, float radius, float force)
    {
        Collider[] hits = Physics.OverlapSphere(center, radius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent<IExplodable>(out _) == false)
                continue;

            hit.attachedRigidbody.AddExplosionForce(force, center, radius, 0f, ForceMode.Impulse);
        }
    }
}