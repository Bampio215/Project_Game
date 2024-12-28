using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth; // Máu tối đa
    private int currentHealth; // Máu hiện tại
    public HealthBar healthBar; // Tham chiếu đến thanh máu

    AudioManager audioManager;
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
        // Kiểm tra nếu đối tượng là Boss
        if (CompareTag("Boss"))
        {
            // Đóng băng thời gian
            Time.timeScale = 0;

            // Tùy chọn: Thêm thông báo hoặc hiển thị giao diện
            Debug.Log("Boss đã chết! Thời gian đã bị đóng băng.");
        }

        // Xóa thanh máu và đối tượng
        if (healthBar != null)
        {
            Destroy(healthBar.gameObject);
        }

        Destroy(gameObject);
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
