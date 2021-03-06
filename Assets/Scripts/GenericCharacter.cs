using UnityEngine;
using System.Collections;

public class GenericCharacter : MonoBehaviour
{
    public double health, standardHealth, fireRate;
    public float arrowVelocity;
    protected Vector3 theta, arrowDir;
    protected double currentTime;
    protected GameObject arrow;

    // Shared projectile object pool for all generic characters

    void Start()
    {
        health = standardHealth;
    }

    protected void RePool(GameObject obj)
    {
        //added to fix issues with projectiles being repooled
        if (obj.name.Equals("BasicProjectile"))
        {
            obj.tag = "Untagged";
        }
        ObjectPool.instance.PoolObject(obj);
    }

    protected void fireArrow(string tag)
    {

        arrow = ObjectPool.instance.GetObjectForType("BasicProjectile", true);
        arrow.transform.position = transform.position;
		// transform.eulerAngles = new Vector3(10, yRotation, 0);
		//arrow.transform.rotation = Quaternion.identity;

		arrow.transform.rotation = transform.rotation;

        arrowDir = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.PI / 180), Mathf.Sin(transform.eulerAngles.z * Mathf.PI / 180));
        arrow.GetComponent<Rigidbody2D>().velocity = arrowDir * arrowVelocity;
		//arrow.GetComponent<Rigidbody2D>().AddForce(arrowDir * arrowVelocity);
		//arrow.transform.localEulerAngles = arrowDir;//added
        arrow.tag = tag;
    }

    void OnEnable()
    {
        health = standardHealth;
    }
}