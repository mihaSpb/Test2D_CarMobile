using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Game.InputLogic
{
    internal class InputArrows : BaseInputView
    {
        [SerializeField] private float _inputMultiplier = 25f;
        float dir = 0;
        private Button leftButton;
        private Button rightButton;

        private void Start() =>
            UpdateManager.SubscribeToUpdate(Move);

        private void OnDestroy() =>
           UpdateManager.UnsubscribeFromUpdate(Move);

        private void LoadPrefab()
        {
            ResourcePath _resourcePath = new ResourcePath("Prefabs/ArrowsInput");
            Transform placeForUi = GameObject.Find("PlaceForUi").transform;
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            Object.Instantiate(prefab, placeForUi, false);
        }

        private void InitButtons()
        {
            leftButton = GameObject.Find("LeftArrow").GetComponent<Button>();
            rightButton = GameObject.Find("RightArrow").GetComponent<Button>();
        }


        private void Move()
        {
            float moveValue = _speed  * _inputMultiplier * Time.deltaTime;

            float abs = Mathf.Abs(moveValue);
            float sign = Mathf.Sign(moveValue);

            if (sign > 0)
                OnRightMove(abs);
            else if (sign < 0)
                OnLeftMove(abs);
        }


    }
}
