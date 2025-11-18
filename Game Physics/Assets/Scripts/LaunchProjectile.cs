using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    private GameObject projectilePrefab;
    public float launchVelocity = 700f;
    public float projectileLifetime = 5f;

    private Vector3 launcher;

    void Start()
    {
        // Create a sphere as the projectile
        projectilePrefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        projectilePrefab.name = "Projectile";

        // Add Rigidbody for physics
        Rigidbody rb = projectilePrefab.AddComponent<Rigidbody>();
        rb.useGravity = true;

        // Create a bouncy physics material
        PhysicsMaterial bounceMat = new PhysicsMaterial("Bouncy");
        bounceMat.bounciness = 1f;
        bounceMat.dynamicFriction = 0f;
        bounceMat.staticFriction = 0f;
        bounceMat.bounceCombine = PhysicsMaterialCombine.Maximum;

        // Assign the material to the collider
        projectilePrefab.GetComponent<SphereCollider>().material = bounceMat;

        // Turn off the prefab (we’ll clone it later)
        projectilePrefab.SetActive(false);
    }

    void Update()
    {
        // Fire projectile
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject launchedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            launchedProjectile.SetActive(true);

            // Apply forward force (relative to launcher’s facing direction)
            Rigidbody rb = launchedProjectile.GetComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * launchVelocity);

            // Destroy after a few seconds
            Destroy(launchedProjectile, projectileLifetime);
        }

        // Move launcher
        launcher = transform.localPosition;
        launcher.x += Input.GetAxis("Horizontal") * Time.deltaTime * 10;
        launcher.y += Input.GetAxis("Vertical") * Time.deltaTime * 10;
        transform.localPosition = launcher;
    }
}
