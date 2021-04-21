namespace LibApiSampleAbstraction.Contexts
{
    public interface IBaseContext<out TContext>
    {
        TContext Context { get; }

        void BeginTransaction();
        void RoolbackTransaction();
        int CommitTransaction();
    }
}