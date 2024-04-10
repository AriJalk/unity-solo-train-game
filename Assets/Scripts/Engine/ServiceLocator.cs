﻿using Engine.ResourceManagement;
using SoloTrainGame.Core;
using SoloTrainGame.GameLogic;
using SoloTrainGame.UI;
using UnityEngine;

namespace Engine
{
    /// <summary>
    /// Contains all resources that needs global access
    /// </summary>
    public static class ServiceLocator
    {
        private static PrefabManager _prefabManager;
        public static PrefabManager PrefabManager
        {
            get
            {
                if (_prefabManager == null)
                {
                    Debug.LogError("PrefabManager not initialized");
                }
                return _prefabManager;
            }

            private set
            {
                _prefabManager = value;
            }
        }

        static private MaterialManager _materialManager;

        static public MaterialManager MaterialManager
        {
            get
            {
                if (_materialManager == null)
                {
                    Debug.LogError("MaterialManager not initialized");
                }
                return _materialManager;
            }

            private set
            {
                _materialManager = value;
            }
        }



        static public ScriptableObjectManager ScriptableObjectManager { get; }

        static public InputManager InputManager { get; private set; }

        static public TimerManager TimerManager { get; private set; }
        static public GUIServices GUIService {  get; private set; }
        static public StateManager StateManager { get; private set; }
        static public LogicState LogicState { get; private set; }
        static public GameEvents GameEvents { get; private set; }
        static ServiceLocator()
        {
            InputManager = new InputManager();
            TimerManager = new TimerManager();
            ScriptableObjectManager = new ScriptableObjectManager();
            StateManager = new StateManager();
            GameEvents = new GameEvents();
            SetMaterialManager();
        }

        static public void SetPrefabManagerManager(Transform transform)
        {
            _prefabManager = new PrefabManager(transform);
        }

        static public void SetMaterialManager()
        {
            _materialManager = new MaterialManager();
            _materialManager.LoadColorMaterials();
        }

        static public void SetUserInterface(GraphicUserInterface ui)
        {
            GUIService = new GUIServices(ui);
        }

        static public void SetLogicState(LogicState state)
        {
            LogicState = state;
        }
    }
}