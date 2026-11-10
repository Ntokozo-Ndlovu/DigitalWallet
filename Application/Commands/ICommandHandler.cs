using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface ICommandHandler<T>
    {
        public Task ExecuteAsync(CancellationToken tk,T cmd);
    }
}
