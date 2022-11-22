using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public void DoInteraction()
   {
      // right now have it pick up the object and put in "inventory" (invisible on screen)
      gameObject.SetActive(false);
   }
}
