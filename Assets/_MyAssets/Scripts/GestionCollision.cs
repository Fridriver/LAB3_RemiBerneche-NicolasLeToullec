using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // ***** Attributs *****

    private GestionJeu _gestionJeu;  // Sert � r�cup�rer le l'attribut pointage dans la classe GestionJeu
    private bool _touche;  // Bool�en qui permet de d�tecter si l'objet a �t� touch�

    private Color _texture;

    private float time = 0;

    // ***** M�thodes priv�es *****
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // lie la variable au gameObject GestionJeu de la sc�ne
        _touche = false;  // initialise le bool�en � faux au d�but de la sc�ne
    }

    /* 
     * R�le : M�thode qui se d�clenche quand une collision se produit avec l'objet
     * Entr�e : un objet de type Collision qui repr�sente l'objet avec qui la collision s'est produite
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_touche)  // Si l'objet avec la collision s'est produite est le joueur et qu'il n'a pas d�j� et touch�
        {
            _texture = gameObject.GetComponent<MeshRenderer>().material.color;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;  //change la couleur du mat�riel � rouge
            
            _gestionJeu.AugmenterPointage();  // Appelle la m�thode publique dans GestionJeu pour augmenter le pointage
            _touche = true;  // change le bool�en � vrai pour indiqu� que l'objet a �t� touch�
        }
    }
    //Coroutine wait 4 seconds
    IEnumerator WaitColor(GameObject e)
    {
        yield return new WaitForSeconds(4);
        e.GetComponent<MeshRenderer>().material.color= _texture;
        _touche = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")  // Si l'objet avec la collision s'est produite est le joueur et qu'il n'a pas d�j� et touch�
        {
            StartCoroutine(WaitColor(gameObject));
            // gameObject.GetComponent<MeshRenderer>().material.color = _texture;  //change la couleur du mat�riel � rouge
            //_touche = false;  // change le bool�en � vrai pour indiqu� que l'objet a �t� touch�
        }
    }
}
