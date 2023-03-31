using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePiege : MonoBehaviour
{
    // ***** Atributs *****
     
    private bool _estActive = false;  // booléen qui permet de valider si la zone piège a été activée
    [SerializeField] private List<GameObject> _listePieges = new List<GameObject>();  // Liste de gameObjects qui contient tous les gameObjects à déclencher
    private List<Rigidbody> _listeRb = new List<Rigidbody>(); // Liste de rigidbody qui va contenir tous les rigidbody des gameObjects de la liste précédente
    [SerializeField] private float _intensiteForce = 200;  // Intensité de la force à appliquer sur les gameObjects

    // ***** Méthode privées ****
    
    private void Awake()
    {
        // Pour chacun des gameObjects définis je récupère son rigidbory
        // et l'ajoute à la liste contenant ceux-ci
        foreach(var piege in _listePieges)
        {
            _listeRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    /*
     * Méthode qui est appelée quand un object entre dans la zone
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_estActive)  // Si c'est le joueur qui est entré dans la zone et qu'elle n'a pas été activée
        {
            // Pour chacun des RB dans la liste j'active leur gravité
            // et leur applique une force vers le bas
            foreach(var rb in _listeRb)
            {
                rb.useGravity = true;  //active la gravité sur le rigidbody
                Vector3 direction = new Vector3(0f, -1f, 0f); // Établi la direction de la force
                rb.AddForce(direction * _intensiteForce); // Applique la force sur le rigidbody
            }
            _estActive = true;  // Marque la zone comme activée
        }
    }
}
