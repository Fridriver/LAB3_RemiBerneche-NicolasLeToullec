using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInstructions : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject _menuInstructions = default;

    public void AfficherInstructions()
    {
        _menuInstructions.SetActive(true);
    }

    public void RetourInstructions()
    {
        _menuInstructions.SetActive(false);
    }
}
