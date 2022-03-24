using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class Achievement
    {
        public string achievementName;
        public List<AchievementManager.ACTIONS> propertiestoCheck = new List<AchievementManager.ACTIONS>();

        public int achievementStep, achievementSteps;
        public bool isCumulative, isLocked, isCompleted;


        
        

        public Achievement Poll()
        {
            foreach (AchievementManager.ACTIONS propertyToCheck in propertiestoCheck)
            {
                
                if (GameManager.Instance.monitorableProperties[propertyToCheck] && !isCompleted)
                {
                    return this;
                }
            }

            return null;
        }
        
    }