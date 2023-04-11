using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _player = default;
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private bool _enPause;
    private GestionJeu _gestionJeu;
    //private Player player;

    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text = "Accrochages : " + _gestionJeu.GetPointage();
        Time.timeScale = 1;
        _enPause = false;
    }


    private void Update()
    {
        float temps = _gestionJeu.GetTempsDebut();

        _txtTemps.text = "Temps : " + (Time.time - temps + _gestionJeu.GetTempsNiv1() + _gestionJeu.GetTempsNiv2()).ToString("f2");
        if (_player.transform.position == new Vector3(-45f, 0.3f, -45f))
        {
            _gestionJeu.TempsSansBouger = Time.time;
        }
            if (_player.transform.position != new Vector3(-45f, 0.3f, -45f))
        {
            _txtTemps.text = "Temps : " + (temps - _gestionJeu.TempsSansBouger + _gestionJeu.GetTempsNiv1() + _gestionJeu.GetTempsNiv2()).ToString("f2");
        }

        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }
}
