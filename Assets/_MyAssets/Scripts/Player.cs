using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ***** Attributs *****

    [SerializeField] private Transform _playerFront;

    [SerializeField] private float _vitesse = 800f;  //Vitesse de d�placement du joueur
    private Rigidbody _rb;  // Variable pour emmagasiner le rigidbody du joueur

    public float speed;
    public float rotationSpeed;

    //  ***** M�thodes privées *****

    private void Start()
    {
        // Position initiale du joueur
        transform.position = new Vector3(-45f, 0.3f, -45f);  // place le joueur � sa position initiale 
        _rb = GetComponent<Rigidbody>();  // R�cup�re le rigidbody du Player
    }

    // Ici on utilise FixedUpdate car les mouvements du joueurs implique le déplacement d'un rigidbody
    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    /*
     * M�thode qui gére les déplacements du joueur
     */
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal"); // Récupére la valeur de l'axe horizontal de l'input manager
        float positionZ = Input.GetAxis("Vertical");  // Récupére la valeur de l'axe vertical de l'input manager
        Vector3 direction = new Vector3(positionX, 0f, positionZ);  // Établi la direction du vecteur à appliquer sur le joueur
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;  // Applique la vélocité sur le corps du joueur dans la direction du vecteur

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Fait tourner le playerFront dans la même direction que le joueur
            _playerFront.rotation = Quaternion.LookRotation(direction);
        }

    }

    // ***** M�thodes publiques *****

    /*
     * Méthode appelé en fin de partie qui rend le gameObject Player inactif
     */
    public void finPartieJoueur()
    {
        gameObject.SetActive(false);  // Désactive le gameObject
    }
}
