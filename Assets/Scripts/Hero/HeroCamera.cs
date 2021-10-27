using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCamera : MonoBehaviour
{
	[SerializeField] public Transform target;
	[SerializeField] public CameraProp camStat;
	[SerializeField] public Vector3 offset;
	[SerializeField] public Vector3 correction;
	[SerializeField] public float minZoom;
	[SerializeField] public float maxZoom;
	[SerializeField] public float curZoom;
	private float zoomSpeed;
	private float yawSpeed;
	[SerializeField] public float Yaw;
	[SerializeField] public float followYaw;
	[SerializeField] public float curYaw;
	private float pitch;
    private bool cameraFollow = false; //камера поворачивает за лидером
    private bool cameraStab = false; //отцентрировать камеру при движении, если изменяли поворот
	private bool cameraIsFollow = false;

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
		Yaw = camStat.curYaw;
		curYaw = Yaw;
		followYaw = Yaw;
	}

	void Update()
	{
		CameraUpd();
	}

	private void CameraUpd()
	{
		CameraYaw();
		curZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
		curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
		transform.position = (target.position + correction) - offset * curZoom;
		transform.LookAt((target.position + correction) + Vector3.up * pitch);
		transform.RotateAround((target.position + correction), Vector3.up, curYaw);
	}

	private void CameraYaw()
	{
		curYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

		if(cameraFollow)
		{
			followYaw = target.localEulerAngles.y + Yaw;
		}
		if(cameraStab && cameraFollow)
		{
			float tempYaw = 0;
			if(curYaw > followYaw)
			{
				tempYaw = 0.3f;
				curYaw -= tempYaw * yawSpeed * Time.deltaTime;
			}
			if(curYaw < followYaw)
			{
				tempYaw = -0.3f;
				curYaw -= tempYaw * yawSpeed * Time.deltaTime;
			}
			float differenceYaw = followYaw - curYaw;
			if(differenceYaw > -0.4 && differenceYaw < 0.4)
			{
				cameraStab = false;
				curYaw = followYaw;
			}
		}
		if(cameraStab && !cameraFollow)
		{
			float tempYaw = 0;
			if(curYaw > Yaw)
			{
				tempYaw = 0.3f;
				curYaw -= tempYaw * yawSpeed * Time.deltaTime;
			}
			if(curYaw < Yaw)
			{
				tempYaw = -0.3f;
				curYaw -= tempYaw * yawSpeed * Time.deltaTime;
			}
			float differenceYaw = Yaw - curYaw;
			if(differenceYaw > -0.4 && differenceYaw < 0.4)
			{
				cameraStab = false;
				curYaw = Yaw;
			}
		}
	}

	public void CameraStab()
	{
		cameraStab = true;
	}

	public void CameraFollow(bool followCam)
	{
		cameraFollow = followCam;
		if(followCam)
		{
			cameraIsFollow = true;
			cameraStab = true;
		}
		else
		{
			if(cameraIsFollow)
			{
				cameraIsFollow = false;
				cameraStab = true;
			}
		}
			
	}
}
