using UnityEngine;

public class CursorModeController : MonoBehaviour
{
	[SerializeField] private CursorLockMode enableCursorLockMode = CursorLockMode.None;
	[SerializeField] private CursorLockMode disableCursorLockMode = CursorLockMode.Locked;

	private void OnEnable()
	{
		Cursor.lockState = enableCursorLockMode;
	}

	private void OnDisable()
	{
		Cursor.lockState = disableCursorLockMode;
	}
}