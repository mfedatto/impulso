CREATE TABLE Tipos (
    Id SERIAL PRIMARY KEY,
    Nome TEXT UNIQUE NOT NULL,
    Habilitado BOOLEAN NOT NULL
);