using UnityEngine;

namespace RPG.Core
{ 
    public class ActionSchedule : MonoBehaviour 
    {
        IAction currentAction;
        public void StartAction(IAction action)
        {
            if(action == currentAction) return;
            if(currentAction != null) 
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
    }
}