using System;

namespace Bico.WebApi.Authorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttruibute : Attribute { }
}
