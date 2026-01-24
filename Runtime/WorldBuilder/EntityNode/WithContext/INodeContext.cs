using System;

namespace BusinessLogic.WorldBuilder.EntityNode
{
    public interface INodeContext
    {
        public bool Verify(Func<string, string> formatter);
    }
}