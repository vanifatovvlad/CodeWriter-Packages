﻿using System;
using UniMob;
using UnityEngine.UI;

namespace Sample
{
    using UnityEngine;

    public class SampleCounter : MonoBehaviour
    {
        [SerializeField] private Text counterText = default;
        [SerializeField] private Button incrementButton = default;

        [Atom] private int Counter { get; set; } = 0;

        private IDisposable _render;

        private void OnEnable()
        {
            _render = Atom.Reaction("SampleCounter.Render()", Render);

            incrementButton.onClick.AddListener(Increment);
        }

        private void OnDisable()
        {
            _render.Dispose();

            incrementButton.onClick.RemoveListener(Increment);
        }

        private void Render()
        {
            counterText.text = $"Count: {Counter}";
        }

        private void Increment()
        {
            Counter++;
        }
    }
}