import "bootstrap/dist/css/bootstrap.min.css";

function Loading() {
  return (
    <div className="d-flex justify-content-center align-items-center">
      <div className="p-4 justify-content-center">
        <div className="spinner-border text-warning" role="status">
          <span className="sr-only"></span>
        </div>
        <p>Cargando datos...</p>
      </div>
    </div>    
  );
}

export default Loading;