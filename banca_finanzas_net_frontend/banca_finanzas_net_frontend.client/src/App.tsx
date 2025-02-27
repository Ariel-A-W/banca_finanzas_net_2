import React, { useEffect, useState } from "react";
import axios from "axios";

import "bootstrap/dist/css/bootstrap.min.css";
import Loading from "./components/Loading";


const API_URL = "https://localhost:7061/api/Clientes";

const App = () => {
  const [clientes, setClientes] = useState(Array);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios
      .get(API_URL)
      .then((response) => {
        if (Array.isArray(response.data)) {
          console.log("Data fetched:", response.data);
          setClientes(response.data);
        } else {
          console.error("Error: Los datos recibidos no son un array", response.data);
        }
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching data:", error);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return (
      <Loading></Loading>
    )
  } else {
    return (
      <div className="d-flex justify-content-center align-items-center">
        <div className="p-4" style={{ background: "#3a75c4" }} >
          <h3 style={{ color: "white"}} >Clientes</h3>
          {clientes.map((cliente, index) => (
            <div key={cliente.cliente_UUID || index} className="border rounded" style={{ border: "1px solid #ccc", margin: "10px", padding: "10px", background: "#ffffff" }}>
              <h4>{cliente.nombres} {cliente.apellidos}</h4>
              <p><b>Email:</b> {cliente.email}</p>
              <h4>Caja de Ahorro</h4>
              {cliente.cajaAhorros?.length > 0 ? (
                <ul>
                  <p><b>Movimientos:</b></p>
                  {cliente.cajaAhorros.map((ca, idx) => (
                    <ol key={idx}>
                      {ca.movimiento} - ${ca.debe || ca.haber} - Saldo: ${ca.saldo}
                    </ol>
                  ))}
                </ul>
              ) : <p>No tiene caja de ahorro</p>}
              <h4>Cuentas Corrientes</h4>
              {cliente.cuentasCorrientes?.length > 0 ? (
                <ul>
                  {cliente.cuentasCorrientes.map((cc, idx) => (
                    <ol key={idx}>
                      {cc.estadp}: $ {cc.debe || cc.haber} = Saldo: $ {cc.saldo}
                    </ol>
                  ))}
                </ul>
              ) : <p>No tiene cuentas corrientes</p>}
              <h4>Plazos Fijos</h4>
              {cliente.plazosFijos?.length > 0 ? (
                <ul>
                  {cliente.plazosFijos.map((pf, idx) => (
                    <div key={idx}>
                      <p><b>Cuenta:</b> {pf.nrocuenta}</p>
                      <p><b>Monto:</b> $ {pf.monto.toFixed(2)}</p>
                      <p><b>Plazo:</b> {pf.plazo} d&iacute;as</p>
                      <p><b>Capital:</b> $ {pf.capital?.toFixed(2)}</p>
                    </div>
                  ))}
                </ul>
              ) : <p>No tiene plazos fijos</p>}
            </div>
          ))}
        </div>
      </div>
    );
  }  
};

export default App;