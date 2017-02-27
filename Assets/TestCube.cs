using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour {
    //on stock l'objet transform du gameobject du cube ici. 
    //On peut aussi appeller directement la propriété "transform" hérité de Monobehaviour
    private Transform transformOfMyOwner;

	// Use this for initialization
	void Start () {
        //on récupère au démarage le composant transform de l'objet
        //a noter qu'on peut aussi appeller gameObject.transform (tout les gameobject ayant un transform)
        transformOfMyOwner = GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {
        //on utilise la classe statique Input qui contient les évènement d'Input (souris, clavier, manette, touch...)
        //on récupère l'input d'un touche avec GetKey()
        //on demande le cas de la touche A via l'enum KeyCode
		if(Input.GetKey(KeyCode.A))
        {
            //a l'aide du transform j'appelle la méthode Translate
            //elle possède beaucoup de variante mais je prend le choix de ne lui envoyer qu'un vector3
            //c'est une struct qui défini un vecteur 3 axes (il existe aussi les Vector2, les Vector4, les Quaternion)
            //elle dispose d'une méthode statique up qui renvoie un vecteur pointant vers le haut (0,1,0)
            transformOfMyOwner.Translate(Vector3.up*0.2f);

        }
	}
}
