using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage=false;
    [SerializeField] float destroyTime=0.5f;
    [SerializeField] Color32 hasPackageColor=new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor=new Color32 (1,1,1,1);

    public DeliveryManager deliveryManager;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!!");
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyTime);
            hasPackage=true;
            
        }
        else if(other.tag=="Customer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            deliveryManager.PackageDelivered();


            hasPackage=false;
            spriteRenderer.color = noPackageColor;
        }
        
        
    }
}
