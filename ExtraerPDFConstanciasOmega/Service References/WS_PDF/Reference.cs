﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExtraerPDFConstanciasOmega.WS_PDF
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "TipoPDF", Namespace = "http://tempuri.org/")]
    public enum TipoPDF : int
    {
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Acreditado = 0,

        [System.Runtime.Serialization.EnumMemberAttribute()]
        Coacreditado = 1,
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Archivo", Namespace = "http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Archivo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] DatosField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MsjErrorField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public byte[] Datos
        {
            get
            {
                return this.DatosField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DatosField, value) != true))
                {
                    this.DatosField = value;
                    this.RaisePropertyChanged("Datos");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false)]
        public string MsjError
        {
            get
            {
                return this.MsjErrorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.MsjErrorField, value) != true))
                {
                    this.MsjErrorField = value;
                    this.RaisePropertyChanged("MsjError");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "WS_PDF.GenerarSoap")]
    public interface GenerarSoap
    {
        // CODEGEN: Generating message contract since element name Fila from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/GenerarPDF", ReplyAction = "*")]
        ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFResponse GenerarPDF(ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GenerarPDFRequest
    {
        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GenerarPDF", Namespace = "http://tempuri.org/", Order = 0)]
        public ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequestBody Body;

        public GenerarPDFRequest()
        {
        }

        public GenerarPDFRequest(ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://tempuri.org/")]
    public partial class GenerarPDFRequestBody
    {
        [System.Runtime.Serialization.DataMemberAttribute(Order = 0)]
        public int Numero_Prestamo;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 1)]
        public ExtraerPDFConstanciasOmega.WS_PDF.TipoPDF tipoPDF;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 2)]
        public int Anno;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public int Porcentaje;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string Fila;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 5)]
        public bool Forzar;

        public GenerarPDFRequestBody()
        {
        }

        public GenerarPDFRequestBody(int Numero_Prestamo, ExtraerPDFConstanciasOmega.WS_PDF.TipoPDF tipoPDF, int Anno, int Porcentaje, string Fila, bool Forzar)
        {
            this.Numero_Prestamo = Numero_Prestamo;
            this.tipoPDF = tipoPDF;
            this.Anno = Anno;
            this.Porcentaje = Porcentaje;
            this.Fila = Fila;
            this.Forzar = Forzar;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GenerarPDFResponse
    {
        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GenerarPDFResponse", Namespace = "http://tempuri.org/", Order = 0)]
        public ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFResponseBody Body;

        public GenerarPDFResponse()
        {
        }

        public GenerarPDFResponse(ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://tempuri.org/")]
    public partial class GenerarPDFResponseBody
    {
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public ExtraerPDFConstanciasOmega.WS_PDF.Archivo GenerarPDFResult;

        public GenerarPDFResponseBody()
        {
        }

        public GenerarPDFResponseBody(ExtraerPDFConstanciasOmega.WS_PDF.Archivo GenerarPDFResult)
        {
            this.GenerarPDFResult = GenerarPDFResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GenerarSoapChannel : ExtraerPDFConstanciasOmega.WS_PDF.GenerarSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GenerarSoapClient : System.ServiceModel.ClientBase<ExtraerPDFConstanciasOmega.WS_PDF.GenerarSoap>, ExtraerPDFConstanciasOmega.WS_PDF.GenerarSoap
    {
        public GenerarSoapClient()
        {
        }

        public GenerarSoapClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public GenerarSoapClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenerarSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public GenerarSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFResponse ExtraerPDFConstanciasOmega.WS_PDF.GenerarSoap.GenerarPDF(ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequest request)
        {
            return base.Channel.GenerarPDF(request);
        }

        public ExtraerPDFConstanciasOmega.WS_PDF.Archivo GenerarPDF(int Numero_Prestamo, ExtraerPDFConstanciasOmega.WS_PDF.TipoPDF tipoPDF, int Anno, int Porcentaje, string Fila, bool Forzar)
        {
            ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequest inValue = new ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequest();
            inValue.Body = new ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFRequestBody();
            inValue.Body.Numero_Prestamo = Numero_Prestamo;
            inValue.Body.tipoPDF = tipoPDF;
            inValue.Body.Anno = Anno;
            inValue.Body.Porcentaje = Porcentaje;
            inValue.Body.Fila = Fila;
            inValue.Body.Forzar = Forzar;
            ExtraerPDFConstanciasOmega.WS_PDF.GenerarPDFResponse retVal = ((ExtraerPDFConstanciasOmega.WS_PDF.GenerarSoap)(this)).GenerarPDF(inValue);
            return retVal.Body.GenerarPDFResult;
        }
    }
}