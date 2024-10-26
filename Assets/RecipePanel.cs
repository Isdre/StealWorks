using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    // Struktura przechowująca dane przepisu
    [System.Serializable]
    public class Recipe
    {
        public string ingredients; // Lista składników
        public Sprite image;       // Obraz przepisu
    }

    public Recipe[] recipes;    // Lista przepisów (wypełnij w edytorze Unity)
    public TMP_Text ingredientsText;    // Tekst wyświetlający składniki
    public Image recipeImage;       // Obraz przepisu

    public Button leftButton;       // Przycisk nawigacji w lewo
    public Button rightButton;      // Przycisk nawigacji w prawo

    private int currentRecipeIndex = 0; // Indeks aktualnie wyświetlanego przepisu

    void Start()
    {
        // Dodanie funkcji do przycisków
        leftButton.onClick.AddListener(PreviousRecipe);
        rightButton.onClick.AddListener(NextRecipe);

        // Inicjalne wyświetlenie pierwszego przepisu
        ShowRecipe(currentRecipeIndex);
    }

    void ShowRecipe(int index)
    {
        // Upewnij się, że indeks jest prawidłowy
        if (index < 0 || index >= recipes.Length)
            return;

        // Ustaw tekst składników i obraz przepisu
        ingredientsText.text = recipes[index].ingredients;
        recipeImage.sprite = recipes[index].image;
        
        // Uaktualnij widoczność przycisków
        leftButton.interactable = index > 0;
        rightButton.interactable = index < recipes.Length - 1;
    }

    public void NextRecipe()
    {
        if (currentRecipeIndex < recipes.Length - 1)
        {
            currentRecipeIndex++;
            ShowRecipe(currentRecipeIndex);
        }
    }

    public void PreviousRecipe()
    {
        if (currentRecipeIndex > 0)
        {
            currentRecipeIndex--;
            ShowRecipe(currentRecipeIndex);
        }
    }
}

