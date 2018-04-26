using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draghandler : MonoBehaviour ,IDragHandler,IEndDragHandler {

	// Use this for initialization
	public void OnDrag(PointerEventData AxisEventData){
		transform.position = Input.mousePosition;
	}
	public void OnEndDrag(PointerEventData AxisEventData){
		transform.localPosition = Vector3.zero;
	}
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
