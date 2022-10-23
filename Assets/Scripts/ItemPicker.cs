using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public LayerMask ItemMask;
    public Camera cam;
    public float MaxDistance;
    public GameObject NextPoint;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !RefernceManager.Instance.Screens)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, MaxDistance, ItemMask))
            {
                RefernceManager.Instance.PlayerController.enabled = false;
                RefernceManager.Instance.Screens = true;
                RefernceManager.Instance.InventoryPopUp.SetActive(true);
                RefernceManager.Instance.CusorCall();
                hit.transform.gameObject.SetActive(false);
                NextPoint.SetActive(true);
                RefernceManager.Instance.LatestCheckPoint = hit.transform.gameObject.transform;
                RefernceManager.Instance.PlayAudio(RefernceManager.Instance.AudioClips[0]);
            }
        }
    }
}
