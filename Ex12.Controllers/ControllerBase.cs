using Ex12.UseCasesPort.ProyectosPort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Controllers
{
    public class ControllerBase<IInputPort, IOutputPort>
    {
        protected readonly IInputPort _inputPort;
        protected readonly IOutputPort _outputPort;

        public ControllerBase(IInputPort inputPort, IOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }
    }
}
