using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private Vector2 aimSensitivity;
    private float xAngle;
    private Vector2 aimInput;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Rotacion en la horizontal (el player rota)
        transform.Rotate(0, aimInput.x * aimSensitivity.x * Time.deltaTime, 0);

        //Rotacion en la vetical (La camara rota)
        xAngle = Mathf.Clamp(xAngle - aimInput.y * aimSensitivity.y * Time.deltaTime, -90, 90);
        transform.GetChild(0).localEulerAngles = new Vector3 (xAngle, 0, 0);
    }

    // Capturar donde apunta
    private void OnAim(InputValue value)
    {
        aimInput = value.Get<Vector2>();
    }

    // Disparar
    private void OnShoot(InputValue value)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.GetChild(0).position, transform.GetChild(0).forward, out hit))
        {
            if (hit.collider.CompareTag("Alien"))
            {
                hit.transform.gameObject.GetComponentInParent<EnemyMovement>().ReceiveHit();
                if (hit.transform.gameObject.GetComponentInParent<EnemyMovement>().hits >= 2)
                {
                    StartCoroutine(alienDeath(hit));
                }
            }
        }
    }

    //Corrutina para morir el Alien
    private IEnumerator alienDeath(RaycastHit shooted)
    {
        shooted.transform.gameObject.GetComponentInParent<EnemyMovement>().Die(true);

        yield return new WaitForSeconds(3);
        Destroy(shooted.collider.gameObject.transform.root.gameObject);
    }
}
