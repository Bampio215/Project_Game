using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fillbar;
    public new GameObject gameObject;
    private Vector3 offset = new Vector3(0, 0, 1.5f);
    // Điều chỉnh vị trí thanh máu

    public void SetHealth(int currentHealth, int maxHealth)
    {
        fillbar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    void Update()
    {
        if (!gameObject.CompareTag("Player"))
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position + offset);
            fillbar.transform.position = screenPosition;
        }

    }
}
