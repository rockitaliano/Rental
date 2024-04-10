using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}
