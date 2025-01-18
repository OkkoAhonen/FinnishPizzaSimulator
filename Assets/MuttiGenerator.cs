using UnityEngine;

public class MuttiGenerator : MonoBehaviour
{
    public GameObject prefab; // Prefabi, joka spawnataan
    [SerializeField] private bool Dragging; // Kontrolloidaan, onko spawnaus sallittu
    public DragWithKey dragWithKeydragWithKey;
    public LayerMask pizzaLayer; // LayerMask tarkistaa "pizza"-kerroksen
    public bool mouseDown = false;
    public Transform pizzaObject; // Referenssi Pizza-objektiin, johon prefabit lis‰t‰‰n

    void Start()
    {
        dragWithKeydragWithKey = GetComponent<DragWithKey>();
        Dragging = dragWithKeydragWithKey.isDragging;
    }

    void Update()
    {
        // P‰ivitet‰‰n Dragging-arvo joka frame
        Dragging = dragWithKeydragWithKey.isDragging;

        // Tarkistetaan, onko hiiren vasen nappi painettuna
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true; // K‰ynnistet‰‰n hiiren painallus
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false; // Pys‰ytet‰‰n hiiren painallus
        }

        if (mouseDown && Dragging)
        {
            // Tarkista, osuuko hiiri pizza-kerroksen kohdalle ja spawnaa jatkuvasti
            Vector3 spawnPosition;
            if (IsMouseOverPizza(out spawnPosition))
            {
                SpawnPrefab(spawnPosition);
            }
        }
    }

    private void SpawnPrefab(Vector3 position)
    {
        if (prefab != null)
        {
            // Luo uusi prefab hiiren sijaintiin ja lis‰‰ se pizza-objektiin
            GameObject newPrefab = Instantiate(prefab, position, Quaternion.identity);
            if (pizzaObject != null)
            {
                newPrefab.transform.SetParent(pizzaObject); // Asetetaan prefab pizza-objektin lapseksi
            }
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned!");
        }
    }

    private bool IsMouseOverPizza(out Vector3 spawnPosition)
    {
        // Haetaan hiiren sijainti maailmakoordinaateissa
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Suoritetaan Raycast2D ja tarkistetaan osuuko se pizza-kerrokseen
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f, pizzaLayer);

        if (hit.collider != null)
        {
            spawnPosition = mousePosition; // Asetetaan spawnPosition hiiren sijaintiin
            return true;
        }

        spawnPosition = Vector3.zero;
        return false;
    }
}
