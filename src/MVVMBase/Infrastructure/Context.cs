namespace MVVMBase.Infrastructure;

public static class Context
{
    public static IServices? Services { get; set; }
    public static Action<Action> InvokeOnUiThread = action => { };
}