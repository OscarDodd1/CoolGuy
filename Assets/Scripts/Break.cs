using UnityEngine;

public class UnlockSelfOnTrigger2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && rb != null && col != null)
        {
            // Unlock all position and rotation constraints
            rb.constraints = RigidbodyConstraints2D.None;

            // Disable trigger so it becomes a solid collider again
            col.isTrigger = false;
        }
    }
}
