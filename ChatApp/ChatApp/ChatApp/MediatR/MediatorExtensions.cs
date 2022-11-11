using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatApp.MediatR
{
    public static class MediatorExtensions
    {
        public static bool IsMediatorHandler(this Type arg)
        {
            
            //Ugly hack to limit assembly registration to request handlers only
            return arg.GetInterfaces().Where(i => i.Name.StartsWith("IRequestHandler")).Any();

        }
        public static bool IsPipeline(this Type arg)
        {

            return arg.GetInterfaces().Where(i => i.Name.StartsWith("IPipelineBehavior")).Any();

        }
    }
}
