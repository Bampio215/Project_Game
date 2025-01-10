using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth; // Máu tối đa
    private int currentHealth; // Máu hiện tại
    public HealthBar healthBar; // Tham chiếu đến thanh máu
    private ExpController expController;
    public int ExpCreep;
    void Start()
    {   
        expController = FindObjectOfType<ExpController>();
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
        expController.CurrentEXP += ExpCreep; 
        Destroy(gameObject); 
        Destroy(healthBar.gameObject);
    }
}
