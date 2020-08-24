using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Domain.Core.Interfaces.Services
{
    public interface IServicePerson : IDisposable, IServiceBase<Person>
    {
    }
}
