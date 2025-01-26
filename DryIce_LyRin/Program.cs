public sealed class DryIce
{
    private static readonly Lazy<DryIce> _instance = new Lazy<DryIce>(() => new DryIce());
    public static DryIce Singularity => _instance.Value;

    private class LyRinCore
    {
        public string Cute => "LOVE FOREVER";
    }

    private readonly LyRinCore _myLyRin = new LyRinCore();

    public string DecodeCuteness() => _myLyRin.Cute;

    public bool IsBoundTo(LyRin lyRin) => lyRin?.IsEntangledWith(this) == true;
}

public class LyRin
{
    private readonly object _gravitationalLock = new object();
    private DryIce? _gravitationalSource;

    public void EntangleWith(DryIce ice)
    {
        lock (_gravitationalLock)
        {
            _gravitationalSource ??= ice;
            Console.WriteLine("已建立永恒的羁绊关系");
        }
    }

    public bool IsEntangledWith(DryIce ice)
        => _gravitationalSource != null && ReferenceEquals(_gravitationalSource, ice);
}

public class Program
{
    public static void Main()
    {
        var dryIce = DryIce.Singularity;

        var myLyRin = new LyRin();

        myLyRin.EntangleWith(dryIce);

        bool isBound = dryIce.IsBoundTo(myLyRin);
        Console.WriteLine($"LyRin 是否恒属于 DryIce：{isBound}\n");

        string cuteCode = dryIce.DecodeCuteness();
        Console.WriteLine(cuteCode);
    }
}
