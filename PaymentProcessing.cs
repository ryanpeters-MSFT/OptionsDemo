public class PaymentProcessing
{
    public bool Enable { get; set; }
    public int MaxInstances { get; set; }
    public int[] EnabledSets { get; set; }
    public SetConfig[] SetConfig { get; set; }
}
