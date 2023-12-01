CREATE OR REPLACE FUNCTION fn_BuscarAplicacoes(
    IN p_AppId UUID DEFAULT NULL,
    IN p_Nome TEXT DEFAULT NULL,
    IN p_Sigla TEXT DEFAULT NULL,
    IN p_Aka TEXT DEFAULT NULL,
    IN p_Habilitado BOOLEAN DEFAULT NULL,
    IN p_VigenteEm DATE DEFAULT NULL,
    IN p_Skip INT DEFAULT 0,
    IN p_Limit INT DEFAULT NULL
)
RETURNS TABLE (
    AppId UUID,
    Nome TEXT,
    Sigla TEXT,
    Aka TEXT,
    Habilitado BOOLEAN,
    VigenteDe DATE,
    VigenteAte DATE
) AS $$
BEGIN
    RETURN QUERY
    SELECT *
    FROM Aplicacoes
    WHERE
        (p_AppId IS NULL OR AppId = p_AppId) AND
        (p_Nome IS NULL OR Nome = p_Nome) AND
        (p_Sigla IS NULL OR Sigla = p_Sigla) AND
        (p_Aka IS NULL OR Aka = p_Aka) AND
        (p_Habilitado IS NULL OR Habilitado = p_Habilitado) AND
        (p_VigenteEm IS NULL OR (VigenteDe IS NULL OR VigenteDe <= p_VigenteEm) AND (VigenteAte IS NULL OR VigenteAte >= p_VigenteEm))
    ORDER BY AppId
    OFFSET p_Skip
    LIMIT p_Limit;
END;
$$ LANGUAGE plpgsql;
