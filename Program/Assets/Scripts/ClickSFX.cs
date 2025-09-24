using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CkickSFX : MonoBehaviour
{
    public AudioSource SFXSource;
    public AudioClip Click;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SFXSource.PlayOneShot(Click);
        }
    }
}
