﻿using SoloTrainGame.GameLogic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

namespace SoloTrainGame.UI
{
    /// <summary>
    /// Global listenable events
    /// </summary>
    public class GUIEvents
    {
        public UnityEvent<CardUIObject> CardClickedEvent;
        public UnityEvent<Vector2> WorldDraggedEvent;
        public UnityEvent<CardInstance> PlayActionEvent;

        private GraphicUserInterface _gui;

        public GUIEvents(GraphicUserInterface gui)
        {
            _gui = gui;

            CardClickedEvent = new UnityEvent<CardUIObject>();

            WorldDraggedEvent = new UnityEvent<Vector2>();
            _gui.WorldDrag.OnDragEvent.AddListener(WorldDragged);

            _gui.Hand.CardClickedEvent.AddListener(CardClicked);

            _gui.CardView.PlayActionEvent?.AddListener(PlayAction);
        }

        ~GUIEvents()
        {
            _gui.Hand.CardClickedEvent.RemoveListener(CardClicked);
            _gui.WorldDrag.OnDragEvent.RemoveListener(WorldDragged);
        }

        private void CardClicked(CardUIObject card)
        {
            if (card != null)
            {
                CardClickedEvent?.Invoke(card);
            }
        }

        private void WorldDragged(Vector2 delta)
        {
            WorldDraggedEvent?.Invoke(delta);
        }

        private void PlayAction(CardInstance card)
        {
            PlayActionEvent?.Invoke(card);
        }

    }

}