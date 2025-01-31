using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье врага
    public int currentHealth; // Текущее здоровье врага
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
        // Проверяем, виден ли враг в камере
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position + healthBarOffset);

        // Если враг виден в камере, обновляем позицию полоски здоровья
        bool isVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        healthBarUI.SetActive(isVisible);

        if (isVisible)
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