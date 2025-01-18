using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonButtonButton : MonoBehaviour
{
    public GameObject pouta;
    // Start is called before the first frame update
    void Start()
    {
        pouta = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SuljePouta()
    {
        gameObject.SetActive(false);
    }

    private void AvaaUuni()
    {
        gameObject.SetActive(true);
    }

    
}
