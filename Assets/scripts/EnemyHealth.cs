using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Максимальное здоровье врага
    public float currentHealth; // Текущее здоровье врага
    public GameObject healthBarPrefab; // Префаб полоски здоровья
    public Vector3 healthBarOffset = new Vector3(0, 2, 0); // Смещение полоски здоровья над врагом

    private Slider healthSlider; // Ссылка на компонент Slider
    private GameObject healthBarUI; // Ссылка на объект полоски здоровья

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье

        // Создаём полоску здоровья
        healthBarUI = Instantiate(healthBarPrefab, FindObjectOfType<Canvas>().transform);
        healthSlider = healthBarUI.GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // Обновляем позицию полоски здоровья
        if (healthBarUI != null)
        {
            healthBarUI.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
        }
    }

    // Метод для нанесения урона
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        // Если здоровье закончилось, уничтожаем врага
        if (currentHealth <= 0)
        {
            Destroy(healthBarUI); // Уничтожаем полоску здоровья
            Destroy(gameObject); // Уничтожаем врага
        }
    }
}