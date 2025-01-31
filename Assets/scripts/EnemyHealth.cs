using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ �������� �����
    public int currentHealth; // ������� �������� �����
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
        // ���������, ����� �� ���� � ������
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position + healthBarOffset);

        // ���� ���� ����� � ������, ��������� ������� ������� ��������
        bool isVisible = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        healthBarUI.SetActive(isVisible);

        if (isVisible)
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