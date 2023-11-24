using System.Reflection;

namespace Basket.API.Mapper
{
    public class SpecialMapper : ISpecialMapperR
    {
        public TDest MapProperties<TSource, TDest>(TSource source, TDest destination)
        {
            PropertyInfo[] sourceProps = source.GetType().GetProperties();
            PropertyInfo[] destProps = destination.GetType().GetProperties();

            foreach (var sourceProp in sourceProps)
            {
                var matchingDestProp = destProps.FirstOrDefault(p => p.Name == sourceProp.Name);

                if (matchingDestProp != null)
                {
                    object value = sourceProp.GetValue(source);
                    matchingDestProp.SetValue(destination, value);
                }
            }

            return destination;
        }
    }
}
