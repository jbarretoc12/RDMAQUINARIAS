/*inv*/

/*
PRODUCTOS
ALMACENES
TIPO DE MOVIMIENTO
MOVIMIENTOS CABECERA
MOVIMIENTOS DEALLE
*/

--CREATE DATABASE BDPRUEBA
--GO
USE BDPRUEBA
GO
CREATE TABLE ERP_ALM_UNIMED(
	idUm int identity(1,1),
	coUm char(4) PRIMARY KEY,
	deUm varchar(30),
	estado char(1),
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_UNIMED (coUm,deUm,estado,coEmp) VALUES ('UNI','UNIDAD','A','01'),('LTS','LITROS','A','01')
GO
CREATE TABLE ERP_ALM_MARCA(
	idMar int identity(1,1),
	coMar varchar(5) primary key,
	deMar varchar(50),
	estado char(1),
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_MARCA (coMar,deMar,estado,coEmp) VALUES ('00001','VOLVO','A','01'),('00002','FG WILSON','A','01')
GO
CREATE TABLE ERP_ALM_PRODUCTOS(
	idProd int identity(1,1),
	coProd varchar(30) primary key,
	deProd varchar(50),
	tipoBien char(1), --B=BIENES / S=SERVICIOS
	coUm char(4),
	coMar varchar(20),
	stockActual decimal(18,2),
	cos_u decimal(18,2),
	coEmp char(2),
	estado char(1),
	st_registro bit,
	co_usua_crea varchar(30),
	fe_usua_crea datetime,
	co_usua_modi varchar(30),
	fe_usua_modi datetime
)
GO
INSERT INTO ERP_ALM_PRODUCTOS (coProd,deProd,tipoBien,coUm,coMar,stockActual,cos_u,coEmp,estado,st_registro,co_usua_crea,fe_usua_crea) VALUES 
('RU2590','FILTRO DE AIRE (B044B6)','B','UNI','00001',50.00,50000.00,'01','A',1,'JBARRETO',GETDATE()),
('FF5711','FILTRO DE COMBUSTIBLE','B','UNI','00002',25.00,18500.00,'01','A',1,'JBARRETO',GETDATE())


GO
CREATE TABLE ERP_ALM_ALMACENES(
	idAlm int identity(1,1),
	coAlm char(2) primary key,
	deAlm varchar(50),
	deUbi varchar(30),
	coSuc char(2),
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_ALMACENES (coAlm,deAlm,deUbi,coEmp,coSuc) VALUES ('01','PRINCIPAL REPUESTOS','','01','01'),('02','PRINCIPAL EQUIPO','','01','01')  
GO
CREATE TABLE ERP_ALM_OPERACIONES(
	idOpe int identity(1,1),
	coOpe char(3) primary key,
	deOpe varchar(50),
	tiMov char(1),
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_OPERACIONES (coOpe,deOpe,tiMov,coEmp) VALUES ('ICO','INGRESO COMPRA LOCAL','I','01'),('INI','SALDO INICIAL','I','01'),('SVT','SALIDA POR VENTA','S','01')
GO

SELECT * FROM ERP_ALM_OPERACIONES
GO
alter PROC SP_ERP_ALM_OPERACIONES_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT coOpe,deOpe FROM ERP_ALM_OPERACIONES WHERE coEmp=@coEmp AND tiMov=@criterio
END

GO
CREATE TABLE ERP_ALM_NUMERADOR(
	idNum int identity(1,1),
	seNum char(3),
	deNum varchar(50),
	numero int,
	coOpe char(3),
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_NUMERADOR (seNum,deNum,numero,coOpe,coEmp) VALUES  ('001','INGRESO DIRECTO',0,'INI','01'),('001','COMPRA LOCAL',0,'ICO','01'),('001','SALIDA POR VENTA',0,'SVT','01')
GO
SELECT * FROM ERP_ALM_NUMERADOR
GO
ALTER proc SP_ERP_ALM_NUMERADOR_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT seNum,deNum FROM ERP_ALM_NUMERADOR WHERE coEmp=@coEmp
END
IF @opcion=1
BEGIN
	SELECT seNum,deNum FROM ERP_ALM_NUMERADOR WHERE coEmp=@coEmp AND coOpe=@criterio
END



GO
CREATE TABLE ERP_ALM_MOVIMIENTO_CAB(
	idMov int identity(1,1),
	coOpe char(3),
	seNum char(3),
	numero char(8),
	nuMov varchar(16) primary key,
	coProvCli varchar(20),
	tiMov char(1),
	coMon char(1),
	tcVen decimal(18,4),
	feMov date,
	feRef date,
	origen char(1), --A=ALMACEN / C=COMPRAS
	coAlm char(2),
	coAlmDes char(2),
	coProy varchar(30),
	cos_t_nac decimal(18,2),
	deObsInt varchar(255),
	deObsProv varchar(255),
	nuDocRef varchar(20),
	estado char(1),
	st_registro bit,
	co_usua_crea varchar(30),
	fe_usua_crea datetime,
	co_usua_modi varchar(30),
	fe_usua_modi datetime,
	coEmp char(2)
)
GO
INSERT INTO ERP_ALM_MOVIMIENTO_CAB (coOpe,seNum,numero,nuMov,coProvCli,tiMov,coMon,tcVen,feMov,feRef,origen,coAlm,coAlmDes,coProy,cos_t_nac,deObsInt,deObsProv,estado,st_registro,co_usua_crea,fe_usua_crea,coEmp) 
VALUES ('INI','001','00000001','INI-001-00000001','20102279256','I','D',3.9870,GETDATE(),GETDATE(),'A','01',NULL,NULL,0,'','','A',1,'JBARRETO',GETDATE(),'01')
GO
CREATE TABLE ERP_ALM_MOVIMIENTO_DET(
	idMovDet int identity(1,1),
	item int,
	nuMov varchar(16),
	tipoBien char(1),
	coProd varchar(30),
	cant decimal(18,2),
	cos_u_nac decimal(18,2),
	cos_t_nac decimal(18,2),
	deObs varchar(250)
)
GO
INSERT INTO ERP_ALM_MOVIMIENTO_DET (item,nuMov,tipoBien,coProd,cant,cos_u_nac,cos_t_nac,deObs) VALUES 
(1,'INI-001-00000001','B','RU2590',2,10.50,21.00,''),
(2,'INI-001-00000001','B','FF5711',1,5.00,5.00,'')

GO

SELECT * FROM ERP_ALM_MOVIMIENTO_CAB
SELECT * FROM ERP_ALM_MOVIMIENTO_DET


GO

/*WITH Movimientos AS (
	SELECT D.coProd,
		CONVERT(date,C.feMov) 'feMov',
		O.deOpe,
		C.nuDocRef,
		CASE WHEN O.tiMov='S' THEN D.cant ELSE 0 END 'Salida',
		CASE WHEN O.tiMov='I' THEN D.cant ELSE 0 END 'Entrada',
		D.cos_u_ext,D.cos_t_ext	
	FROM ERP_ALM_MOVIMIENTO_DET D 
	INNER JOIN ERP_ALM_MOVIMIENTO_CAB C ON C.nuMov=D.nuMov
	INNER JOIN ERP_ALM_OPERACIONES O ON O.coOpe=C.coOpe
)
SELECT feMov,deOpe,nuDocRef,Entrada,Salida, SUM(Entrada - Salida) OVER (ORDER BY feMov,nuDocRef ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS 'stockAcumulado',
cos_u_ext
FROM Movimientos 
GROUP BY feMov,deOpe,nuDocRef,Entrada,Salida,cos_u_ext
ORDER BY feMov
*/
---Consulta SQL: Kardex con Promedio Ponderado Móvil

/*-- Paso 1: Obtener todos los movimientos del producto, con flag de entrada/salida
WITH MovimientoBase AS (
	SELECT 
		D.coProd,
		C.feMov,
		C.nuDocRef,
		O.tiMov,
		O.deOpe,
		D.cant,
		D.cos_u_ext,
		D.cos_t_ext,
		ROW_NUMBER() OVER (ORDER BY C.feMov, D.idMovDet) AS orden
	FROM ERP_ALM_MOVIMIENTO_DET D 
	INNER JOIN ERP_ALM_MOVIMIENTO_CAB C ON C.nuMov = D.nuMov
	INNER JOIN ERP_ALM_OPERACIONES O ON O.coOpe = C.coOpe
	WHERE D.coProd='RU2590'
),
-- Paso 2: Crear acumulado de entradas y salidas
MovimientosCalculados AS (
	SELECT *,
		CASE WHEN tiMov = 'I' THEN cant ELSE 0 END AS Entrada,
		CASE WHEN tiMov = 'S' THEN cant ELSE 0 END AS Salida
	FROM MovimientoBase
),
-- Paso 3: Cálculo base sin acumulados
Calculado AS (
	SELECT 
		coProd,
		feMov,
		nuDocRef,
		deOpe,
		Entrada,
		Salida,
		cos_u_ext,
		cos_t_ext,
		orden
	FROM MovimientosCalculados
),
-- Paso 4: Simulación del promedio ponderado (Stock y ValorAcumulado)
Final AS (
	SELECT 
		A.coProd,
		A.feMov,
		A.nuDocRef,
		A.deOpe,
		A.Entrada,
		A.Salida,
		A.cos_u_ext,
		A.cos_t_ext,
		-- Stock acumulado
		SUM(A.Entrada - A.Salida) OVER (ORDER BY A.orden ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS Stock,
		-- Costo acumulado: solo se suma cuando hay entrada
		SUM(CASE WHEN A.Entrada > 0 THEN A.cos_t_ext ELSE 0 END) 
			OVER (ORDER BY A.orden ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) 
		AS TotalCostoEntradas,

		-- Total cantidad acumulada
		SUM(CASE WHEN A.Entrada > 0 THEN A.Entrada ELSE 0 END) 
			OVER (ORDER BY A.orden ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)
		AS TotalCantidadEntradas
	FROM Calculado A
)
-- Paso 5: Agregar columna final: Costo Promedio y Valor Total
SELECT 
	coProd,
	feMov,
	nuDocRef,
	deOpe,
	Entrada,
	Salida,
	cos_u_ext,
	cos_t_ext,
	Stock,
	TotalCostoEntradas,
	TotalCantidadEntradas,
	-- Costo Promedio
	CASE 
		WHEN TotalCantidadEntradas = 0 THEN 0 
		ELSE ROUND(TotalCostoEntradas / TotalCantidadEntradas, 2)
	END AS CostoPromedio,
	-- Valor total del stock
	CASE 
		WHEN Stock = 0 THEN 0
		ELSE ROUND(Stock * (TotalCostoEntradas / NULLIF(TotalCantidadEntradas, 0)), 2)
	END AS ValorTotalStock
FROM Final;*/
GO

ALTER VIEW VW_ERP_ALM_MOVIMIENTOS
AS
SELECT C.coEmp,C.nuMov,C.coOpe,C.coProvCli,PC.deProvCli,C.tiMov,C.coMon,C.feMov,C.coAlm,C.coAlmDes,D.idMovDet,D.coProd,D.cant,D.cos_u_nac,D.cos_t_nac 
FROM ERP_ALM_MOVIMIENTO_CAB C INNER JOIN ERP_ALM_MOVIMIENTO_DET D ON D.nuMov=C.nuMov
LEFT JOIN EPR_COM_PROVCLI PC ON PC.coProvCli=C.coProvCli AND PC.coEmp=C.coEmp
GO

SELECT * FROM VW_ERP_ALM_MOVIMIENTOS
SELECT * FROM ERP_ALM_MOVIMIENTO_CAB
SELECT * FROM ERP_ALM_MOVIMIENTO_DET
SELECT * FROM EPR_COM_PROVCLI
SELECT * FROM ERP_ALM_PRODUCTOS


--00000001
GO

ALTER PROC SP_ERP_ALM_MOVIMIENTO_CAB_LS
@opcion int,
@criterio varchar(30),
@tiMov char(1),
@coEmp char(2),
@coSuc char(2)
AS
IF @opcion=0
BEGIN
	SELECT C.*,P.deProvCli FROM ERP_ALM_MOVIMIENTO_CAB C LEFT JOIN EPR_COM_PROVCLI P ON P.coProvCli=C.coProvCli AND P.coEmp=C.coEmp
	WHERE C.coEmp=@coEmp AND C.nuMov=@criterio
END
IF @opcion=1
BEGIN

	SELECT ROW_NUMBER() OVER (ORDER BY M.nuMov) 'nro',M.nuMov,N.deNum,M.feMov,C.deProvCli,M.nuDocRef,M.coProy FROM ERP_ALM_MOVIMIENTO_CAB M 
	INNER JOIN EPR_COM_PROVCLI C ON C.coProvCli=M.coProvCli AND C.coEmp=M.coEmp
	LEFT JOIN ERP_ALM_NUMERADOR N ON N.coOpe=M.coOpe AND N.seNum=M.seNum
	WHERE M.tiMov=@tiMov AND M.nuMov LIKE '%'+@criterio+'%'
	
	/*SELECT ISNULL(M.nuMov,O.nuPed) 'numDoc',C.deProvCli,M.coProy,O.fePed,O.feRec,M.feMov,O.coMon,O.dirEnt,S.dirSuc,O.stOrdenado /*,O.**/ 
	FROM EPR_COM_ORDEN_PEDIDO_CAB O LEFT JOIN EPR_COM_PROVCLI C ON C.coProvCli=O.coProvCli and C.coEmp=O.coEmp
	LEFT JOIN ERP_COM_CONDICION_PAGO CP ON CP.coCond=O.coCond AND CP.coEmp=O.coEmp
	LEFT JOIN ERP_ADM_SUCURSAL S ON S.coSuc=O.coSuc AND S.coEmp=O.coEmp
	LEFT JOIN ERP_ALM_MOVIMIENTO_CAB M ON M.nuDocRef=O.nuPed AND M.coEmp=O.coEmp
	WHERE ISNULL(stOrdenado,0)=1*/

END
GO


CREATE PROC SP_ERP_ALM_MOVIMIENTO_SALIDA_CAB_LS
@opcion int,
@criterio varchar(30),
@tiMov char(1),
@coEmp char(2),
@coSuc char(2)
AS
IF @opcion=0
BEGIN
	SELECT C.*,P.deProvCli FROM ERP_ALM_MOVIMIENTO_CAB C LEFT JOIN EPR_COM_PROVCLI P ON P.coProvCli=C.coProvCli AND P.coEmp=C.coEmp
	WHERE C.coEmp=@coEmp AND C.nuMov=@criterio
END
IF @opcion=1
BEGIN

	SELECT ROW_NUMBER() OVER (ORDER BY M.nuMov) 'nro',M.nuMov,N.deNum,M.feMov,C.deProvCli,M.nuDocRef,M.coProy FROM ERP_ALM_MOVIMIENTO_CAB M 
	INNER JOIN EPR_COM_PROVCLI C ON C.coProvCli=M.coProvCli AND C.coEmp=M.coEmp
	LEFT JOIN ERP_ALM_NUMERADOR N ON N.coOpe=M.coOpe AND N.seNum=M.seNum
	WHERE M.tiMov=@tiMov AND M.nuMov LIKE '%'+@criterio+'%'
END


	/*SELECT M.nuMov,C.deProvCli,M.feMov,M.nuDocRef,M.coProy,M.co_usua_crea FROM ERP_ALM_MOVIMIENTO_CAB M 
	LEFT JOIN EPR_COM_PROVCLI C ON C.coProvCli=M.coProvCli AND C.coEmp=M.coEmp
	LEFT JOIN EPR_COM_ORDEN_PEDIDO_CAB OC ON OC.nuPed=M.nuDocRef*/


	/*SELECT * FROM EPR_COM_ORDEN_PEDIDO_CAB
	SELECT * FROM ERP_ALM_MOVIMIENTO_CAB
	SELECT * FROM ERP_ADM_SUCURSAL

	SELECT * FROM ERP_ALM_MOVIMIENTO_CAB
	SELECT * FROM sys.tables

	SELECT C.nuMov,C.coOpe,C.coProvCli,C.tiMov,C.coMon,C.feMov,C.coAlm,C.coAlmDes,
	C.idMovDet,C.coProd,C.cant,C.cos_u_nac,C.cos_t_nac FROM VW_ERP_ALM_MOVIMIENTOS C
	WHERE C.coEmp=@coEmp AND C.coProvCli+C.deProvCli LIKE '%'+@criterio+'%'*/


GO
SELECT * FROM ERP_ALM_NUMERADOR
ALTER PROC SP_ERP_ALM_NUMERADOR_GENERAR
@opc int,
@seNum char(3),
@coEmp char(2)
AS
IF @opc = 1
BEGIN
	declare @num int; set @num = (SELECT numero + 1 FROM ERP_ALM_NUMERADOR WHERE seNum=@seNum AND coEmp=@coEmp)
	select @num 'num'
END
GO
CREATE PROC SP_ERP_ALM_NUMERADOR_GENERAR_SALIDA
@opc int,
@seNum char(3),
@coEmp char(2)
AS
IF @opc = 1
BEGIN
	declare @num int; set @num = (SELECT numero + 1 FROM ERP_ALM_NUMERADOR WHERE seNum=@seNum AND coEmp=@coEmp)
	select @num 'num'
END



GO
EXEC SP_ERP_ALM_NUMERADOR_GENERAR 1,'001','01'
SELECT numero + 1 FROM ERP_ALM_NUMERADOR WHERE seNum='001' AND coEmp='01'
GO

ALTER PROC SP_ERP_ALM_MOVIMIENTO_CAB_GB
@opc int,
@coOpe char(3),
@seNum char(3),
@numero char(8),
@nuMov varchar(16),
@coProvCli varchar(20),
@tiMov char(1),
@coMon char(1),
@tcVen decimal(18,4),
@feMov date,
@feRef date,
@origen char(1), --A=ALMACEN / C=COMPRAS
@coAlm char(2),
@coAlmDes char(2),
@coProy varchar(30),
@cos_t_nac decimal(18,2),
@deObsInt varchar(255),
@deObsProv varchar(255),
@nuDocRef varchar(20),
@estado char(1),
@co_usua_crea varchar(30),
@coEmp char(2)
AS
IF @opc=1
BEGIN
	UPDATE ERP_ALM_NUMERADOR SET numero=CONVERT(int,@numero) WHERE coOpe=@coOpe AND seNum=@seNum AND coEmp=@coEmp

	INSERT INTO ERP_ALM_MOVIMIENTO_CAB 
	(coOpe,seNum,numero,nuMov,coProvCli,tiMov,coMon,tcVen,feMov,feRef,origen,coAlm,coAlmDes,coProy,
	cos_t_nac,deObsInt,deObsProv,nuDocRef,estado,st_registro,co_usua_crea,fe_usua_crea,coEmp)
	VALUES
	(@coOpe,@seNum,@numero,@nuMov,@coProvCli,@tiMov,@coMon,@tcVen,@feMov,@feRef,@origen,@coAlm,@coAlmDes,
	@coProy,@cos_t_nac,@deObsInt,@deObsProv,@nuDocRef,@estado,1,@co_usua_crea,GETDATE(),@coEmp)
END
GO

CREATE PROC SP_ERP_ALM_MOVIMIENTO_SALIDA_CAB_GB
@opc int,
@coOpe char(3),
@seNum char(3),
@numero char(8),
@nuMov varchar(16),
@coProvCli varchar(20),
@tiMov char(1),
@coMon char(1),
@tcVen decimal(18,4),
@feMov date,
@feRef date,
@origen char(1), --A=ALMACEN / C=COMPRAS
@coAlm char(2),
@coAlmDes char(2),
@coProy varchar(30),
@cos_t_nac decimal(18,2),
@deObsInt varchar(255),
@deObsProv varchar(255),
@nuDocRef varchar(20),
@estado char(1),
@co_usua_crea varchar(30),
@coEmp char(2)
AS
IF @opc=1
BEGIN
	UPDATE ERP_ALM_NUMERADOR SET numero=CONVERT(int,@numero) WHERE coOpe=@coOpe AND seNum=@seNum AND coEmp=@coEmp

	INSERT INTO ERP_ALM_MOVIMIENTO_CAB 
	(coOpe,seNum,numero,nuMov,coProvCli,tiMov,coMon,tcVen,feMov,feRef,origen,coAlm,coAlmDes,coProy,
	cos_t_nac,deObsInt,deObsProv,nuDocRef,estado,st_registro,co_usua_crea,fe_usua_crea,coEmp)
	VALUES
	(@coOpe,@seNum,@numero,@nuMov,@coProvCli,@tiMov,@coMon,@tcVen,@feMov,@feRef,@origen,@coAlm,@coAlmDes,
	@coProy,@cos_t_nac,@deObsInt,@deObsProv,@nuDocRef,@estado,1,@co_usua_crea,GETDATE(),@coEmp)
END

GO
ALTER PROC SP_ERP_ALM_MOVIMIENTO_DET_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT D.*,P.deProd,P.coUm FROM ERP_ALM_MOVIMIENTO_DET D INNER JOIN ERP_ALM_PRODUCTOS P ON P.coProd=D.coProd AND P.coEmp=P.coEmp
	WHERE nuMov=@criterio AND D.tipoBien='B'
END
GO

CREATE PROC SP_ERP_ALM_MOVIMIENTO_SALIDA_DET_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT D.*,P.deProd,P.coUm FROM ERP_ALM_MOVIMIENTO_DET D INNER JOIN ERP_ALM_PRODUCTOS P ON P.coProd=D.coProd AND P.coEmp=P.coEmp
	WHERE nuMov=@criterio AND D.tipoBien='B'
END

GO
ALTER PROC SP_ERP_ALM_MOVIMIENTO_DET_GB
@idMovDet int,
@item int,
@nuMov varchar(16),
@tipoBien char(1),
@coProd varchar(30),
@cant decimal(18,2),
@cos_u_nac decimal(18,2),
@cos_t_nac decimal(18,2),
@deObs varchar(250)
AS
IF NOT EXISTS(SELECT * FROM ERP_ALM_MOVIMIENTO_DET WHERE idMovDet=@idMovDet AND nuMov=@nuMov)
BEGIN
	INSERT INTO ERP_ALM_MOVIMIENTO_DET (item,nuMov,tipoBien,coProd,cant,cos_u_nac,cos_t_nac,deObs)
	VALUES (@item,@nuMov,@tipoBien,@coProd,@cant,@cos_u_nac,@cos_t_nac,@deObs)
END
ELSE
BEGIN
	UPDATE ERP_ALM_MOVIMIENTO_DET SET item=@item,coProd=@coProd,cant=@cant,cos_u_nac=@cos_u_nac,cos_t_nac=@cos_t_nac,deObs=@deObs
	WHERE idMovDet=@idMovDet AND nuMov=@nuMov
END




GO
---aldair 9160


GO
/*KARDEX DE TODOS LOS PRODUCTOS*/

WITH Movimientos AS(
	SELECT
		DM.coProd,
		P.deProd,
		DM.feMov,
		DM.tiMov,
		DM.cant,
		DM.cos_u_nac,
		DM.cos_t_nac,
		DM.idMovDet
	FROM VW_ERP_ALM_MOVIMIENTOS DM INNER JOIN ERP_ALM_PRODUCTOS P ON P.coProd=DM.coProd
),
Ordenado AS (
	SELECT *,
		ROW_NUMBER() OVER (PARTITION BY coProd ORDER BY feMov,idMovDet) AS Orden
	FROM Movimientos
),
Kardex AS (
	SELECT idMovDet,coProd,deProd,feMov,tiMov,cant,cos_u_nac,cos_t_nac,
	--inicializamos valores
	CAST(0 AS DECIMAL(18,2)) AS 'StockAcumulado',
	CAST(0 AS DECIMAL(18,2)) AS 'ValorAcumulado',
	CAST(0 AS DECIMAL(18,2)) AS 'CostoPromedio'
	FROM Ordenado
)
SELECT 
	K.tiMov,
	K.coProd,
	K.deProd,
	k.feMov,
	CASE WHEN K.tiMov='I' THEN 'Entrada' ELSE 'Salida' END 'TipoMovimiento',
	K.cant,
	K.cos_u_nac,
	K.cos_t_nac,
	--Calculo acumulado del Stock y valor
	SUM(CASE WHEN K.tiMov='I' THEN K.cant ELSE - K.cant END) 
		OVER(PARTITION BY K.coProd ORDER BY K.feMov, K.idMovDet
			ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS 'StockAcumulado',

	SUM(CASE WHEN K.tiMov='I' THEN K.cos_t_nac ELSE - K.cos_t_nac END)
		OVER(PARTITION BY K.coProd ORDER BY K.feMov, K.idMovDet
			ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS 'ValorAcumulado',
	--Costo promedio acumulado
	CASE 
		WHEN SUM(CASE WHEN K.tiMov='I' THEN K.cant ELSE - K.cant END)
		OVER (PARTITION BY K.coProd ORDER BY K.feMov, K.idMovDet
			ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) = 0 THEN 0
		ELSE
			SUM(CASE WHEN K.tiMov='I' THEN K.cos_t_nac ELSE - K.cos_t_nac END)
			OVER (PARTITION BY K.coProd ORDER BY K.feMov, K.idMovDet
				ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW ) /
			NULLIF(
				SUM(CASE WHEN K.tiMov='I' THEN K.cant ELSE - K.cant END)
				OVER (PARTITION BY K.coProd ORDER BY K.feMov, K.idMovDet
					ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW),
				0
			) END AS 'CostoPromedioPonderado'
FROM Kardex K
ORDER BY K.coProd,K.idMovDet

/**************SALDO MENSUAL***********/

CREATE TABLE ERP_ALM_SALDO_MENSUAL(
	coProd varchar(30),
	periodo char(7),
	StockInicial DECIMAL(18,2),
    Entradas DECIMAL(18,2),
    Salidas DECIMAL(18,2),
    StockFinal DECIMAL(18,2),
    ValorInicial DECIMAL(18,2),
    ValorEntradas DECIMAL(18,2),
    ValorSalidas DECIMAL(18,2),
    ValorFinal DECIMAL(18,2),
    PRIMARY KEY (coProd, Periodo)
);


GO

alter PROC SP_ERP_ALM_GENERAR_SALDOS_MENSUALES
@anio int,
@mes int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PeriodoActual VARCHAR(7) = FORMAT(DATEFROMPARTS(@Anio, @Mes, 1), 'yyyy-MM');
	DECLARE @FechaInicio DATE = DATEFROMPARTS(@Anio, @Mes, 1);
	DECLARE @FechaFin DATE = EOMONTH(@FechaInicio);

	 -- Eliminar datos previos del mismo periodo (si existían)
	DELETE FROM ERP_ALM_SALDO_MENSUAL WHERE Periodo = @PeriodoActual;

	-- Insertar nuevos datos
	INSERT INTO ERP_ALM_SALDO_MENSUAL (
		coProd,
		Periodo,
		StockInicial,
		Entradas,
		Salidas,
		StockFinal,
		ValorInicial,
		ValorEntradas,
		ValorSalidas,
		ValorFinal
	)
	SELECT 
		P.coProd,
		@PeriodoActual,
			-- Stock inicial y valor inicial: acumulado antes del mes
			ISNULL((
			SELECT SUM(CASE WHEN tiMov='I' THEN cant ELSE - cant END) 
			FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND feMov<@FechaInicio
			),0) AS 'StockInicial',
			-- Entradas y salidas del mes
		ISNULL((
			SELECT SUM(DM.cant) FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND DM.tiMov='I' AND DM.feMov BETWEEN @FechaInicio AND @FechaFin
		),0) AS 'Entradas',
		ISNULL((
			SELECT SUM(DM.cant) FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND DM.tiMov='S' AND DM.feMov BETWEEN @FechaInicio AND @FechaFin
		),0) AS 'Salidas',
		-- Stock final = inicial + entradas - salidas
		NULL, -- lo calculamos después con UPDATE
		-- Valor inicial
			ISNULL((
			SELECT SUM(CASE WHEN tiMov='I' THEN cos_t_nac ELSE - cos_t_nac END) 
			FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND feMov<@FechaInicio
			),0) AS 'ValorInicial',
			-- Valor entradas y salidas
		ISNULL((
			SELECT SUM(DM.cos_t_nac) FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND DM.tiMov='I' AND DM.feMov BETWEEN @FechaInicio AND @FechaFin
		),0) AS 'Entradas',
		ISNULL((
			SELECT SUM(DM.cos_t_nac) FROM VW_ERP_ALM_MOVIMIENTOS DM
			WHERE DM.coProd=P.coProd AND DM.tiMov='S' AND DM.feMov BETWEEN @FechaInicio AND @FechaFin
		),0) AS 'Salidas',
		-- Valor final = inicial + entradas - salidas
		NULL -- lo actualizamos luego
		FROM ERP_ALM_PRODUCTOS P;

		-- Calcular StockFinal y ValorFinal
	UPDATE ERP_ALM_SALDO_MENSUAL
	SET 
		StockFinal = SM.StockInicial + SM.Entradas - SM.Salidas,
		ValorFinal = SM.ValorInicial + SM.ValorEntradas - SM.ValorSalidas
	FROM ERP_ALM_SALDO_MENSUAL SM
	WHERE SM.Periodo = @PeriodoActual
END
GO

EXEC SP_ERP_ALM_GENERAR_SALDOS_MENSUALES @Anio = 2025, @Mes = 5;

SELECT * FROM ERP_ALM_SALDO_MENSUAL

SELECT * FROM ERP_ALM_MOVIMIENTO_CAB
SELECT * FROM ERP_ALM_MOVIMIENTO_DET
-----------------CIERRE DE PERIODOS

CREATE TABLE ERP_ALM_CIERRE_PERIODO_INVENTARIO (
    Periodo VARCHAR(7) PRIMARY KEY, -- formato 'YYYY-MM'
    FechaCierre DATE NULL,
    Cerrado BIT DEFAULT 0,
    co_usua_cierre VARCHAR(30),
    deObs NVARCHAR(250),
	coEmp char(2)
);
GO
SELECT * FROM ERP_ALM_CIERRE_PERIODO_INVENTARIO
GO
INSERT INTO ERP_ALM_CIERRE_PERIODO_INVENTARIO (Periodo, Cerrado) VALUES ('2025-01', 1);
GO
alter PROC SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO 
@anio int,
@mes int,
@co_usua_cierre varchar(30),
@deObs varchar(250),
@coEmp char(2)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @periodo varchar(7); SET @periodo=FORMAT(DATEFROMPARTS(@Anio, @Mes, 1), 'yyyy-MM');
	--validacion
	IF EXISTS(SELECT 1 FROM ERP_ALM_CIERRE_PERIODO_INVENTARIO WHERE Periodo=@periodo AND Cerrado=1 and coEmp=@coEmp)
	BEGIN 
		RAISERROR('El Periodo ya está cerrado',16,1);
		RETURN
	END
	--PASO 1: Generar saldos mensuales
	EXEC SP_ERP_ALM_GENERAR_SALDOS_MENSUALES @anio,@mes;

	--PASO 2: Registrar Cierre

	IF EXISTS(SELECT 1 FROM ERP_ALM_CIERRE_PERIODO_INVENTARIO WHERE Periodo=@periodo AND coEmp=@coEmp)
	BEGIN
		UPDATE ERP_ALM_CIERRE_PERIODO_INVENTARIO 
		SET Cerrado=1,
			FechaCierre=GETDATE(),
			co_usua_cierre=@co_usua_cierre,
			deObs=@deObs
		WHERE Periodo=@periodo
	END
	ELSE
	BEGIN
		INSERT INTO ERP_ALM_CIERRE_PERIODO_INVENTARIO (Periodo,Cerrado,FechaCierre,co_usua_cierre,deObs,coEmp)
		VALUES (@periodo,1, GETDATE(),@co_usua_cierre,@deObs,@coEmp);
	END

	-- Paso 3: (opcional) Bloquear movimientos previos al periodo
    -- Esto depende de tu sistema, pero podrías agregar un campo "Bloqueado" a tus tablas

	PRINT 'Cierre del periodo ' + @Periodo + ' realizado exitosamente.';
END
GO
CREATE TABLE ERP_CON_MESES(
	id int identity(1,1),
	nuMes char(2),
	noMes varchar(30)
)
GO
/*INSERT INTO  ERP_CON_MESES (nuMes,noMes) VALUES
('01','ENERO'),
('02','FEBRERO'),
('03','MARZO'),
('04','ABRIL'),
('05','MAYO'),
('06','JUNIO'),
('07','JULIO'),
('08','AGOSTO'),
('09','SETIEMBRE'),
('10','OCTUBRE'),
('11','NOVIEMBRE'),
('12','DICIEMBRE')*/

GO

CREATE PROC SP_ERP_ALM_LISTAR_ANIOS_MOV
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	SELECT YEAR(feMov) 'anio' FROM ERP_ALM_MOVIMIENTO_CAB WHERE coEmp=@coEmp
	GROUP BY YEAR(feMov)
END
GO
ALTER PROC SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	
	SELECT M.nuMes,M.noMes,ISNULL(C.Cerrado,0) 'Cerrado' FROM ERP_CON_MESES M LEFT JOIN ERP_ALM_CIERRE_PERIODO_INVENTARIO C
	ON M.nuMes=RIGHT(C.Periodo,2) AND C.coEmp=@coEmp AND LEFT(C.Periodo,4)=@criterio
END



GO
select * from ERP_ALM_MOVIMIENTO_CAB
select * from ERP_ALM_MOVIMIENTO_DET
GO
EXEC SP_ERP_ALM_CIERRE_PERIODO_INVENTARIO @anio='2025',@mes=1, @co_usua_cierre='JBARRETO',@deObs='',@coEmp='01'

---Bloquear el registrar cuando el periodo está cerrado con un TRIGGER

CREATE TRIGGER TR_ERP_ALM_CIERRE_PERIODO_INVENTARIO_VALIDAR_INSERT
ON ERP_ALM_MOVIMIENTO_CAB
INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS(
		SELECT 1 FROM inserted I
		JOIN ERP_ALM_CIERRE_PERIODO_INVENTARIO PC ON FORMAT(I.feMov,'yyyy-MM')=PC.Periodo
		WHERE PC.Cerrado=1
	)
	BEGIN
		RAISERROR('No se pueden registrar movimientos en un periodo cerrado.', 16, 1);
		RETURN;
	END
	-- Si todo bien, hacer la inserción real

END

/************************************************************************************************/

GO
CREATE PROC SP_ERP_ALM_UNIMED_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	SELECT coUm,deUm FROM ERP_ALM_UNIMED WHERE coEmp=@coEmp ORDER BY idUm
END
GO

CREATE PROC SP_ERP_ALM_MARCA_LS
@opcion int,
@criterio varchar(50),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	SELECT * FROM ERP_ALM_MARCA WHERE coEmp=@coEmp AND estado='A' ORDER BY deMar
END
IF @opcion=2
BEGIN
	SELECT * FROM ERP_ALM_MARCA WHERE coEmp=@coEmp AND estado='A' AND deMar=@criterio
END

GO
CREATE PROC SP_ERP_ALM_PRODUCTOS_LS
	@opcion int,
	@criterio varchar(30),
	@coEmp char(2),
	@coSuc char(2)
AS
IF @opcion=0
BEGIN
	SELECT P.*,M.deMar FROM ERP_ALM_PRODUCTOS P INNER JOIN ERP_ALM_MARCA M ON M.coMar=P.coMar 
	WHERE P.coProd=@criterio AND P.tipoBien='B' AND P.coEmp=@coEmp;	
END
IF @opcion=1
BEGIN
	SELECT ROW_NUMBER() OVER (ORDER BY P.coProd) 'nro',P.idProd,P.coProd,P.deProd,P.coUm,M.deMar,P.stockActual,P.cos_u FROM ERP_ALM_PRODUCTOS P INNER JOIN ERP_ALM_MARCA M ON M.coMar=P.coMar
	WHERE P.coProd+P.deProd LIKE '%'+@criterio+'%' AND P.coEmp=@coEmp
END
IF @opcion=2
BEGIN
	SELECT P.*,M.deMar FROM ERP_ALM_PRODUCTOS P INNER JOIN ERP_ALM_MARCA M ON M.coMar=P.coMar 
	WHERE P.coProd=@criterio;
END

GO
select 'ALQUILER DE MONTACARGA'='ALQUILER DE MONTACARGAs'


CREATE PROC SP_ERP_ALM_PRODUCTOS_SERVICIOS_LS
	@opcion int,
	@criterio varchar(30),
	@coEmp char(2),
	@coSuc char(2)
AS
IF @opcion=0--BUSQUEDA POR CODIGO
BEGIN
	SELECT ROW_NUMBER() OVER (ORDER BY P.coProd) 'nro',P.* FROM ERP_ALM_PRODUCTOS P 
	WHERE P.coProd = @criterio AND P.tipoBien='S' AND P.coEmp=@coEmp AND st_registro=1
END
IF @opcion=1
BEGIN
	SELECT ROW_NUMBER() OVER (ORDER BY P.coProd) 'nro',P.* FROM ERP_ALM_PRODUCTOS P 
	WHERE P.coProd+P.deProd LIKE '%'+@criterio+'%' AND P.coEmp=@coEmp AND P.tipoBien='S' AND st_registro=1
END
IF @opcion=2--BUSQUEDA POR DESCRIPCIÓN
BEGIN
	SELECT P.* FROM ERP_ALM_PRODUCTOS P 
	WHERE P.deProd=@criterio AND P.coEmp=@coEmp AND P.tipoBien='S' AND st_registro=1;
END

GO
CREATE PROC SP_ERP_ALM_PRODUCTOS_GB
@opc int,
@coProd varchar(30),
@deProd varchar(50),
@coUm char(4),
@coMar varchar(20),
--@stockActual decimal(18,2),
@cos_u decimal(18,2),
@coEmp char(2),
@estado char(1),
@co_usua_crea varchar(30)
AS
IF @opc=1
BEGIN
	INSERT INTO ERP_ALM_PRODUCTOS (coProd,deProd,coUm,coMar,stockActual,cos_u,coEmp,estado,st_registro,co_usua_crea,fe_usua_crea)
	VALUES (@coProd,@deProd,@coUm,@coMar,0,@cos_u,@coEmp,@estado,1,@co_usua_crea,GETDATE())
END
IF @opc=2
BEGIN
	UPDATE ERP_ALM_PRODUCTOS SET deProd=@deProd,coUm=@coUm,coMar=@coMar,/*stockActual=@stockActual,*/
	cos_u=@cos_u,estado=@estado,co_usua_modi=@co_usua_crea,fe_usua_modi=GETDATE()
	WHERE coProd=@coProd
END
GO

CREATE PROC SP_ERP_ALM_PRODUCTOS_SERVICIOS_GB
@opc int,
@coProd varchar(30),
@deProd varchar(50),
@tipoBien char(1),
@coUm char(4),
@coEmp char(2),
@estado char(1),
@co_usua_crea varchar(30)
AS
IF @opc=1
BEGIN
	--9
	declare @cod varchar(9); set @cod = (SELECT  'S' + @coEmp + RIGHT('000000' + CONVERT(VARCHAR, ISNULL(MAX(LEFT(coProd,6)),0) + 1),6) FROM ERP_ALM_PRODUCTOS WHERE tipoBien='S' AND coEmp=@coEmp)
	INSERT INTO ERP_ALM_PRODUCTOS (coProd,deProd,tipoBien,coUm,coEmp,estado,st_registro,co_usua_crea,fe_usua_crea)
	VALUES (@cod,@deProd,@tipoBien,@coUm,@coEmp,@estado,1,@co_usua_crea,GETDATE())
END
IF @opc=2
BEGIN
	UPDATE ERP_ALM_PRODUCTOS SET deProd=@deProd,coUm=@coUm,
	estado=@estado,co_usua_modi=@co_usua_crea,fe_usua_modi=GETDATE()
	WHERE coProd=@coProd
END

GO
CREATE PROC SP_ERP_ALM_PRODUCTOS_ELIM
@coProd varchar(30),
@coEmp char(2)
AS
DELETE FROM ERP_ALM_PRODUCTOS WHERE coProd=@coProd AND coEmp=@coEmp;

GO
ALTER PROC SP_ERP_ALM_ALMACENES_LS
@opcion int,
@criterio varchar(30),
@coSuc char(2),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT coAlm,deAlm FROM ERP_ALM_ALMACENES WHERE coEmp=@coEmp and coSuc=@coSuc
END
IF @opcion=1
BEGIN
	SELECT coAlm,deAlm FROM ERP_ALM_ALMACENES WHERE coEmp=@coEmp and coSuc=@coSuc
END
GO
SELECT * FROM ERP_ALM_ALMACENES
GO

SELECT * FROM EPR_COM_PROVCLI
SELECT * FROM ERP_ALM_PRODUCTOS



/*CREATE TABLE ERP_COM_TIPO_DOCUMENTO(
	idDoc int identity(1,1),
	coDoc char(3) primary key,
	deDoc varchar(50),
	numero int,
	coEmp char(2),
	estado char(1),
	st_registro bit
)
GO
INSERT INTO ERP_COM_TIPO_DOCUMENTO (coDoc,deDoc,numero,coEmp,estado,st_registro) VALUES ('OCI','ORDEN DE COMPRA IMPORACIÓN',0,'01','A',1)

GO
CREATE TABLE EPR_COM_ORDEN_PEDIDO_CAB(
	idPed int identity(1,1),
	coDoc char(3),
	numero char(8),
	nuPed varchar(15) primary key,
	coProvCli varchar(20),
	dirEnt varchar(100),
	fePed datetime,
	feRec datetime,
	tcVen decimal(18,4),
	coCond char(4),
	deObsInt varchar(250),
	deObsProv varchar(250),
	estado char(1),
	st_registro bit,
	coEmp char(2),
	coSuc char(2),
	co_usua_crea varchar(30),
	fe_usua_crea datetime,
	co_usua_modi varchar(30),
	fe_usua_modi datetime
)
GO
CREATE TABLE EPR_COM_ORDEN_PEDIDO_DET(
	idPedDet int identity(1,1),
	nuPed varchar(15),
	item int,
	coProd varchar(30),
	deProd varchar(100),
	cant decimal(18,2),
	coUm char(4),
	imp_u_ext decimal(18,2),
	imp_u_nac decimal(18,2),
	porImp decimal(18,4),
	imp_i_ext decimal(18,2),
	imp_i_nac decimal(18,2),
	imp_n_ext decimal(18,2),
	imp_n_nac decimal(18,2)
)
GO

*/
