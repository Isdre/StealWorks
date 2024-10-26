using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CourierManager : MonoBehaviour
{
    private bool isCourierActive = false;
    
    public Image order;
    public Order[] orders ;
    public Image[] ordersImages;
    private int currentOrderIndex = 0;
    public TMP_Text timer;
    
    public float timeLimit = 300f; // 5 minut w sekundach
    private float timeRemaining;
    public Color normalColor = Color.white;       // Normalny kolor tekstu
    public Color warningColor = Color.red;        // Kolor ostrzegawczy
    public float pulseSpeed = 2f;
    public Vector3 normalScale = Vector3.one;     // Normalny rozmiar tekstu
    public Vector3 pulseScale = Vector3.one * 1.5f;
    private int helper = 0;
    
    void Start()
    {
        // Rozpocznij proces
        StartCoroutine(SpawnCourier());
        
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
        order.gameObject.SetActive(true);
        for (int i = 0; i < orders.Length; i++)
        {
            ordersImages[i].sprite = orders[i].icon;
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
        if (isCourierActive && currentOrderIndex < orders.Length)
        {
           
            currentOrderIndex++;
            ShowOrder();

            if (currentOrderIndex >= orders.Length)
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
