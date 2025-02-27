using banca_finanzas_net.Application.Abstractions;
using banca_finanzas_net.Application.CajaAhorros;
using banca_finanzas_net.Application.CuentasCorrientes;
using banca_finanzas_net.Application.PlazosFijos;
using banca_finanzas_net.Domain.Abstractions;
using banca_finanzas_net.Domain.CajaAhorros;
using banca_finanzas_net.Domain.Clientes;
using banca_finanzas_net.Domain.CuentasCorrientes;
using banca_finanzas_net.Domain.PlazosFijos;

namespace banca_finanzas_net.Application.Clientes;

public class ClientesUseCase : ICRUDUsesCases
    <
        ClientesResponse,
        ClientesAddRequest,
        ClientesDeleteRequest,
        ClientesUpdateRequest
    >
{
    private readonly ICRUD<Cliente> _cliente;
    private readonly ICRUD<CajaAhorro> _cajaAhorro;
    private readonly ICajaAhorro _cajaAhorroCliente;
    private readonly ICRUD<CuentaCorriente> _cuentaCorriente;
    private readonly ICuentaCorriente _cuentaCorrienteCliente;
    private readonly ICRUD<PlazoFijo> _plazoFijo;

    public ClientesUseCase(
        ICRUD<Cliente> cliente, 
        ICRUD<CajaAhorro> cajaAhorro,
        ICajaAhorro cajaAhorroCliente,
        ICRUD<CuentaCorriente> cuentaCorriente,
        ICuentaCorriente cuentaCorrienteCliente,
        ICRUD<PlazoFijo> plazoFijo
    )
    {
        _cliente = cliente;
        _cajaAhorro = cajaAhorro;
        _cajaAhorroCliente = cajaAhorroCliente;
        _cuentaCorriente = cuentaCorriente;
        _cuentaCorrienteCliente = cuentaCorrienteCliente;
        _plazoFijo = plazoFijo;
    }

    public IEnumerable<ClientesResponse> GetAll()
    {
        var lstClientes = new List<ClientesResponse>();        
        var clientes = _cliente.GetList(); 

        if (clientes == null)
            return lstClientes;

        foreach (Cliente cliente in clientes)
        {
            // *******************************************************************************
            // *** Caja de Ahorro
            var lstCajaAhorro = GetClienteMovsCajaAhorro(cliente);
            // *******************************************************************************
            // *** Cuenta Corriente
            var lstCuentaCorriente = GetClienteMovsCuentaCorriente(cliente);
            // *******************************************************************************
            // *** Plazo Fijo 
            var lstPlazoFijo = GetClienteMovsPlazoFijo(cliente);
            // *******************************************************************************
            lstClientes.Add(
                new ClientesResponse()
                {
                    Cliente_UUID = cliente.Cliente_UUID,
                    Nombres = cliente.Nombres,
                    Apellidos = cliente.Apellidos,
                    Email = cliente.Email,
                    Active = cliente.Active,
                    CajaAhorros = lstCajaAhorro,
                    CuentasCorrientes = lstCuentaCorriente,
                    PlazosFijos = lstPlazoFijo
                }
            );
        }
        return lstClientes;
    }

    public ClientesResponse GetByIb(int id)
    {
        throw new NotImplementedException();
    }

    public ClientesResponse GetByUUID(Guid guid)
    {
        return GetAll().SingleOrDefault(x => x.Cliente_UUID == guid)!; 
    }

    public Task<int> Add(ClientesAddRequest entity, CancellationToken cancellationToken)
    {
        try
        {
            var newReg = new Cliente()
            {
                Cliente_Id = 0, 
                Cliente_UUID = Guid.NewGuid(), 
                Nombres = entity.Nombres, 
                Apellidos = entity.Apellidos, 
                Email = entity.Email, 
                Telefono = entity.Telefono, 
                Active = 1
            };
            var result = _cliente.Add(newReg, cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Delete(ClientesDeleteRequest entity, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = _cliente.GetByUUID(entity.Cliente_UUID);

            if (cliente == null)
                return Task<int>.FromResult(0);

            var result = _cliente.Delete(cliente.Cliente_Id, cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    public Task<int> Update(ClientesUpdateRequest entity, CancellationToken cancellationToken)
    {
        try
        {
            var cliente = _cliente.GetByUUID(entity.Cliente_UUID);

            if (cliente == null)
                return Task<int>.FromResult(0);

            var regUpdate = new Cliente() 
            { 
                Cliente_Id = cliente.Cliente_Id, 
                Cliente_UUID = entity.Cliente_UUID, 
                Nombres = entity.Nombres, 
                Apellidos = entity.Apellidos, 
                Email = entity.Email, 
                Telefono = entity.Telefono, 
                Active = entity.Active
            };
            var result = _cliente.Update(regUpdate, cancellationToken);
            return Task<int>.FromResult((int)result.Result);
        }
        catch
        {
            return Task<int>.FromResult(0);
        }
    }

    private List<PlazosFijosResponse> GetClienteMovsPlazoFijo(Cliente cliente)
    {
        var plazoFijo = _plazoFijo
            .GetList()
            .SingleOrDefault(x => x.Cliente_Id == cliente.Cliente_Id);

        var lstPlazoFijo = new List<PlazosFijosResponse>();

        if (plazoFijo != null)
        {
            lstPlazoFijo.Add(
                new PlazosFijosResponse()
                {
                    Plazofijo_UUID = plazoFijo!.Plazofijo_UUID,
                    Nrocuenta = plazoFijo.Nrocuenta,
                    Monto = plazoFijo.Monto,
                    Plazo = plazoFijo.Plazo!.GetPlazo(),
                    Interes = plazoFijo.Interes,
                    TNA = plazoFijo.Interes * 12, // TNA %
                    Capital = plazoFijo.Capital!.GetCapital(),
                    Fecha_Inicio = plazoFijo.Fecha_Inicio,
                    Fecha_Vencimiento = plazoFijo.Fecha_Vencimiento!.GetFechaVencimiento(),
                    Active = plazoFijo.Active
                }
            );
        }
        else
        {
            plazoFijo = null;
        }

        return lstPlazoFijo;
    }

    private List<CajaAhorrosResponse> GetClienteMovsCajaAhorro(Cliente cliente)
    {
        // *******************************************************************************
        // *** Caja de Ahorro 
        // *******************************************************************************
        var lstCajaAhorro = new List<CajaAhorrosResponse>();
        var cajaAhorro = _cajaAhorroCliente.GetClienteMovsByID(cliente.Cliente_Id);
        if (cajaAhorro != null)
        {
            //var debe = _cajaAhorroCliente.GetClienteMovsByID(cliente.Cliente_Id).Sum(x => x.Debe);
            //var haber = _cajaAhorroCliente.GetClienteMovsByID(cliente.Cliente_Id).Sum(x => x.Haber);
            //var saldo = debe - haber;

            decimal debe = 0;
            decimal haber = 0;

            foreach (CajaAhorro caja in cajaAhorro)
            {
                debe += caja.Debe;
                haber += caja.Haber;
                decimal saldo = debe - haber;

                lstCajaAhorro.Add(
                    new CajaAhorrosResponse()
                    {
                        NroCuenta = caja.NroCuenta,
                        Movimiento = caja.Movimiento,
                        Debe = caja.Debe,
                        Haber = caja.Haber,
                        Saldo = saldo
                    }
                );
            }
        }
        else
        {
            cajaAhorro = null;
        }
        // *******************************************************************************
        return lstCajaAhorro;
    }

    private List<CuentaCorrienteResponse> GetClienteMovsCuentaCorriente(Cliente cliente)
    {
        // *******************************************************************************
        // *** Cuenta Corriente
        // *******************************************************************************
        var lstCuentaCorriente = new List<CuentaCorrienteResponse>();
        var cuentaCorriente = _cuentaCorrienteCliente.GetClienteMovsByID(cliente.Cliente_Id);
        if (cuentaCorriente != null)
        {
            decimal debe = 0;
            decimal haber = 0;

            foreach (CuentaCorriente cc in cuentaCorriente)
            {
                debe += cc.Debe;
                haber += cc.Haber;
                decimal saldo = debe - haber;

                lstCuentaCorriente.Add(
                    new CuentaCorrienteResponse()
                    {
                        Cuenta_Corriente_UUIG = cc.Cuenta_Corriente_UUID,
                        Estadp = cc.Estado,
                        Fecha_Emision = cc.Fecha_Emision,
                        Fecha_Cobro = cc.Fecha_Cobro,
                        Debe = cc.Debe,
                        Haber = cc.Haber,
                        Saldo = saldo,
                        Active = cc.Active
                    }
                );
            }
        }
        else
        {
            cuentaCorriente = null;
        }
        // *******************************************************************************
        return lstCuentaCorriente;
    }
}
