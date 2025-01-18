using UnityEngine;

public class MuttiGenerator : MonoBehaviour
{
    public GameObject prefab; // Prefabi, joka spawnataan
    [SerializeField] private bool Dragging; // Kontrolloidaan, onko spawnaus sallittu
    public DragWithKey dragWithKeydragWithKey;
    public LayerMask pizzaLayer; // LayerMask tarkistaa "pizza"-kerroksen
    public bool mouseDown = false;

    void Start()
    {
        dragWithKeydragWithKey = GetComponent<DragWithKey>();
        Dragging = dragWithKeydragWithKey.isDragging;
    }

    void Update()
    {
        // Tarkistetaan, onko hiiren vasen nappi painettuna
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true; // K‰ynnistet‰‰n hiiren painallus
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false; // Pys‰ytet‰‰n hiiren painallus
        }

        Dragging = dragWithKeydragWithKey.isDragging;

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
            // Luo uusi prefab hiiren sijaintiin
            Instantiate(prefab, position, Quaternion.identity);
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
