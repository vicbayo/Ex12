using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12.Presenters
{
    /// <summary>
    /// Formatea a FormatDataType
    /// </summary>
    /// <typeparam name="FormatDataType"></typeparam>
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
