using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerui : MonoBehaviour {
	public ataques elatkj1;
	public ataques elatkj2;
	public movimiento elmovj1;
	public movimiento elmovj2;
	public Image imagej1;
	public Image imagej2;
	public float contj1=1;
	public float contj2=1;
	public Image specialj2;
	public Image specialj1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (elmovj1.barravida==100)
			contj1=1;
		if (elmovj1.barravida==90)
			contj1=0.9f;
		if (elmovj1.barravida==80)
			contj1=0.8f;
		if (elmovj1.barravida==70)
			contj1=0.7f;	
		if (elmovj1.barravida==60)
			contj1=0.6f;
		if (elmovj1.barravida==50)
			contj1=0.5f;	
		if (elmovj1.barravida==40)
			contj1=0.4f;
		if (elmovj1.barravida==30)
			contj1=0.3f;	
		if (elmovj1.barravida==20)
			contj1=0.2f;
		if (elmovj1.barravida==10)
			contj1=0.1f;	
		
		if (elmovj2.barravida==100)
			contj2=1;
		if (elmovj2.barravida==90)
			contj2=0.9f;
		if (elmovj2.barravida==80)
			contj2=0.8f;
		if (elmovj2.barravida==70)
			contj2=0.7f;	
		if (elmovj2.barravida==60)
			contj2=0.6f;
		if (elmovj2.barravida==50)
			contj2=0.5f;	
		if (elmovj2.barravida==40)
			contj2=0.4f;
		if (elmovj2.barravida==30)
			contj2=0.3f;	
		if (elmovj2.barravida==20)
			contj2=0.2f;
		if (elmovj2.barravida==10)
			contj2=0.1f;
		imagej1.fillAmount=contj1;
		imagej2.fillAmount=contj2;

		if (elatkj1.barraespecial==true){
			specialj1.fillAmount=1;
		}
		if (elatkj1.barraespecial==false){
			specialj1.fillAmount=0;
		}
		if (elatkj2.barraespecial==true){
			specialj2.fillAmount=1;
		}
		if (elatkj2.barraespecial==false){
			specialj2.fillAmount=0;
		}
	}
}
