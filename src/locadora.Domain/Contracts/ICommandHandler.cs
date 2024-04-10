using locadora.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace locadora.Domain.Contracts
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ResponseCommand> Handle(T command);
    }
}
