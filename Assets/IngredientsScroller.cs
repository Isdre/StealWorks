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

    private int startIndex = 0;
    private int visibleCount = 6; // Liczba widocznych składników

    void Start()
    {
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

    // Metoda dla obsługi kliknięcia w przycisk składnika
    private void OnIngredientClick(int index)
    {
        Debug.Log("Kliknięto składnik: " + index);
        // Tutaj możesz dodać logikę interakcji ze składnikiem, np. wybór składnika, dodanie go do przepisu itd.
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