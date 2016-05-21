namespace BehavioralInformatix.CallER.Client
{

    public enum CallERProcessStatus : 
        short
    {

        Pending = 0,
        Processing = 1,
        Completed = 2,
        Failed = -1,
        Aborted = -2,

    }

}
