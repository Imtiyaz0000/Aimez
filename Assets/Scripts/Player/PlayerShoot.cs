using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    public float rayCastRange = 100f;
    public GameObject shootAudio;

    [SerializeField]
    private LayerMask mask;
    private float audioLength;

    private void Start()
    {
        audioLength = shootAudio.GetComponent<AudioSource>().clip.length;
    }

    public void OnShoot()
    {
        GameObject tempAudio = Instantiate(shootAudio, transform.position, transform.rotation);
        Destroy(tempAudio, audioLength );

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,rayCastRange, mask))
        {
            HittableTarget target = hit.transform.GetComponent<HittableTarget>();
            if (target != null) 
            {
                target.OnHit();
            }
        }
    }
}
