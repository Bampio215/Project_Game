using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth; // Máu tối đa
    private int currentHealth; // Máu hiện tại
    public HealthBar healthBar; // Tham chiếu đến thanh máu

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth); // Cập nhật thanh máu
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth, maxHealth); // Cập nhật thanh máu

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            TakeDamage(1);
        }
    }


    void Die()
    {
        // Khi quái vật chết, có thể thêm hiệu ứng tiêu diệt tại đây
        Destroy(gameObject); // Xóa quái vật
        Destroy(healthBar.gameObject); // Xóa thanh máu
    }
}
