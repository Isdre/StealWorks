using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerBuilder : MonoBehaviour
{
    public List<Sprite> ingredientSprites;  // Lista sprite'ów składników do przypisania w Inspectorze
    public GameObject burgerContainer;      // Referencja do kontenera składników na Canvasie
    public GameObject ingredientPrefab;     // Prefab UI `Image` składnika
    public IngredientScroller ingredientScroller;
    
    private List<GameObject> currentIngredients = new List<GameObject>();
    private float offsetY = 15f;  // Odległość w pionie między składnikami

    private void Start()
    {
        ingredientSprites = ingredientScroller.ingredients;
        if (burgerContainer == null)
        {
            Debug.LogError("Brak przypisanego kontenera na składniki burgera!");
        }
    }

    public void AddIngredient(int ingredientIndex)
    {
        if (ingredientIndex >= 0 && ingredientIndex < ingredientSprites.Count)
        {
            // Tworzenie nowego elementu UI dla składnika
            GameObject newIngredient = Instantiate(ingredientPrefab, burgerContainer.transform);
            newIngredient.GetComponent<Image>().sprite = ingredientSprites[ingredientIndex];

            // Obliczanie pozycji składnika
            float newY = currentIngredients.Count * offsetY;
            newIngredient.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, newY);

            // Dodawanie składnika do listy
            currentIngredients.Add(newIngredient);
        }
    }

    public void ResetBurger()
    {
        foreach (var ingredient in currentIngredients)
        {
            Destroy(ingredient);
        }
        currentIngredients.Clear();
    }
}
