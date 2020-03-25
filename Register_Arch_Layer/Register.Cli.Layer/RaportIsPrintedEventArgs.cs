using System;
using Register.Business.Layer.Dto;

namespace Register.Cli.Layer
{
    public class RaportIsPrintedEventArgs : EventArgs
    {
        public RaportDto RaportDto;
    }
}