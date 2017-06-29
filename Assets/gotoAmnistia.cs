using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoAmnistia : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToAmnistia ()
	{
		Application.OpenURL ("http://www.amnistia.pt/index.php/o-que-fazemos/as-nossas-campanhas/refugiados");
	}
    public void GoToMainM()
    {
        SceneManager.LoadScene(0);
    }
}
