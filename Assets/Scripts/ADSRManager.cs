using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSRManager : MonoBehaviour
{

    [SerializeField] private bool ShowPhases = true;

    [SerializeField] private float Speed = 10.0f;

    [SerializeField] private float AttackDuration = 0.5f;
    [SerializeField] private AnimationCurve Attack;

    [SerializeField] private float DecayDuration = 0.25f;
    [SerializeField] private AnimationCurve Decay;

    [SerializeField] private float SustainDuration = 5.0f;
    [SerializeField] private AnimationCurve Sustain;

    [SerializeField] private float ReleaseDuration = 0.25f;
    [SerializeField] private AnimationCurve Release;

    private string RightInputButton = "Fire1";
    private string LeftInputButton = "Fire2";

    private float AttackTimer;
    private float DecayTimer;
    private float SustainTimer;
    private float ReleaseTimer;

    private float InputDirection = 0.0f;

    private enum Phase { Attack, Decay, Sustain, Release, None};

    private Phase CurrentPhase;

    void Start()
    {
        this.CurrentPhase = Phase.None;
    }

    void Update()
    {
        //Challenge: fix intermixing between presses to Fire1 and Fire2

        if (Input.GetButtonDown(RightInputButton) )
        {
            this.ResetTimers();
            this.CurrentPhase = Phase.Attack;
            this.InputDirection = 1.0f;
        }

        if(Input.GetButton(RightInputButton)) 
        {
            this.InputDirection = 1.0f;
        }

        if (Input.GetButtonUp(RightInputButton))
        {
            this.InputDirection = 1.0f;
            this.CurrentPhase = Phase.Release;
        }

        if (Input.GetButtonDown(LeftInputButton))
        {
            this.ResetTimers();
            this.CurrentPhase = Phase.Attack;
            this.InputDirection = -1.0f;
        }

        if (Input.GetButton(LeftInputButton))
        {
            this.InputDirection = -1.0f;
        }

        if (Input.GetButtonUp(LeftInputButton))
        {
            this.InputDirection = -1.0f;
            this.CurrentPhase = Phase.Release;
        }

        if (this.CurrentPhase != Phase.None)
        {
            var position = this.gameObject.transform.position;
            position.x += this.InputDirection * this.Speed * this.ADSREnvelope() * Time.deltaTime;
            this.gameObject.transform.position = position;
        }

        if (this.ShowPhases)
        {
            this.SetColorByPhase();
        }
    }

    float ADSREnvelope()
    {
        float velocity = 0.0f;

        if(Phase.Attack == this.CurrentPhase)
        {
            velocity = this.Attack.Evaluate(this.AttackTimer / this.AttackDuration);
            this.AttackTimer += Time.deltaTime;
            if(this.AttackTimer > this.AttackDuration)
            {
                this.CurrentPhase = Phase.Decay;
            }
        } 
        else if(Phase.Decay == this.CurrentPhase)
        {
            velocity = this.Decay.Evaluate(this.DecayTimer / this.DecayDuration);
            this.DecayTimer += Time.deltaTime;
            if (this.DecayTimer > this.DecayDuration)
            {
                this.CurrentPhase = Phase.Sustain;
            }
        } 
        else if (Phase.Sustain == this.CurrentPhase)
        {
            velocity = this.Sustain.Evaluate(this.SustainTimer / this.SustainDuration);
            this.SustainTimer += Time.deltaTime;
            if (this.SustainTimer > this.SustainDuration)
            {
                this.CurrentPhase = Phase.Release;
            }
        } 
        else if (Phase.Release == this.CurrentPhase)
        {
            velocity = this.Release.Evaluate(this.ReleaseTimer / this.ReleaseDuration);
            this.ReleaseTimer += Time.deltaTime;
            if (this.ReleaseTimer > this.ReleaseDuration)
            {
                this.CurrentPhase = Phase.None;
            }
        }
        return velocity;
    }

    private void ResetTimers()
    {
        this.AttackTimer = 0.0f;
        this.DecayTimer = 0.0f;
        this.SustainTimer = 0.0f;
        this.ReleaseTimer = 0.0f;
    }

    private void SetColorByPhase()
    {
        var color = Color.white;

        if(Phase.Attack == this.CurrentPhase)
        {
            color = Color.green;
        }
        else if (Phase.Decay == this.CurrentPhase) 
        {
            color = Color.yellow;
        }
        else if (Phase.Sustain == this.CurrentPhase)
        {
            color = Color.blue;
        }
        else if (Phase.Release == this.CurrentPhase)
        {
            color = Color.grey;
        }
        this.gameObject.GetComponent<Renderer>().material.color = color;
    }
}
