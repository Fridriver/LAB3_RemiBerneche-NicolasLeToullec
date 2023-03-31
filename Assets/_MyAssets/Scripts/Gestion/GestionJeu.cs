using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****

    private float _tempsDebut = 0f;
    private bool _debutPartie = false;

    private int _pointage = 0;  // Attribut qui conserve le nombre d'accrochages

    private int _accrochageNiveau1 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 1
    private float _tempsNiveau1 = 0.0f;  // Attribut qui conserve le temps pour le niveau 1

    private int _accrochageNiveau2 = 0;  // Atribut qui conserve le nombre d'accrochage pour le niveau 2
    private float _tempsNiveau2 = 0.0f;  // Attribut qui conserve le temps pour le niveau 2

    // ***** Méthodes privées *****
    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        InstructionsDepart();  // Affiche les instructions de départ
    }

    private void Update()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;

        if (!_debutPartie && Input.anyKeyDown && noScene == 0)
        {
            _debutPartie = true;
            _tempsDebut += Time.time;
            //Debug.Log("GO : " + _tempsDebut.ToString("f2"));
        }
    }

    /*
     * Méthode qui affiche les instructions au départ
     */
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course à obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entraînera une pénalité");
    }

    // ***** Méthodes publiques ******

    /*
     * Méthode publique qui permet d'augmenter le pointage de 1
     */
    public void AugmenterPointage()
    {
        _pointage++;
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }

    // Accesseur qui retourne le temps pour le niveau 1
    public float GetTempsNiv1()
    {
        return _tempsNiveau1;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 1
    public int GetAccrochagesNiv1()
    {
        return _accrochageNiveau1;
    }

    // Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
    public void SetNiveau1(int accrochages, float tempsNiv1)
    {
        _accrochageNiveau1 = accrochages;
        _tempsNiveau1 = tempsNiv1;
    }

    // ----------------------------------------------------

    // Accesseur qui retourne le temps pour le niveau 2
    public float GetTempsNiv2()
    {
        return _tempsNiveau2;
    }

    // Accesseur qui retourne le nombre d'accrochages pour le niveau 2
    public int GetAccrochagesNiv2()
    {
        return _accrochageNiveau2;
    }

    // Méthode qui reçoit les valeurs pour le niveau 2 et qui modifie les attributs respectifs
    public void SetNiveau2(int accrochages, float tempsNiv2)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv2;
    }

    //Méthode qui reçois le timer sans bouger au début
    public float GetTempsDebut()
    {
        return _tempsDebut;
    }
}
