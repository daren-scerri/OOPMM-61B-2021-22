using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCannon : MonoBehaviour
{
    Vector3 currentMousePos;
    Quaternion newrotation;

    GameObject mybulletprefab;
    // Start is called before the first frame update
    void Start()
    {
        mybulletprefab = Resources.Load("SmallBullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePos = GameData.GetMousePos();
        newrotation = Quaternion.LookRotation(this.gameObject.transform.position - currentMousePos, Vector3.forward);  //look at the position of the mouse relative to the cannon and rotate around the Z-axis
        newrotation.x = 0f;
        newrotation.y = 0f;
        // research and code Mathf.Clamp to limit the cannon to rotate max Euler 60 and min Euler -60
        newrotation.z = Mathf.Clamp(newrotation.z, -0.4f, +0.4f);
        newrotation.w = Mathf.Clamp(newrotation.w, 0.6f, 0.6f);
        Debug.Log(newrotation);
        this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, newrotation, Time.deltaTime * 3f);
        
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(mybulletprefab, this.transform.position, Quaternion.identity);
        }
    
    }


}

