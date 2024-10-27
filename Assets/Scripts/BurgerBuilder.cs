using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgerBuilder : MonoBehaviour
{
    public List<Sprite> ingredientSprites; 
    public GameObject burgerContainer;      
    public GameObject ingredientPrefab;    
    
    public IngredientScroller ingredientScroller;
    
    public List<GameObject> currentIngredients = new List<GameObject>();
    public List<String> currentBurger = new List<String>();
    
    private float offsetY = 15f;  // Odległość w pionie między składnikami
    
    
    public Button acceptButton;
    public Button throwButton;

    private void Start()
    {
        acceptButton.onClick.AddListener(SellBurger);
        throwButton.onClick.AddListener(ThrowBurger);
        ingredientSprites = ingredientScroller.ingredients;
        if (burgerContainer == null)
        {
            Debug.LogError("Brak przypisanego kontenera na składniki burgera!");
        }
    }

    public void AddIngredient(int ingredientIndex, string name)
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
            currentBurger.Add(name);
        }
    }

    public void ResetBurger()
    {
        foreach (var ingredient in currentIngredients)
        {
            Destroy(ingredient);
        }
        currentIngredients.Clear();
        currentBurger.Clear();
    }

    public void ThrowBurger()
    {
        ResetBurger();
        
    }

    public void SellBurger()
    {
        ResetBurger();
        //TO DO GDZIEŚ PRZEKAZAĆ INFO O LIŚCIE NAMÓW
    }
}
