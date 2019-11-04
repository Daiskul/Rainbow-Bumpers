using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiosnivel : MonoBehaviour {
	public GameObject[] escenarios;
	public GameObject oldescenario;
	public float tiempodeitems=0;
	public int fases;
	public ataques ataquejugador;
	public GameObject[] items;
	public Vector3[] spawnitems;
	

	public GameObject elItemNuevo;
	
	void Update () {
		if (elItemNuevo == null){
			tiempodeitems+=1*Time.deltaTime;
			if (tiempodeitems>=10){
				tiempodeitems=0;
				elItemNuevo = Instantiate(items[Random.Range(0,items.Length)], spawnitems[Random.Range(0,spawnitems.Length)], this.transform.rotation);
				
			}		
		}
		
	
	}

	public void Cambio (int nuevaFase)
	{
		//Destroy el oldlevel
		if(oldescenario != null)
			Destroy (oldescenario);
		//Cargar newLevel
		oldescenario=Instantiate(escenarios[nuevaFase], escenarios[nuevaFase].transform.position, escenarios[nuevaFase].transform.rotation);
		Destroy(oldescenario,3);
		// escenarios[nuevaFase]
		fases = nuevaFase;

	}
}
