using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace DevFramework.Core.Aspects.PostSharp.LogAspects
{
    [Serializable]
    //Bu kod sadece : nesne instanceslerinin örneklerinin methodlarına uygula hiçbir şekilde ctor'a uygulama
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);

        }
    }
}