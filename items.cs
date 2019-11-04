using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour {
	public Vector3 lejos;
	public string loQueSoy = "Salto+";
	public float contvel=0;
	public float contsalt=0;
	public GameObject eljugador;
	public float duracionitem=3;

	void Update(){
		if (eljugador==null){}
		else{
			if (this.gameObject.transform.position==lejos){
				if (loQueSoy=="Salto+"){
					contsalt+=1*Time.deltaTime;
					if (contsalt>=duracionitem){
						eljugador.GetComponent<movimiento>().salto=15;
						contsalt=0;
						Destroy(this.gameObject);
					}
				}
				if (loQueSoy=="Vel+"){
					contvel+=1*Time.deltaTime;
					if (contvel>=duracionitem){
						eljugador.GetComponent<movimiento>().vel=5;
						contvel=0;
						Destroy(this.gameObject);
					}
				}
				if (loQueSoy=="Vel-"){
					contvel+=1*Time.deltaTime;
					if (contvel>=duracionitem){
						eljugador.GetComponent<movimiento>().vel=5;
						contvel=0;
						Destroy(this.gameObject);
					}
				}
			}
		}
	}
	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag!="suelo"){
			eljugador= other.gameObject;
			if (loQueSoy == "Salto+")
			{
				this.transform.position=lejos;
				eljugador.GetComponent<movimiento>().salto=23;
			}
			if (loQueSoy == "Vel+")
			{
				this.transform.position=lejos;
				eljugador.GetComponent<movimiento>().vel=8;
			}
			if (loQueSoy == "Special+")
			{
				eljugador.GetComponent<ataques>().sumaespecial=5;
				Destroy(this.gameObject);
			}
			if (loQueSoy == "Vel-")
			{
				this.transform.position=lejos;
				eljugador.GetComponent<movimiento>().vel=3;
			}
			if (loQueSoy == "Special-")
			{
				eljugador.GetComponent<ataques>().sumaespecial=0;
				Destroy(this.gameObject);
			}
		}
	}
}
