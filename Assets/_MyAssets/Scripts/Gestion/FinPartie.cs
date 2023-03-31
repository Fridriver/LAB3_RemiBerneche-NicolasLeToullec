using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinPartie : MonoBehaviour
{
    // ***** Attributs *****

    //private bool _finPartie = false;  // booléen qui détermine si la partie est terminée
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** Méthode privées  *****
    
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // récupère sur la scène le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // récupère sur la scène le gameObject de type Player
    }

    /*
     * Méthode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  // Si la collision est produite avec le joueur
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du matériel à vert
            //_finPartie = true; // met le booléen à vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // Récupère l'index de la scène en cours

            if (noScene == 2)  // Si nous somme sur la dernière scène (scène 2)
            {
                int accrochages = _gestionJeu.GetPointage();  // Récupère le pointage total dans gestion jeu

                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1

                float _tempsNiveau2 = _gestionJeu.GetTempsNiv2() - _gestionJeu.GetTempsNiv1(); // Calcul le temps pour le niveau 2
                
                int _accrochagesNiveau2 = _gestionJeu.GetAccrochagesNiv2() - _gestionJeu.GetAccrochagesNiv1(); // Calcul le nombre d'accrochages pour le niveau 2

                float tempsTotalniv2 = _tempsNiveau2 + _accrochagesNiveau2; // Calcul le temps total pour le niveau 2

                float _tempsNiveau3 = Time.time - _gestionJeu.GetTempsNiv2(); // Calcul le temps pour le niveau 3
                int _accrochagesNiveau3 = accrochages - _gestionJeu.GetAccrochagesNiv2(); // Calcul le nombre d'accrochages pour le niveau 3
                float tempsTotalniv3 = _tempsNiveau3 + _accrochagesNiveau3; // Calcul le temps total pour le niveau 3

                // Affichage des résultats finaux dans la console
                Debug.Log("Fin de partie !!!!!!!");

                //----------------------------------------------------------
                // Message pour le niveau 1
                if (_gestionJeu.GetTempsDebut() < _gestionJeu.GetTempsNiv1())
                {
                    Debug.Log("Le temps pour le niveau 1 est de : " + (_gestionJeu.GetTempsNiv1() - _gestionJeu.GetTempsDebut()).ToString("f2") + " secondes");
                    Debug.Log("Vous avez accroché au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                    Debug.Log("Temps total niveau 1 : " + (tempsTotalniv1 - _gestionJeu.GetTempsDebut()).ToString("f2") + " secondes");
                }
                else
                {
                    Debug.Log("Le temps pour le niveau 1 est de : " + (_gestionJeu.GetTempsDebut() - _gestionJeu.GetTempsNiv1()).ToString("f2") + " secondes");
                    Debug.Log("Vous avez accroché au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                    Debug.Log("Temps total niveau 1 : " + (_gestionJeu.GetTempsDebut() - tempsTotalniv1).ToString("f2") + " secondes");
                }

                // Message pour le niveau 2
                Debug.Log("Le temps pour le niveau 2 est de : " + _tempsNiveau2.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 2 : " + _accrochagesNiveau2 + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");

                // Message pour le niveau 3
                Debug.Log("Le temps pour le niveau 3 est de : " + _tempsNiveau3.ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _accrochagesNiveau3 + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");

                Debug.Log("Le temps total pour les trois niveau est de : " + ((tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3) - _gestionJeu.GetTempsDebut()).ToString("f2") + " secondes");

                //Debug.Log("Temps sans jouer : " + _gestionJeu.GetTempsDebut().ToString("f2") + " secondes");

                _player.finPartieJoueur();  // Appeler la méthode publique dans Player pour désactiver le joueur
            }
            else if (noScene == 0) // Si nous somme sur la première scène (scène 0)
            {
                // Appelle la méthode publique dans gestion jeu pour conserver les informations du niveau 1
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);

                // Charge la scène suivante
                SceneManager.LoadScene(noScene + 1);            
            }
            else if (noScene == 1) // Si nous somme sur la deuxième scène (scène 1)
            {
                // Appelle la méthode publique dans gestion jeu pour conserver les informations du niveau 2
                _gestionJeu.SetNiveau2(_gestionJeu.GetPointage(), Time.time);

                // Charge la scène suivante
                SceneManager.LoadScene(noScene + 1);
            }
        }
    }
}
