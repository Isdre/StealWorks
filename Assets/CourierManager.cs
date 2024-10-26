using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourierManager : MonoBehaviour
{
    private bool isCourierActive = false;
    
    public RecipePanel recipePanel;
    public RecipePanel.Recipe[] allRecipes;
    public Transform ordersContainer;
   
    public TMP_Text timer;
    
    public float timeLimit = 300f; // 5 minut w sekundach
    private float timeRemaining;
    public Color normalColor = Color.white;       // Normalny kolor tekstu
    public Color warningColor = Color.red;        // Kolor ostrzegawczy
    public Vector3 normalScale = Vector3.one;     // Normalny rozmiar tekstu
    public Vector3 pulseScale = Vector3.one * 1.5f;
    
    public int numberOfOrders = 3;
    
    
    
    private int currentOrderIndex = 0;
    private List<RecipePanel.Recipe> orders;      
    private List<Image> ordersImages;  
    private int helper = 0;
    
    void Start()
    {
        allRecipes = recipePanel.recipes;
        orders = new List<RecipePanel.Recipe>();  // Inicjalizacja listy zamówień
        ordersImages = new List<Image>();         // Inicjalizacja listy obrazków
        RandomizeOrders();    
        // Rozpocznij proces
        StartCoroutine(SpawnCourier());
        
    }
    private void RandomizeOrders()
    {
        // Losowanie przepisów z listy wszystkich dostępnych przepisów
        List<RecipePanel.Recipe> shuffledRecipes = new List<RecipePanel.Recipe>(allRecipes);
        shuffledRecipes.Shuffle(); // Wykonaj losowanie (dodamy metodę rozszerzającą poniżej)
        
        // Pobierz tylko pierwsze kilka przepisów, np. 10, lub do maksymalnej liczby przepisów
        int orderCount = Mathf.Min(shuffledRecipes.Count, numberOfOrders);
        orders = shuffledRecipes.GetRange(0, orderCount);
    }
    private IEnumerator SpawnCourier()
    {
        yield return new WaitForSeconds(1f); // Czas oczekiwania przed pojawieniem się kuriera
        isCourierActive = true;
        timeRemaining = timeLimit;
        ShowOrder();
        UpdateTimerUI();
        StartCoroutine(CountdownTimer());
    }

    private void ShowOrder()
    {
       
        // Usuń stare obrazki składników
        foreach (Image img in ordersImages)
        {
            Destroy(img.gameObject);
        }
        ordersImages.Clear();
       
        // Dodaj nowe obrazki składników dla aktualnego przepisu
        foreach (var ingredient in  orders)
        {
            Image newImage = new GameObject("OrderImage", typeof(Image)).GetComponent<Image>();
            newImage.sprite = ingredient.image; // ustaw sprite dla składnika
            newImage.transform.SetParent(ordersContainer, false); // przypnij do kontenera z layoutem
            ordersImages.Add(newImage);
        }
    }

    private IEnumerator CountdownTimer()
    {
        while (timeRemaining > 0 && isCourierActive)
        {   
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            UpdateTimerUI();
        }
        if (timeRemaining <= 0)
        {
            EndCourierSession();
        }
    }
    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60); // Minuty
        int seconds = Mathf.FloorToInt(timeRemaining % 60); // Sekundy
        timer.text = $"{minutes:00}:{seconds:00}"; // Format 00:00
        if (timeRemaining <= 15)
        {

            StartCoroutine(PulsingText());

        }
      
    }

    private IEnumerator PulsingText()
    {
        
        while (timeRemaining > 0 && timeRemaining <=15)
        {   
            
            

            if (helper%2==0)
            {
                timer.color = warningColor;
                timer.transform.localScale = pulseScale;
            }

            if (helper%2== 1)
            {
                timer.color=normalColor;
                timer.transform.localScale = normalScale;
            }
            helper++;
            yield return new WaitForSeconds(0.5f);
        }
        if (timeRemaining <= 0)
        {
            StopCoroutine(PulsingText());
        }
        
        
    }


    public void DeliverOrder()
    {
        if (isCourierActive && currentOrderIndex < orders.Count)
        {
           
            currentOrderIndex++;
            ShowOrder();

            if (currentOrderIndex >= orders.Count)
            {
                EndCourierSession();
            }
        }
    }

    private void EndCourierSession()
    {
        isCourierActive = false;
        // Możesz dodać więcej logiki tutaj, np. wywołać inne metody, wyświetlić wyniki itp.
    }
}
public static class ListExtensions
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1) 
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}