using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private TextMeshProUGUI textHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthImage.fillAmount = 1;
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            textHealth.text = currentHealth.ToString();
            healthImage.fillAmount = currentHealth / 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(20);
    }
}
