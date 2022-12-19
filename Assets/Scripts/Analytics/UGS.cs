using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
public class UGS : MonoBehaviour
{
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            LevelCompletedCustomEvent();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }
    private void LevelCompletedCustomEvent()
    {
        int currentLevel = Random.Range(1, 4); //Gets a random number from 1-3
                                               //Define Custom Parameters
        Dictionary<string, object> parameters = new Dictionary<string, object>()
       {
           { "levelName", "level" + currentLevel.ToString()}
       };

        // The ‘levelCompleted’ event will get cached locally 
        //and sent during the next scheduled upload, within 1 minute
        AnalyticsService.Instance.CustomData("levelCompleted", parameters);
        // You can call Events.Flush() to send the event immediately
        AnalyticsService.Instance.Flush();
    }
}