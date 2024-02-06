using System;
using UnityEngine;
using Zenject;

namespace Snake
{
    public class InputHandler : MonoBehaviour
    {
        private FoodController _controller;
        
        [Inject]
        void Init(FoodController foodController)
        {
            _controller = foodController;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _controller.CreateFood("Apple");
            }
        }
    }
}