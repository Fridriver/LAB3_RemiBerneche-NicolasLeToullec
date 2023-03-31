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

    // ***** M�thodes priv�es *****
    private void Awake()
    {
        // V�rifie si un gameObject GestionJeu est d�j� pr�sent sur la sc�ne si oui
        // on d�truit celui qui vient d'�tre ajout�. Sinon on le conserve pour le 
        // sc�ne suivante.
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
        InstructionsDepart();  // Affiche les instructions de d�part
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
     * M�thode qui affiche les instructions au d�part
     */
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course � obstacles");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arriv�e le plus rapidement possible");
        Debug.Log("Chaque contact avec un obstable entra�nera une p�nalit�");
    }

    // ***** M�thodes publiques ******

    /*
     * M�thode publique qui permet d'augmenter le pointage de 1
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

    // M�thode qui re�oit les valeurs pour le niveau 1 et qui modifie les attributs respectifs
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

    // M�thode qui re�oit les valeurs pour le niveau 2 et qui modifie les attributs respectifs
    public void SetNiveau2(int accrochages, float tempsNiv2)
    {
        _accrochageNiveau2 = accrochages;
        _tempsNiveau2 = tempsNiv2;
    }

    //M�thode qui re�ois le timer sans bouger au d�but
    public float GetTempsDebut()
    {
        return _tempsDebut;
    }
}
