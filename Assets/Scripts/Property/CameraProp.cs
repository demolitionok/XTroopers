using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraProp : ScriptableObject
{
	public Vector3 offset;
	public Vector3 correction;
	public float zoomSpeed;
	public float minZoom;
	public float maxZoom;
	public float curZoom;
	public float pitch;
	public float yawSpeed;
	public float curYaw;
}
