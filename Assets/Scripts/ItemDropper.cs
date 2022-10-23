using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public string Tag;
    public GameObject ParentObj;
    public int range;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == Tag) 
        {
            ParentObj.SetActive(false);
           int num= Random.Range(0,range);
            RefernceManager.Instance.Particles[num].SetActive(true);
            RefernceManager.Instance.PlayAudio(RefernceManager.Instance.AudioClips[1]);
            switch (num) 
            {
                case 0:
                    AssignText(num);
                    break;
                case 1:
                    AssignText(num);
                    break;
                case 2:
                    RefernceManager.Instance.PlayerController.gameObject.SetActive(false);
                    RefernceManager.Instance.PlayerController.gameObject.transform.position = RefernceManager.Instance.LatestCheckPoint.position;
                    RefernceManager.Instance.PlayerController.gameObject.SetActive(true);
                    break;
            }
        }
    }
    public void AssignText(int index)
    {
        RefernceManager.Instance.MessageText.gameObject.SetActive(true);
        RefernceManager.Instance.MessageText.text = RefernceManager.Instance.Message[index];
        Invoke("CloseTextPopUp",3.0f);
    }
    void CloseTextPopUp() 
    {
        RefernceManager.Instance.MessageText.gameObject.SetActive(false);
    }

    

 
}
