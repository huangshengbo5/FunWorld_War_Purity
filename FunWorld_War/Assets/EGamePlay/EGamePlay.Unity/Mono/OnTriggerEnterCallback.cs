using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using EGamePlay;
using System;

namespace EGamePlay.Combat
{
    public class OnTriggerEnterCallback : MonoBehaviour
    {
        public Action<Collider> OnTriggerEnterCallbackAction;


        private void Start()
        { 
            Log.Error("OnTriggerEnterCallBack.Start!!!");
        }

        void OnTriggerEnter(Collider other) 
        {
            Log.Error("OnTriggerEnterCallBack.OnTriggerEnter!!!");
            //Debug.Log($"OnTriggerEnterCallback OnTriggerEnter {other.name}");
            OnTriggerEnterCallbackAction?.Invoke(other);
        }
        
    }
}