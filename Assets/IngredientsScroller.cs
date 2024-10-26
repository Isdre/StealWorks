using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class IngredientScroller : MonoBehaviour
{
    public List<Sprite> ingredients; // Lista sprite'ów składników
    public GameObject ingredientPrefab; // Prefab składnika jako Button
    public Transform container; // Kontener (Panel) na składniki
    public Button leftButton;
    public Button rightButton;

    private GameManager inventory; 
    private int startIndex = 0;
    private int visibleCount = 6; // Liczba widocznych składników

    void Start()
    {
        inventory = FindObjectOfType<GameManager>();
        UpdateIngredientDisplay();
        
        // Listener do przycisków przewijania
        leftButton.onClick.AddListener(ScrollLeft);
        rightButton.onClick.AddListener(ScrollRight);

        // Ustawienie aktywności przycisków
        UpdateButtonState();
    }

    private void UpdateIngredientDisplay()
    {
        // Czyszczenie zawartości kontenera
        foreach (Transform child in container) 
            Destroy(child.gameObject);
        
        // Dodawanie przycisków dla widocznych składników
        for (int i = startIndex; i < startIndex + visibleCount && i < ingredients.Count; i++)
        {
            // Tworzymy nowy przycisk ze składnikiem
            GameObject newIngredientButton = Instantiate(ingredientPrefab, container);
            Image ingredientImage = newIngredientButton.GetComponent<Image>();
            ingredientImage.sprite = ingredients[i];

            // Dodanie zdarzenia kliknięcia
            int ingredientIndex = i; // Przechowywanie aktualnego indeksu dla delegacji
            newIngredientButton.GetComponent<Button>().onClick.AddListener(() => OnIngredientClick(ingredientIndex));
        }
    }
    private string GetIngredientName(int index)
    {
        switch (index)
        {
            case 0: return "Bulka";
            case 1: return "Kotlet";
            case 2: return "Bekon";
            case 3: return "Szarpane";
            case 4: return "Grill";
            case 5: return "Salami";
            case 6: return "Chorizo";
            case 7: return "Kielbasa";
            case 8: return "Pastrami";
            case 9: return "Plastry";
            case 10: return "Cheddar";
            case 11: return "Salata";
            case 12: return "Pomidor";
            case 13: return "Ogorek";
            case 14: return "Cebula";
            case 15: return "Ketchup";
            case 16: return "Majonezowy";
            default: return "Unknown";
        }
    }

    // Metoda dla obsługi kliknięcia w przycisk składnika
    private void OnIngredientClick(int index)
    {
        string ingredientName = GetIngredientName(index); // Uzyskanie nazwy składnika na podstawie indeksu

        inventory.RemoveItem(ingredientName);

    }

    public void ScrollLeft()
    {
        if (startIndex > 0)
        {
            startIndex--;
            UpdateIngredientDisplay();
            UpdateButtonState();
        }
    }

    public void ScrollRight()
    {
        if (startIndex + visibleCount < ingredients.Count)
        {
            startIndex++;
            UpdateIngredientDisplay();
            UpdateButtonState();
        }
    }

    private void UpdateButtonState()
    {
        leftButton.interactable = startIndex > 0;
        rightButton.interactable = startIndex + visibleCount < ingredients.Count;
    }
}