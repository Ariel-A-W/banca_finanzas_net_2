import React, { useEffect, useState } from "react";
import axios from "axios";

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

  if (loading) return <p>Cargando datos...</p>;

  return (
    <div>
      <h1>Clientes</h1>
      {clientes.map((cliente, index) => (
        <div key={cliente.cliente_UUID || index} style={{ border: "1px solid #ccc", margin: "10px", padding: "10px" }}>
          <h2>{cliente.nombres} {cliente.apellidos}</h2>
          <p>Email: {cliente.email}</p>
          <h3>Caja de Ahorro</h3>
          {cliente.cajaAhorros?.length > 0 ? (
            <ul>
              {cliente.cajaAhorros.map((ca, idx) => (
                <li key={idx}>
                  {ca.movimiento}: ${ca.debe || ca.haber} - Saldo: ${ca.saldo}
                </li>
              ))}
            </ul>
          ) : <p>No tiene caja de ahorro</p>}
          <h3>Cuentas Corrientes</h3>
          {cliente.cuentasCorrientes?.length > 0 ? (
            <ul>
              {cliente.cuentasCorrientes.map((cc, idx) => (
                <li key={idx}>
                  {cc.estadp}: ${cc.debe || cc.haber} - Saldo: ${cc.saldo}
                </li>
              ))}
            </ul>
          ) : <p>No tiene cuentas corrientes</p>}
          <h3>Plazos Fijos</h3>
          {cliente.plazosFijos?.length > 0 ? (
            <ul>
              {cliente.plazosFijos.map((pf, idx) => (
                <li key={idx}>
                  Cuenta: {pf.nrocuenta} - Monto: ${pf.monto} - Plazo: {pf.plazo} d&iacute;as - Capital Final: ${pf.capital?.toFixed(2)}
                </li>
              ))}
            </ul>
          ) : <p>No tiene plazos fijos</p>}
        </div>
      ))}
    </div>
  );
};

export default App;