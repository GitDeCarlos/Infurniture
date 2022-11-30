using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AbstractLayoutGenerator), true)]

public class ProcGeneration : Editor
{
   AbstractLayoutGenerator generator;

   private void Awake()
   {
      generator = (AbstractLayoutGenerator)target;
   }

   public override void OnInspectorGUI()
   {
      base.OnInspectorGUI();

      if(GUILayout.Button("Create Dungeon"))
      {
         generator.GenerateLayout();
      }
   }
}
