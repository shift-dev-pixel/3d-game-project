using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // ������������ �������� �����
    public float currentHealth; // ������� �������� �����
    public GameObject healthBarPrefab; // ������ ������� ��������
    public Vector3 healthBarOffset = new Vector3(0, 2, 0); // �������� ������� �������� ��� ������

    private Slider healthSlider; // ������ �� ��������� Slider
    private GameObject healthBarUI; // ������ �� ������ ������� ��������

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� ��������

        // ������ ������� ��������
        healthBarUI = Instantiate(healthBarPrefab, FindObjectOfType<Canvas>().transform);
        healthSlider = healthBarUI.GetComponent<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // ��������� ������� ������� ��������
        if (healthBarUI != null)
        {
            healthBarUI.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
        }
    }

    // ����� ��� ��������� �����
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        // ���� �������� �����������, ���������� �����
        if (currentHealth <= 0)
        {
            Destroy(healthBarUI); // ���������� ������� ��������
            Destroy(gameObject); // ���������� �����
        }
    }
}