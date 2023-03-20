using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();

            //for overload methods
            var methodAttributes = type.GetMethod(method.Name, method.GetParameters()
                .Select(p => p.ParameterType).ToArray())
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);


            if (methodAttributes != null)
                classAttributes.AddRange(methodAttributes);
            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)); //butun metotlara ekler.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}