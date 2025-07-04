﻿namespace TurnBasedHexEngine.StateMachine
{
	/// <summary>
	/// Manages the StateMachine flow
	/// </summary>
	public class StateMachineManager
	{
		public IStateMachine CurrentState {  get; private set; }

		public StateMachineManager()
		{
			
		}

		public void NextState(IStateMachine nextState)
		{
			if (CurrentState != null)
			{
				CurrentState.ExitState();
			}
			nextState.EnterState();
			CurrentState = nextState;
		}

	}
}
