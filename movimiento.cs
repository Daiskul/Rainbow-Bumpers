using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {
	public bool ataco=false;
	public bool saltar=true;
	public float delayatk;
	public bool atacado=false;
	public int golpeado;
	public KeyCode botonSalto;
	public KeyCode botonIzquierda;
	public KeyCode botonDerecha;
	public bool VIVO=true;
	public GameObject respawn;
	public int barravida=100;
	public int vidas=3;
	bool cambiosentido=true;
	public Vector3 der;
	public Vector3 izq;
	public int vel=5;
	public int salto=15;
	public float alcanceRayo = 0.8f;
	public Vector3 direccion = new Vector3(0, -1, 0);
	public ataques ataquejugador;
	public float contnoatk=0;
	public bool moverse=true;
	public string quemandosoy;
	public bool inmune=false;
	
	void Update () {
		
		if (vidas==0){
			VIVO=false;
		}
		if (VIVO==true){
			if (ataco==true){
				ataquejugador.enabled=false;
				delayatk+=1*Time.deltaTime;
			}
			if (delayatk>=0.3f){
				ataquejugador.enabled=true;
				ataco=false;
				delayatk=0;
			}
			if(atacado==false){
				ataquejugador.enabled=true;
			}
			if (atacado==true){
				contnoatk+=Time.deltaTime;	
				ataquejugador.enabled=false;
			}
			if(contnoatk>=0.5){
				atacado=false;
			    contnoatk=0;
			}
			//RESPAWN
			if (barravida<=0){
				vidas-=1;
				barravida=100;
				this.transform.position=respawn.transform.position;
				this.GetComponent<Rigidbody>().velocity =new Vector3 (0,0,0);
				inmune=true;
				ataquejugador.sumaespecial=0;
			}
			//CAMBIO DE SENTIDO
			if (BotIz() &&cambiosentido==false){
				cambiosentido=true;
				this.transform.Rotate(izq);
			}
			if (BotDer()&&cambiosentido==true){
				cambiosentido=false;
				this.transform.Rotate(der);
			}

			//MOVIMIENTO
			if (moverse==true){
				if (BotDer()){
					this.transform.Translate(vel*Time.deltaTime,0,0,Space.World);	
				}
				if (BotIz() ){
					this.transform.Translate(-vel*Time.deltaTime,0,0,Space.World);	
				}
			}
			if (saltar==true){
				if (Input.GetKeyDown(botonSalto)){
					inmune=false;
					RaycastHit resultadoRayo;
					if (Physics.Raycast(this.transform.position, direccion, out resultadoRayo, alcanceRayo)){
						if(resultadoRayo.collider.tag=="suelo"){
							this.GetComponent<Rigidbody>().velocity =new Vector3 (0,salto,0);
						}
						if(resultadoRayo.collider.tag=="thunder"){
							this.GetComponent<Rigidbody>().velocity =new Vector3 (0,salto,0);
						}
				
					}

				}
			}
		}
		if (VIVO==false){
			Destroy(this.gameObject);
		}	
		
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag=="lim"){
			barravida=0;
			this.transform.position=respawn.transform.position;
			this.GetComponent<Rigidbody>().velocity =new Vector3 (0,0,0);
			
		}
		if (other.gameObject.tag!=this.gameObject.tag&&inmune==false){
			if (other.GetComponent<special>() != null)
			{
				barravida-=10;
				atacado=true;
				this.GetComponent<Rigidbody>().velocity += other.transform.forward*golpeado;
			}
		}
	}
	void OnTriggerStay (Collider other){
		if (other.gameObject.tag=="hielo"&&this.gameObject.tag!="j1"&&inmune==false){
			moverse=false;
			if (moverse==false){
			if (BotIz() ){
				this.GetComponent<Rigidbody>().velocity +=new Vector3 (-1,0,0);
			}
			if (BotDer()){
				this.GetComponent<Rigidbody>().velocity +=new Vector3 (1,0,0);
			}
			}
		}
		if (other.gameObject.tag=="fuego"&&this.gameObject.tag!="j2"&&inmune==false){
			barravida-=1;
		}
		if (other.gameObject.tag=="thunder"&&this.gameObject.tag!="j3"&&inmune==false){
			saltar=false;
		}
		if (other.gameObject.tag=="viento"&&this.gameObject.tag!="j4"&&inmune==false){
			this.GetComponent<Rigidbody>().velocity=new Vector3 (5,0,0);
		}
	}
	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag=="suelo"){
			moverse=true;
		}
	}
	bool BotIz()
	{
		if (botonIzquierda != KeyCode.None){
			return Input.GetKey(botonIzquierda);
		}

		return Input.GetAxis("Horizontal"+quemandosoy) < -0.2;		
	}
	bool BotDer()
	{
		if (botonDerecha != KeyCode.None)
			return Input.GetKey(botonDerecha);

		return Input.GetAxis("Horizontal"+quemandosoy) > 0.2;

	}
}
