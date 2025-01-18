using UnityEngine;

public class DragWithKey : MonoBehaviour
{
    private bool isDragging = false; // Tila, onko vet‰minen k‰ynniss‰
    private Vector3 offset; // Et‰isyys objektin ja hiiren v‰lill‰
    private bool isMouseOver = false; // Onko hiiri objektin p‰‰ll‰

    void Update()
    {
        // Tarkista, painetaanko E-n‰pp‰int‰
        if (Input.GetKeyDown(KeyCode.E) && isMouseOver)
        {
            // Vaihda vetotila vain, jos hiiri on objektin p‰‰ll‰
            if (!isDragging)
            {
                StartDragging();
            }
            else
            {
                StopDragging();
            }
        }

        // Jos vet‰minen on k‰ynniss‰, seuraa hiirt‰
        if (isDragging)
        {
            DragObject();
        }
    }

    private void StartDragging()
    {
        // Lasketaan et‰isyys objektin ja hiiren v‰lill‰
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private void DragObject()
    {
        // P‰ivitet‰‰n objektin sijainti hiiren mukaan
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Haetaan hiiren sijainti maailmakoordinaateissa
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // S‰‰det‰‰n syvyys
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }

    // Kun hiiri osuu objektin collideriin
    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    // Kun hiiri poistuu objektin colliderista
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}
