using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffichageFinal : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtTempsTotal = default;
    [SerializeField] private TMP_Text _txtAccorchagesTotal = default;
    [SerializeField] private TMP_Text _txtPointageTotal = default;
    private GestionJeu _gestionJeu;

    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtTempsTotal.text = (Time.time-_gestionJeu.GetTempsDebut()).ToString("f2") + " sec.";
        _txtAccorchagesTotal.text = _gestionJeu.GetPointage().ToString();
        float pointageTotal = _gestionJeu.GetTempsFinal() + _gestionJeu.GetPointage();
        _txtPointageTotal.text = ((Time.time-_gestionJeu.GetTempsDebut()) + pointageTotal).ToString("f2") + " sec.";
    }
}
