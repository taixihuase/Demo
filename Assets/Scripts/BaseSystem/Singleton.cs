public class Singleton<T> where T : class, new()
{
    private static T inst;
    private static readonly object syslock = new object();

    public static T Inst
    {
        get
        {
            if (inst == null)
            {
                lock (syslock)
                {
                    if (inst == null)
                    {
                        inst = new T();
                    }
                }
            }
            return inst;
        }
    }
}
