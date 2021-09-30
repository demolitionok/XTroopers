using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCamera : MonoBehaviour
{
	public Transform target;
	public CameraProp camStat;
	public Vector3 offset;
	public Vector3 correction;
	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;
	public float curZoom;
	public float pitch;
	public float yawSpeed;
	public float curYaw;
	void Start()
	{
		offset = camStat.offset;
		correction = camStat.correction;
		zoomSpeed = camStat.zoomSpeed;
		minZoom = camStat.minZoom;
		maxZoom = camStat.maxZoom;
		curZoom = camStat.curZoom;
		pitch = camStat.pitch;
		yawSpeed = camStat.yawSpeed;
		curYaw = camStat.curYaw;
	}
	void Update()
	{
		curZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
		curYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
		transform.position = (target.position + correction) - offset * curZoom;
		transform.LookAt((target.transform.position + correction) + Vector3.up * pitch);
		transform.RotateAround((target.position + correction), Vector3.up, curYaw);
	}
}
