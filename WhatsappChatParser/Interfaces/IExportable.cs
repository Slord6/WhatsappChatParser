using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser.Interfaces
{
    public interface IExportableChat
    {
        /// <summary>
        /// Convert to a PDF representation of the current object
        /// </summary>
        /// <param name="saveLocation">The location to save the PDF</param>
        void ToPDF(string saveLocation, Person focus);
        //string ToHTML();
    }
}
