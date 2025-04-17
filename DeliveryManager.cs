using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public int totalPackages = 6;
    private int deliveredPackages = 0;

    public void PackageDelivered()
    {
        deliveredPackages++;
    }

    public bool AllPackagesDelivered()
    {
        return deliveredPackages >= totalPackages;
    }
}
