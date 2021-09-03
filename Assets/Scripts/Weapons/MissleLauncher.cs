using UnityEngine;

public class MissleLauncher : MonoBehaviour ,IWeapon
{
    [SerializeField] private GameObject rocket;
    [SerializeField] private Transform rocketPosition;
    

    public void OpenFire(Transform target)
    {
        Instantiate(rocket, rocketPosition.position, Quaternion.identity);
        AntiTankRocket activeRocket = rocket.GetComponent<AntiTankRocket>();
        activeRocket.targetForRocket = target;
        activeRocket.launcherIsActive = true;
    }
}
