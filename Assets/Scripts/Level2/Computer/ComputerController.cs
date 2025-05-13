using UnityEngine;
using UnityEngine.UI;

public class ComputerController : MonoBehaviour
{
    public Sprite computerOn;        // Спрайт включенного компьютера
    public Sprite computerOff;       // Спрайт выключенного компьютера
    public GameObject screenContent; // Объект с изображением на экране (должен быть дочерним)

    private Image computerImage;     // Компонент Image для отображения спрайта
    private bool isOn = true;       // Текущее состояние компьютера

    void Start()
    {
        // Получаем компонент Image
        computerImage = GetComponent<Image>();

        // Устанавливаем начальный спрайт и состояние экрана
        if (computerImage != null && computerOn != null)
        {
            computerImage.sprite = computerOn;
        }

        // Инициализируем состояние экрана
        UpdateScreenState();
    }

    // Метод для переключения состояния компьютера
    public void ToggleComputer()
    {
        isOn = !isOn; // Инвертируем состояние

        // Меняем спрайт
        if (computerImage != null)
        {
            computerImage.sprite = isOn ? computerOn : computerOff;
        }

        // Обновляем состояние экрана
        UpdateScreenState();

    }

    // Метод для обновления состояния экрана
    private void UpdateScreenState()
    {
        if (screenContent != null)
        {
            screenContent.SetActive(isOn);
        }
    }
    public bool IsComputerOn()
    {
        return isOn;
    }
}