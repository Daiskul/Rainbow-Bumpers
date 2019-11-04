using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class special : MonoBehaviour {

	public ataques elJugCreador;
	public movimiento elmov;
	


	// Use this for initialization
	void OnTriggerEnter(Collider other){
		movimiento sumov = other.gameObject.GetComponent<movimiento>();
		if (other.gameObject.tag!=elJugCreador.gameObject.tag && other.gameObject.tag!="suelo"&&sumov.inmune==false){
			//contespecial+=1;
			elJugCreador.sumaespecial++;
		
		}
		
	}
	
	// Update is called once per frame
	void Update () {
			
		this.gameObject.tag=elJugCreador.gameObject.tag;
	}
}
