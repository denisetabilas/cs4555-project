using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationItem : MonoBehaviour
{
    [SerializeField] private Animator myChest;
    [SerializeField] private string Open = "Open";
    [SerializeField] private GameObject item;
    private void OnTriggerEnter(Collider other)
    {
    if (other.CompareTag("Player"))
        {
            myChest.Play(Open, 0, 0.0f);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            item.SetActive(true);
        }
    }
}
