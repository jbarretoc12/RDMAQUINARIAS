/**/
CREATE TABLE EPR_COM_PROVCLI(
	id int identity(1,1),
	coProvCli varchar(30) primary key,
	deProvCli varchar(100),
	dirProvCli varchar(200),
	tipo varchar(20),
	coEmp Char(2),
	estado char(1),
	co_usua_crea varchar(30),
	fe_usua_crea datetime,
	co_usua_modi varchar(30),
	fe_usua_modi datetime 
)
GO
INSERT INTO EPR_COM_PROVCLI (coProvCli,deProvCli,dirProvCli,tipo,coEmp,estado,co_usua_crea,fe_usua_crea) VALUES 
('20102279256','CORMEI CONTRATISTAS GENERALES S.A.C.',' AV. LOS FAISANES NRO. 284 URB. LA CAMPIÑA ZONA DOS','NACIONAL','01','A','JBARRETO',GETDATE())
GO
CREATE TABLE ERP_COM_CONDICION_PAGO(
	idCond int identity(1,1),
	coCond char(3) primary key,
	deCond varchar(50),
	nuDias int,
	coEmp char(2),
	estado char(1)
)
GO
INSERT INTO ERP_COM_CONDICION_PAGO (coCond,deCond,nuDias,coEmp,estado) VALUES 
('C00','CONTADO',0,'01','A'),
('C30','CRÉDITO 30 DÍAS',30,'01','A'),
('C60','CRÉDITO 60 DÍAS',60,'01','A')
GO
SELECT * FROM ERP_COM_CONDICION_PAGO
GO
CREATE TABLE ERP_COM_TIPO_DOCUMENTO(
	idDoc int IDENTITY(1,1),
	coDoc char(3) PRIMARY KEY,
	deDoc varchar(50),
	numero int,
	coEmp char(2),
	estado char(1),
	st_registro bit
)
GO
INSERT INTO ERP_COM_TIPO_DOCUMENTO (coDoc,deDoc,numero,coEmp,estado,st_registro) VALUES 
('OCI','ORDEN DE COMPRA IMPORACIÓN',0,'01','A',1)
GO
SELECT * FROM ERP_COM_TIPO_DOCUMENTO
GO
CREATE TABLE EPR_COM_ORDEN_PEDIDO_CAB(
	[idPed] [int] IDENTITY(1,1) NOT NULL,
	[coDoc] [char](3) NULL,
	[numero] [char](8) NULL,
	[nuPed] [varchar](15) PRIMARY KEY,
	[coProvCli] [varchar](20) NULL,
	[dirEnt] [varchar](100) NULL,
	[fePed] [datetime] NULL,
	[feRec] [datetime] NULL,
	coMon char(1),--D=DOLARES / S=SOLES,
	[tcVen] [decimal](18, 4) NULL,
	[coCond] [char](4) NULL,
	[deObsInt] [varchar](250) NULL,
	[deObsProv] [varchar](250) NULL,
	imp_n_nac decimal(18,2),
	imp_i_nac decimal(18,2),
	imp_t_nac decimal(18,2),
	[estado] [char](1) NULL,--P=SOLICITUD / E=SOL. ENVIADA / O=ORDEN DE COMPRA 
	[st_registro] [bit] NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[co_usua_crea] [varchar](30),
	[fe_usua_crea] [datetime],
	[co_usua_modi] [varchar](30),
	[fe_usua_modi] [datetime],
	stSolicitud bit,
	stEnviado bit,
	stOrdenado bit,
	stEnviarOrden bit
)
GO
create TABLE EPR_COM_ORDEN_PEDIDO_DET(
	idPedDet [int] IDENTITY(1,1) NOT NULL,
	nuPed [varchar](15) NULL,
	item [int] NULL,
	coProd [varchar](30) NULL,
	deProd [varchar](100) NULL,
	tipoBien char(1),--B=BIENES / S=SERVICIOS
	cant [decimal](18, 2) NULL,
	coUm [char](4) NULL,
	--[imp_u_ext] [decimal](18, 2) NULL,
	imp_u_nac decimal(18, 2) NULL,
	porDcto decimal(18,6),
	imp_d_nac decimal(18,2),
	imp_n_nac decimal(18,2),
	porImp decimal(18,4),
	imp_i_nac decimal(18,2),
	imp_t_nac decimal(18, 2) NULL,
	deObs varchar(200),
	coEmp char(2)
) 
GO
CREATE PROC SP_EPR_COM_PROVCLI_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT coProvCli,deProvCli,dirProvCli FROM EPR_COM_PROVCLI WHERE estado='A' AND coEmp=@coEmp AND coProvCli=@criterio
END
IF @opcion=1
BEGIN
	SELECT coProvCli,deProvCli FROM EPR_COM_PROVCLI WHERE estado='A' AND coEmp=@coEmp
END
GO
CREATE PROC SP_ERP_COM_CONDICION_PAGO_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion = 1
BEGIN
	SELECT 0 'i', '%%' 'coCond','--Seleccionar--' 'deCond' UNION ALL
	SELECT 1 'i', coCond,deCond FROM ERP_COM_CONDICION_PAGO WHERE estado='A' AND coEmp=@coEmp
	ORDER BY 1,3
END
GO
CREATE PROC SP_ERP_COM_TIPO_DOCUMENTO_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	SELECT coDoc,coDoc+' - '+deDoc 'deDoc' FROM ERP_COM_TIPO_DOCUMENTO 
	WHERE coEmp=@coEmp AND estado='A' AND st_registro=1
END
GO
CREATE PROC SP_ERP_COM_TIPO_DOCUMENTO_GENERAR
@opc int,
@coDoc char(3),
@coEmp char(2)
AS
IF @opc = 1
BEGIN
	declare @num int; set @num = (SELECT numero + 1 FROM ERP_COM_TIPO_DOCUMENTO WHERE coDoc=@coDoc AND coEmp=@coEmp)
	select @num
END
GO

EXEC SP_ERP_COM_TIPO_DOCUMENTO_GENERAR 1,'OCI','01'
GO
CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_CAB_GB
	@opc int,
	@coDoc char(3),
	@numero char(8),
	@nuPed varchar(15),
	@coProvCli varchar(20),
	@dirEnt varchar(100),
	@fePed datetime,
	@feRec datetime,
	@coMon char(1),
	@tcVen decimal(18, 4),
	@coCond char(4),
	@deObsInt varchar(250),
	@deObsProv varchar(250),
	@imp_n_nac decimal(18,2),
	@imp_i_nac decimal(18,2),
	@imp_t_nac decimal(18,2),
	@estado char(1),
	@coEmp char(2),
	@coSuc char(2),
	@co_usua_crea varchar(30)
AS
IF @opc = 1
BEGIN
	if EXISTS(SELECT * FROM ERP_COM_TIPO_DOCUMENTO WHERE coDoc=@coDoc)
	BEGIN
		UPDATE ERP_COM_TIPO_DOCUMENTO SET numero=CONVERT(INT,@numero) WHERE coDoc=@coDoc AND coEmp=@coEmp;
	END

	INSERT INTO EPR_COM_ORDEN_PEDIDO_CAB (coDoc,numero,nuPed,coProvCli,dirEnt,fePed,feRec,coMon,tcVen,coCond,deObsInt,deObsProv,estado,st_registro,coEmp,coSuc,co_usua_crea,fe_usua_crea,imp_n_nac,imp_i_nac,imp_t_nac,stSolicitud)
	VALUES (@coDoc,@numero,@nuPed,@coProvCli,@dirEnt,@fePed,@feRec,@coMon,@tcVen,@coCond,@deObsInt,@deObsProv,@estado,1,@coEmp,@coSuc,@co_usua_crea,GETDATE(),@imp_n_nac,@imp_i_nac,@imp_t_nac,1)
END
IF @opc = 2
BEGIN
	UPDATE EPR_COM_ORDEN_PEDIDO_CAB SET coDoc=@coDoc,numero=@numero,nuPed=@nuPed,coProvCli=@coProvCli,
	dirEnt=@dirEnt,fePed=@fePed,feRec=@feRec,coMon=@coMon,tcVen=@tcVen,coCond=@coCond,deObsInt=@deObsInt,deObsProv=@deObsProv,estado=@estado,
	coSuc=@coSuc,co_usua_modi=@co_usua_crea,fe_usua_modi=GETDATE(),imp_n_nac=@imp_n_nac,imp_i_nac=@imp_i_nac,imp_t_nac=@imp_t_nac
	WHERE nuPed=@nuPed AND coEmp=@coEmp
END
GO
CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_CAB_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2),
@coSuc char(2)
AS
IF @opcion = 0
BEGIN
	SELECT P.idPed,P.coDoc,P.numero,P.nuPed,P.coProvCli,P.dirEnt,P.fePed,P.feRec,P.coMon,P.tcVen,
	P.coCond,P.deObsInt,P.deObsProv,P.imp_n_nac,P.imp_i_nac,P.imp_t_nac,P.estado,P.st_registro,
	P.coEmp,P.coSuc,P.co_usua_crea,P.fe_usua_crea,P.co_usua_modi,P.fe_usua_modi,ISNULL(P.stSolicitud,0) 'stSolicitud',ISNULL(P.stEnviado,0) 'stEnviado',ISNULL(P.stOrdenado,0) 'stOrdenado',
	ISNULL(P.stEnviarOrden,0) 'stEnviarOrden',
	PC.deProvCli,PC.dirProvCli FROM EPR_COM_ORDEN_PEDIDO_CAB P INNER JOIN EPR_COM_PROVCLI PC ON PC.coProvCli=P.coProvCli and PC.coEmp=P.coEmp
	WHERE P.coEmp=@coEmp AND P.idPed =CONVERT(int, @criterio)
END
IF @opcion = 1
BEGIN
	SELECT ROW_NUMBER() OVER (ORDER BY nuPed) 'Nro.',P.idPed,P.nuPed,pc.deProvCli,P.co_usua_crea,P.fePed,
	P.feRec,
	CASE WHEN P.coMon='D' THEN 'DOL' ELSE 'SOL' END 'coMon',
	P.imp_t_nac,CASE WHEN P.estado='P' THEN 'Solicitud [RFQ]' WHEN P.estado='E' THEN 'Sol. Envíado' WHEN P.estado='O' THEN 'Orden de Compra [OC]' END 'Status' 
	FROM EPR_COM_ORDEN_PEDIDO_CAB P INNER JOIN EPR_COM_PROVCLI PC ON PC.coProvCli=P.coProvCli and PC.coEmp=P.coEmp
	WHERE P.coEmp=@coEmp AND P.nuPed+P.coProvCli+PC.deProvCli+P.dirEnt LIKE '%'+@criterio+'%'
END
GO
--fernando suñiga;


go
CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_DET_LS
@opcion int,
@criterio varchar(30),
@tipoBien char(1),
@coEmp char(2)
AS
IF @opcion=0
BEGIN
	SELECT * FROM EPR_COM_ORDEN_PEDIDO_DET WHERE nuPed=@criterio AND coEmp=@coEmp AND tipoBien=@tipoBien
END

GO


CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_DET_GB
	@idPedDet int,
	@nuPed varchar(15),
	@item int,
	@coProd varchar(30),
	@deProd varchar(100),
	@tipoBien char(1),
	@cant decimal(18, 2),
	@coUm char(4),
	@imp_u_nac decimal(18, 2),
	@porDcto decimal(18,6),
	@imp_d_nac decimal(18,2),
	@imp_n_nac decimal(18,2),
	@porImp decimal(18,4),
	@imp_i_nac decimal(18,2),
	@imp_t_nac decimal(18, 2),
	@deObs varchar(200),
	@coEmp char(2)
AS
IF NOT EXISTS(SELECT idPedDet FROM EPR_COM_ORDEN_PEDIDO_DET WHERE idPedDet=@idPedDet AND nuPed=@nuPed AND coEmp=@coEmp)
BEGIN
	INSERT INTO EPR_COM_ORDEN_PEDIDO_DET (nuPed,item,coProd,deProd,tipoBien,cant,coUm,imp_u_nac,porDcto,imp_d_nac,imp_n_nac,porImp,imp_i_nac,imp_t_nac,deObs,coEmp)
	VALUES (@nuPed,@item,@coProd,@deProd,@tipoBien,@cant,@coUm,@imp_u_nac,@porDcto,@imp_d_nac,@imp_n_nac,@porImp,@imp_i_nac,@imp_t_nac,@deObs,@coEmp)
END
ELSE
BEGIN 
	UPDATE EPR_COM_ORDEN_PEDIDO_DET SET nuPed=@nuPed,item=@item,coProd=@coProd,deProd=@deProd,tipoBien=@tipoBien,cant=@cant,coUm=@coUm,
	imp_u_nac=@imp_u_nac,porDcto=@porDcto,imp_d_nac=@imp_d_nac,imp_n_nac=@imp_n_nac,porImp=@porImp,imp_i_nac=@imp_i_nac,
	imp_t_nac=@imp_t_nac,deObs=@deObs
	WHERE idPedDet=@idPedDet AND nuPed=@nuPed
END
GO

CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO
@nuPed varchar(12),
@estado char(1),
@coEmp char(2)
AS
UPDATE EPR_COM_ORDEN_PEDIDO_CAB SET estado=@estado,stEnviado=1 WHERE nuPed=@nuPed AND coEmp=@coEmp

GO

CREATE PROC SP_EPR_COM_ORDEN_PEDIDO_CAB_CAMBIAR_ESTADO_ORDEN_COMPRA
@nuPed varchar(12),
@estado char(1),
@coEmp char(2)
AS
UPDATE EPR_COM_ORDEN_PEDIDO_CAB SET estado=@estado,stOrdenado=1 WHERE nuPed=@nuPed AND coEmp=@coEmp

GO




GO
/*SELECT * FROM EPR_COM_PROVCLI
SELECT * FROM ERP_ALM_PRODUCTOS
SELECT * FROM EPR_COM_ORDEN_PEDIDO_DET

SELECT * FROM ERP_COM_TIPO_DOCUMENTO

SELECT * FROM EPR_COM_ORDEN_PEDIDO_CAB
SELECT * FROM EPR_COM_ORDEN_PEDIDO_DET
SP_HELP EPR_COM_ORDEN_PEDIDO_CAB*/


