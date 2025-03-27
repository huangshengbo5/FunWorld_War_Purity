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

        void OnTriggerEnter(Collider other) 
        {
            Log.Debug("OnTriggerEnterCallBack.OnTriggerEnter!!!");
            OnTriggerEnterCallbackAction?.Invoke(other);
        }
    }
}