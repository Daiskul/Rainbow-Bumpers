using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataques : MonoBehaviour {
	public movimiento movimientojug;
	public cambiosnivel cambianivel;
	public KeyCode botonAtaque1;
	public KeyCode botonAtaque2;
	public KeyCode botonEspecial;
	public KeyCode botonEspecial2;
	 public GameObject spawnfist; 
	 public GameObject spawnkick;
	 public float delayatk;
	 public bool barraespecial=false;
	 public GameObject hitbox;
	 public int sumaespecial;
	 public GameObject transicion;
	 public GameObject spawntrans;
	 GameObject nuevosueloj1;
	 GameObject nuevosueloj2;
	 public ataques estescript;


	
	void Update () {
		    //ESPECIAL
			if (sumaespecial>=5){
				barraespecial=true;
			}
			if (this.gameObject.tag!="j1"&&this.gameObject.tag!="j2"){
				if (Input.GetKey(botonEspecial)&&Input.GetKey(botonEspecial2)&&barraespecial==true){
					barraespecial=false;
					sumaespecial=0;
					GameObject nuevatransition = Instantiate(transicion, spawntrans.transform.position, spawnfist.transform.rotation);
					Destroy (nuevatransition, 1);
					if (this.gameObject.tag=="j3"){		
						cambianivel.Cambio(2);
					}
					if (this.gameObject.tag=="j4"){	
						cambianivel.Cambio(3);
					}
				}
			}	
			else{
				if (Input.GetKeyDown(botonEspecial)&&barraespecial==true){
					barraespecial=false;
					sumaespecial=0;
					GameObject nuevatransition = Instantiate(transicion, spawntrans.transform.position, spawnfist.transform.rotation);
					Destroy (nuevatransition, 1);
					if (this.gameObject.tag=="j1"){
						
						cambianivel.Cambio(0);
					}
					if (this.gameObject.tag=="j2"){
						
						cambianivel.Cambio(1);
					}
				}
			}
			//PEGAR
			
			if (movimientojug.ataco==false){
				if (Input.GetKeyDown(botonAtaque1)){
					movimientojug.inmune=false;
					GameObject nuevofist=Instantiate(hitbox,spawnfist.transform.position, spawnfist.transform.rotation);
					nuevofist.GetComponent<special>().elJugCreador=this;
					Destroy(nuevofist,0.1f);
					movimientojug.ataco=true;
				}
				else if (Input.GetKeyDown(botonAtaque2)){
					movimientojug.inmune=false;
					GameObject nuevokick=Instantiate(hitbox,spawnkick.transform.position, spawnkick.transform.rotation);
					nuevokick.GetComponent<special>().elJugCreador=this;
					Destroy(nuevokick,0.1f);
					movimientojug.ataco=true;
				}
			}
	}
}
