using UnityEngine;
using UnityEngine.UI;

public class PizzaDrag : MonoBehaviour
{
    public Button startDragButton; // UI-nappi, joka sallii pizzan liikkumisen
    private bool canDrag = false; // Onko pizza valmis liikutettavaksi
    private bool isDragging = false; // Onko pizzaa juuri nyt liikutettu
    private Vector3 offset;

    private void Start()
    {
        startDragButton.onClick.AddListener(EnableDrag); // Liitet‰‰n nappiin toiminto
    }

    private void Update()
    {
        if (canDrag && Input.GetKeyDown(KeyCode.E)) // Aktivoi liikuttaminen E-n‰pp‰imell‰
        {
            if (!isDragging)
                StartDragging();
            else
                StopDragging();
        }

        if (isDragging)
            DragPizza();
    }

    private void EnableDrag()
    {
        canDrag = true; // Sallitaan pizzan liikuttaminen
    }

    private void StartDragging()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private void DragPizza()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
