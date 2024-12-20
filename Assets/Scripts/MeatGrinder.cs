using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class MeatGrinder : MonoBehaviour
{
    public GrabingKid player;               // Obiekt Player
    public List<Sprite> itemSprites;        // Lista dostępnych itemów (jako Sprite)
    public GameObject itemPrefab;           // Prefab do wyświetlania sprite'ów
    public GameManager inventory;
    public GameObject output;

    private Animator _animator;
    void Start()
    {
        inventory = GameManager.Instance;
        _animator = GetComponent<Animator>();
        inventory = FindObjectOfType<GameManager>();
        itemSprites = inventory.gameObject.GetComponent<ListOfItem>().itemsSprites;
    }
    public void Grind()
    {
        int childCount = player.childCount;
        _animator.SetTrigger("Grind");
        for (int i = 0; i < childCount; i++)
        {
            
            int itemCount = GetRandomItemCount();

         
            for (int j = 0; j < itemCount; j++)
            {
                int index = Random.Range(1, 9);
                Sprite randomSprite = itemSprites[index];
                Vector2 randomOffset = Random.insideUnitCircle.normalized * Random.Range(0, 2f);
                Vector3 spawnPosition = output.transform.position + (Vector3)randomOffset;

               
                ItemCount help = inventory.Inventory[index];
                help.count++;
                inventory.Inventory[index] = help;
            
                // Rozpoczęcie korutyny do respienia i wygaszania obiektu
                StartCoroutine(SpawnAndFadeItem(spawnPosition, randomSprite));
            }
        }
    }

    // Funkcja losująca liczbę itemów (1, 2 lub 3) na podstawie procentowej szansy
    int GetRandomItemCount()
    {
        float rand = Random.value;
        if (rand <= 0.1f)
            return 3;  // 10% szans na 3 itemy
        else if (rand <= 0.6f)
            return 2;  // 50% szans na 2 itemy
        else
            return 1;  // 100% szans na 1 item
    }

    // Korutyna do tworzenia i znikania sprite'ów
    IEnumerator SpawnAndFadeItem(Vector3 position, Sprite sprite)
    {
        GameObject itemObject = Instantiate(itemPrefab, position + Vector3.up * 2, Quaternion.identity);
        SpriteRenderer spriteRenderer = itemObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        float fadeDuration = 1.5f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
            yield return null;
        }

        Destroy(itemObject);
    }
}
