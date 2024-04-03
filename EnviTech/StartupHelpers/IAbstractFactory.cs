namespace EnviTech.StartupHelpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}