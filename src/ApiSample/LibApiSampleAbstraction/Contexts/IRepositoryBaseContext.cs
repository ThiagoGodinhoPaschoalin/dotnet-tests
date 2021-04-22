namespace LibApiSampleAbstraction.Contexts
{
    public interface IRepositoryBaseContext<out TContext>
    {
        TContext Context { get; }
    }
}