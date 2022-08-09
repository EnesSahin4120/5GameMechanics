using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] private Transform target;
	[SerializeField] private float distance;
	[SerializeField] private float height;
	[SerializeField] private Vector3 lookOffset;

	private float cameraSpeed = 1000f;
	private float rotSpeed = 100f;

	void Update()   
	{
		Follow();
	}

	private void Follow()
	{
		Vector3 lookPosition = target.position + lookOffset;
		Vector3 relativePos = lookPosition - transform.position;
		Quaternion rot = Quaternion.LookRotation(relativePos);

		transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * rotSpeed * 0.1f);

		Vector3 targetPos = target.transform.position + target.transform.up * height - target.transform.forward * distance;

		transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * cameraSpeed * 0.1f);
	}
}