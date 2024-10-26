using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourierManager : MonoBehaviour
{

    public Image order;
    public float timeLimit = 300f; // 5 minut w sekundach
    private float timeRemaining;
    private bool isCourierActive = false;

    // Możesz dostosować tę tablicę do swoich zamówień
    public Order[] orders ;
    public Image[] ordersImages;
    private int currentOrderIndex = 0;

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
        }
        if (timeRemaining <= 0)
        {
            EndCourierSession();
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
