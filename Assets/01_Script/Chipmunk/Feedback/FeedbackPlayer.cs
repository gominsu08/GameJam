using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    [SerializeField] private List<Feedback> _feedbackToPlay;

    private void Awake() {
        _feedbackToPlay = GetComponents<Feedback>().ToList();    
        
    }
    public void PlayFeedbacks()
    {
        StopFeedbacks();
        Debug.Log("피드백 플레이");
        _feedbackToPlay.ForEach(f => f.PlayFeedback());
    }

    public void StopFeedbacks()
    {
        _feedbackToPlay.ForEach(f => f.StopFeedback());
    }

}
