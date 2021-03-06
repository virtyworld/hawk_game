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

    public void Setup(Action onLoseScreenAction = null)
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

    private void TakeDamage(Collision collider)
    {
        if (currentHealth > 0)
        {
            
            if (gameObject.tag == "Character")
            {
                currentHealth -= 20;
                Score.Instance.PlayerHasDamage(collider.transform.parent.GetInstanceID());
            }
            else
            {
                if (Score.Instance.IsBonus)
                {
                    currentHealth -= 40;
                }
                else
                {
                    currentHealth -= 20;
                }
                
                Score.Instance.EnemyHasDamage();
            }
            
            textHealth.text = currentHealth.ToString();
            healthImage.fillAmount = currentHealth / 100;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        TakeDamage(other);
        Destroy(other.gameObject);
    }

    private IEnumerator Die()
    {
        explosion.Play();
        yield return new WaitForSeconds(0.5f);
        
        if (gameObject.tag == "Character")
        {
            Time.timeScale = 0.3f;
            onLoseScreenAction?.Invoke();
        }
        if (gameObject.tag != "Character")
        {
            Score.Instance.KillEnemy(transform.parent.GetInstanceID());
        }
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}