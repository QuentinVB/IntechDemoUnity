using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Cette classe détermine le comportement du vaisseau. 
/// Héritant de MonoBehaviour, il dispose de 2 méthodes Start() et Update() gérant son initialisation et son actualisation.
/// </summary>
public class ShipBehaviour : MonoBehaviour {
    
    private bool stillAlive;
    private float speed;
    private Object laserPrefab;
    private float limiter;
    
    // Use this for initialization
    void Start ()
    {
        //initialisation des divers paramètres
        speed = 0.2f;
        limiter = 8.0f;
        stillAlive = true;
        //on charge le Prefab du laser pour pouvoir l'appeller à la volé et instancier les laser
        laserPrefab = Resources.Load("Laser");
    }
	
	// Update is called once per frame
	void Update () {
        //on met a jour le mouvement
        movement(stillAlive);
        //on tire 
        fire(stillAlive);
	}
    /// <summary>
    /// permet de tirer, tant que still alive est actif
    /// </summary>
    /// <param name="stillAlive">if set to <c>true</c> [still alive].</param>
    private void fire(bool stillAlive)
    {
        if (stillAlive == true)
        {
            //on tire si l'utilisateur à appuyé sur la touche espace
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //on instancie le laser, on le positionne sur l'objet vide "canon" (le premier enfant du transform du vaisseau), on l'oriente grace à un Quaternion
                Instantiate(laserPrefab, transform.GetChild(0).position, Quaternion.Euler(90, 0, 0));        
            }
        }
    }
    /// <summary>
    /// permet de bouger, tant que still alive est actif
    /// </summary>
    /// <param name="stillAlive">if set to <c>true</c> [still alive].</param>
    private void movement(bool stillAlive)
    {
        Vector3 currentPosition = transform.position;
        Vector3 futurPosition;

        if(stillAlive==true)
        {
            //si l'utlisateur appuye sur la touche de gauche
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                //on crée un nouveau vecteur3 de position du vaisseau d'après la current position - 1 * la vitesse/
                //la valeur est "clampé" (tronqué) pour éviter qu'elle ne dépasse les limite et sorte du champs camera
                futurPosition = new Vector3(
                                 Mathf.Clamp(currentPosition.x - 1.0f * speed, - limiter ,limiter),
                                 0, 
                                 0);
                //on envoie la nouvelle position au transform du vaisseau
                transform.position = futurPosition;
            }
            //idem mais on oriente la position dans l'autre sens (+)
            if (Input.GetKey(KeyCode.RightArrow))
            {
                futurPosition = new Vector3(Mathf.Clamp(currentPosition.x + 1.0f * speed, -limiter, limiter), 0, 0);
                transform.position = futurPosition;
            }            
        }
    }
    /// <summary>
    /// Evenement de collision, si le moteur de jeu unity détecte une collision entre le collider du vaisseau et un autre il appelle cette méthode (ou pas, si rien n'est défini)
    /// A noter qu'il existe OnTriggerEnter, OnTriggerActive, OnTriggerLeave
    /// Le collider de paramètre envoyé correspond au collider de l'autre objet.
    /// </summary>
    /// <param name="other">The other.</param>
    private void OnTriggerEnter(Collider other)
    {
        //on appelle le tag du gameobject du collider ayant collisionné
        if (other.gameObject.tag=="Plasma")
        {
            stillAlive = false;
            Debug.Log("HIT !");
            //on appelle une des méthodes de MonoBehaviour Destroy et on lui dit de détruire le gameobject auquel la classe est attaché
            Destroy(gameObject);
            //call the MOTHERFUCKING MICHAELBAY XPLOSION (and the you loose message... and restart)
            //Heuuu j'ai un peu fumé la moquette, pas la foi de gérer l'explosion. A la place on reload la scène :p
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
