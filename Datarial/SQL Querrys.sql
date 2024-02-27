Create database Datarial

Use Datarial

CREATE TABLE Factura (
    FacturaId INT PRIMARY KEY,
    Fecha DATE,
    Total DECIMAL(10, 2)
);

CREATE TABLE Producto (
    ProductoId INT PRIMARY KEY,
    Descripcion VARCHAR(255)
);

CREATE TABLE FacturaDetalle (
    FacturaDetalleId INT PRIMARY KEY,
    FacturaId INT,
    ProductoId INT,
    Precio DECIMAL(10, 2),
    FOREIGN KEY (FacturaId) REFERENCES Factura(FacturaId),
    FOREIGN KEY (ProductoId) REFERENCES Producto(ProductoId)
);
