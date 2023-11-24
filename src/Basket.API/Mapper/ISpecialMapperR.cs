namespace Basket.API.Mapper
{
    public interface ISpecialMapperR
    {
        public TDest MapProperties<TSource, TDest>(TSource source, TDest destination);

    }
}

