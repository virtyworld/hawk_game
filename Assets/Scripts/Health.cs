using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthImage;
    [SerializeField] private TextMeshProUGUI textHealth;
    [SerializeField] private ParticleSystem explosion;
    

    private Action onLoseScreenAction;
    
    public void Setup(Action onLoseScreenAction)
    {
        this.onLoseScreenAction = onLoseScreenAction;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthImage.fillAmount = 1;
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
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

    private IEnumerator Die()
    {
        explosion.Play();
        if (gameObject.tag == "Character")
        {
            Time.timeScale = 0.3f;
            // Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
      
        yield return new WaitForSeconds(0.5f);
        onLoseScreenAction?.Invoke();
        Time.timeScale = 1f;
        //Time.fixedDeltaTime = Time.timeScale * 0.01f;
        Destroy(gameObject);
    }
}