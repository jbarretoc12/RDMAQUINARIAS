CREATE DATABASE BDPRUEBA;
GO
USE BDPRUEBA
--INSERT INTO ERP_CON_TIPO_CAMBIO (feTc,tcVen,tcCom) VALUES (GETDATE(),3.8770,3.8779)

--USE BDFMBK;
--DROP DATABASE BDPRUEBA

/*--SELECT * FROM SYS.TABLES WHERE NAME LIKE 'ERP_ADM'

ERP_ADM_EMPRESA
ERP_ADM_SUCURSAL
ERP_ADM_AREA
ERP_ADM_CARGO
ERP_ADM_MODULO
ERP_ADM_MENU
ERP_ADM_SUBMENU
ERP_ADM_SUBSUBMENU
ERP_ADM_PERIODO 

ERP_SOP_USUARIO
ERP_ADM_PERMISOS
*/

GO
CREATE TABLE ERP_ADM_EMPRESA(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coEmp] [char](2) PRIMARY KEY,
	[rucEmp] [varchar](30) NULL,
	[noEmp] [varchar](100) NULL,
	[comEmp] [varchar](100) NULL,
	[dirEmp] [varchar](150) NULL,
	[telEmp] [varchar](30) NULL,
	[urlEmp] [varchar](100) NULL,
	[imgEmp] [image] NULL,
	[estado] [char](1) NULL,
	[co_usua_crea] [varchar](30) NULL,
	[fe_usua_crea] [datetime] NULL,
	[co_usua_modi] [varchar](30) NULL,
	[fe_usua_modi] [datetime] NULL,
	[st_registro] [bit] NULL
)
GO
INSERT INTO ERP_ADM_EMPRESA (coEmp,rucEmp,noEmp,comEmp,dirEmp,telEmp,
urlEmp,imgEmp,estado,co_usua_crea,fe_usua_crea,st_registro)
VALUES ('01','20118201401','RIVERA DIESEL S.A.','RIVERA DIESEL','CAL.DOS MZA. C LOTE. 6 URB. INDUSTRIAL LA MERCED','348-1500',
'www.riveradiesel.com.pe',NULL,'A','JBARRETO',GETDATE(),1);
GO

CREATE TABLE ERP_ADM_SUCURSAL(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coSuc] [char](2) PRIMARY KEY,
	[noSuc] [varchar](50) NULL,
	[coEmp] [char](2) NULL,
	[dirSuc] [varchar](150) NULL,
	[telSuc] [varchar](30) NULL,
	[estado] [char](1) NULL,
	[co_usua_crea] [varchar](30) NULL,
	[fe_usua_crea] [datetime] NULL,
	[co_usua_modi] [varchar](30) NULL,
	[fe_usua_modi] [datetime] NULL,
	[st_registro] [bit] NULL 
);
GO
INSERT INTO ERP_ADM_SUCURSAL (coSuc,noSuc,coEmp,dirSuc,telSuc,
estado,co_usua_crea,fe_usua_crea,st_registro)
VALUES ('01','LIMA','01','CAL.DOS MZA. C LOTE. 6 URB. INDUSTRIAL LA MERCED','348-1500',
'A','JBARRETO',GETDATE(),1);
GO
CREATE TABLE ERP_ADM_AREA(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coAre] [char](3) PRIMARY KEY,
	[deAre] [varchar](50) NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[estado] [char](1) NULL,
	[co_usua_crea] [varchar](30) NULL,
	[fe_usua_crea] [datetime] NULL,
	[co_usua_modi] [varchar](30) NULL,
	[fe_usua_modi] [datetime] NULL,
	[st_registro] [bit] NULL
);
GO
INSERT INTO ERP_ADM_AREA (coAre,deAre,coEmp,coSuc,estado,
co_usua_crea,fe_usua_crea,st_registro)
VALUES ('001','DESARROLLO DE SISTEMAS','01','01','A',
'JBARRETO',GETDATE(),1)
GO
CREATE PROC SP_ERP_ADM_AREA_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=3
BEGIN
	SELECT 0 'i','%%' 'coAre','--Seleccionar Area--' 'deAre' UNION
	SELECT 1 'i',coAre,deAre FROM ERP_ADM_AREA 
	order by 1,3
END
GO
CREATE TABLE ERP_ADM_CARGO(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coCar] [char](4) PRIMARY KEY,
	[noCar] [varchar](50) NULL,
	[coAre] [char](3) NULL,
	[stJefe] [bit] NULL,
	[coEmp] [char](2) NULL,
	[stRegistro] [bit] NULL
);
GO
INSERT INTO ERP_ADM_CARGO (coCar,noCar,coAre,stJefe,coEmp,stRegistro)
VALUES ('0001','JEFE DE DESARROLLO','001',1,'01',1),('0002','PROGRAMADOR JUNIOR','001',0,'01',1)
GO
CREATE TABLE ERP_SOP_USUARIO(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coUsu] [varchar](30) PRIMARY KEY,
	[noUsu] [varchar](100) NULL,
	[deCor] [varchar](50) NULL,
	[coAre] [char](3) NULL,
	[coCar] [char](4) NULL,
	[noclave] [varchar](30) NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[imgFoto] [image] NULL,
	[imgFirma] [image] NULL,	
	[estado] [char](1) NULL,
	[co_usua_crea] [varchar](30) NULL,
	[fe_usua_crea] [datetime] NULL,
	[co_usua_modi] [varchar](30) NULL,
	[fe_usua_modi] [datetime] NULL,
	[st_registro] [bit] NULL
)
GO
INSERT INTO ERP_SOP_USUARIO (coUsu,noUsu,deCor,coAre,coCar,noclave,
coEmp,coSuc,imgFoto,imgFirma,estado,co_usua_crea,fe_usua_crea,st_registro)
VALUES 
('DCONDORI','DAVIS CONDORI','dcondori@riveradiesel.com.pe','001','0001','123',
'01','01',NULL,NULL,'A','JBARRETO',NULL,1),
('JBARRETO','JEFFER BARRETO CARHUAZ','jbarreto@riveradiesel.com.pe','001','0001','999',
'01','01',NULL,NULL,'A','JBARRETO',NULL,1)
GO
CREATE TABLE ERP_SOP_MODULO(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coMod] [char](4) PRIMARY KEY,
	[noMod] [varchar](50) NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[form] [bit] NULL,
	[nuOrd] [int] NULL,
	[stRegistro] [bit] NULL
)
GO
INSERT INTO ERP_SOP_MODULO (coMod,noMod,coEmp,coSuc,form,nuOrd,stRegistro)
VALUES ('0001','SOPORTE','01','01',0,1,1),
('0002','ADMINISTRACIÓN','01','01',0,2,1),
('0003','COMERCIAL','01','01',0,3,1),
('0004','CONTABILIDAD','01','01',0,4,1),
('0005','INVENTARIOS','01','01',0,5,1),
('0006','COMPRAS','01','01',0,6,1)
GO
CREATE TABLE ERP_SOP_MENU(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coMenu] [char](5) PRIMARY KEY,
	[noMenu] [varchar](50) NULL,
	[coMod] [char](4) NULL,
	[form] [bit] NULL,
	[nuOrd] [int] NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[stRegistro] [bit] NULL
) 
GO
INSERT INTO ERP_SOP_MENU (coMenu,noMenu,coMod,form,nuOrd,coEmp,coSuc,stRegistro)
VALUES 
('00001','Configuración','0001',0,1,'01','01',1),
('00002','Configurar Accesos','0001',0,2,'01','01',1),
('00003','Consultas','0001',0,4,'01','01',1),
('00004','Reportes','0001',0,5,'01','01',1),
('00005','Configuración','0002',0,1,'01','01',1),
--OPRACIONES
('00006','Table Pendientes','0005',0,1,'01','01',1),
('00007','Operaciones','0005',0,3,'01','01',1),
('00008','Productos','0005',0,4,'01','01',1),
('00009','Reportes','0005',0,5,'01','01',1),
('00010','Configuración','0005',0,6,'01','01',1),
--PEDIDOS
('00011','Tablero Pendientes','0006',0,1,'01','01',1),
('00012','Pedidos','0006',0,2,'01','01',1),
('00013','Productos','0006',0,3,'01','01',1),
('00014','Reportes','0006',0,4,'01','01',1),
('00015','Configuración','0006',0,5,'01','01',1)
--FIN COMPAR

GO
CREATE TABLE ERP_SOP_SUBMENU(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coSubMenu] [char](6) PRIMARY KEY,
	[noSubMenu] [varchar](200) NULL,
	[coMod] [char](4) NULL,
	[coMenu] [char](5) NULL,
	[nuOrd] [int] NULL,
	[form] [bit] NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[stRegistro] [bit] NULL
)
GO
INSERT INTO ERP_SOP_SUBMENU (coSubMenu,noSubMenu,coMod,coMenu,nuOrd,
form,coEmp,coSuc,stRegistro)
VALUES 
('000001','Gestionar Módulos','0001','00001',1,1,'01','01',1),
('000002','Accesos de Usuario','0001','00002',1,1,'01','01',1),
('000003','Gestionar Empresas','0002','00005',1,1,'01','01',1),
--('000004','Gestionar Sedes','0002','00005',2,1,'01','01',1),
('000005','Líneas','0005','00008',1,1,'01','01',1),
('000006','Sub Líneas','0005','00008',2,1,'01','01',1),
('000007','Marcas','0005','00008',3,1,'01','01',1),
('000008','Unidade de Medida','0005','00008',4,1,'01','01',1),
('000009','Registrar Producto','0005','00008',5,1,'01','01',1),
('000010','Ingreso Inventario','0005','00007',1,1,'01','01',1),
('000011','Salida Inventario','0005','00007',2,1,'01','01',1),
('000012','Transferencia entre Almacenes','0005','00007',3,1,'01','01',1),
('000013','Cierre de Periodo','0005','00007',4,1,'01','01',1),
('000014','Kardex General','0005','00014',5,1,'01','01',1),
('000015','Saldo Actual','0005','00014',6,1,'01','01',1),
--COMPRAS
--PEDIDOS
('000016','Solicitud de Presupuesto','0006','00013',1,1,'01','01',1),
('000017','Pedido de Compra','0006','00013',2,1,'01','01',1),
('000018','Proveedores','0006','00013',3,1,'01','01',1),
--PRODUCTOS
('000019','Registrar Producto','0006','00014',3,1,'01','01',1)
--FIM COMPRAS


--('000005','Accesos al Sistema','00003',2/*nuOrd*/,1/*form*/,'01','01',1/*stRegistro*/)
GO
/*SELECT * FROM ERP_SOP_SUBMENU
SELECT * FROM ERP_SOP_MODULO
SELECT * FROM ERP_SOP_MENU
GO*/

CREATE TABLE ERP_SOP_SUBSUBMENU(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coSubSubMenu] [char](7) NOT NULL,
	[noSubSubMenu] [varchar](50) NULL,
	[coMod] [char](4) NULL,
	[coSubMenu] [char](6) NULL,
	[nuOrd] [int] NULL,
	[form] [bit] NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[stRegistro] [bit] NULL
)
GO
--SELECT * FROM ERP_SOP_SUBSUBMENU
--GO
CREATE TABLE ERP_SOP_PERMISOS(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[coUsu] [varchar](30) NULL,
	[coEmp] [char](2) NULL,
	[coSuc] [char](2) NULL,
	[stMod] [bit] NULL,
	[coMod] [char](4) NULL,
	[stMenu] [bit] NULL,
	[coMenu] [char](5) NULL,
	[stSubMenu] [bit] NULL,
	[coSubMenu] [char](6) NULL,
	[stSubSubMenu] [bit] NULL,
	[coSubSubMenu] [char](7) NULL,
	[stGrabar] [bit] NULL,
	[stEditar] [bit] NULL,
	[stEliminar] [bit] NULL,
	[stReporte] [bit] NULL
)
GO
--SELECT * FROM ERP_SOP_PERMISOS
--TRUNCATE TABLE ERP_SOP_PERMISOS

  INSERT INTO ERP_SOP_PERMISOS (coUsu,coEmp,coSuc,coMod,/*noMod,*/coMenu,/*noMenu,*/coSubMenu,/*noSubMenu,*/coSubSubMenu,/*noSubSubMenu,*/ 
  stMod,stMenu,stSubMenu,stSubSubMenu,stGrabar,stEditar,stEliminar,stReporte)
   SELECT DISTINCT 'JBARRETO' as 'coUsu',EMP.coEmp,SUC.coSuc,MD.coMod,/*MD.noMod,*/ME.coMenu,/*ME.noMenu,*/SM.coSubMenu,  
   /*SM.noSubMenu,*/SSM.coSubSubMenu,/*SSM.noSubSubMenu,*/  
   case when MD.coMod IS null then 0 else 1 end AS 'stMod',
   case when ME.coMenu IS null then 0 else 1 end AS 'stMenu',
   case when SM.coSubMenu IS null then 0 else 1 end AS 'stSubMenu',
   case when SSM.coSubSubMenu IS null then 0 else 1 end AS 'stSubSubMenu',/*,1*/  
   1,1,1,1
   FROM ERP_ADM_EMPRESA EMP  
   INNER JOIN ERP_ADM_SUCURSAL SUC ON EMP.coEmp=SUC.coEmp  
   --LEFT JOIN U_USUARIO USU ON EMP.coEmp=USU.coEmp and SUC.coSuc=USU.coSuc  
   LEFT JOIN ERP_SOP_MODULO MD ON EMP.coEmp=MD.coEmp /*and SUC.coSuc=MD.coSuc*/ and MD.stRegistro=1  
   LEFT JOIN ERP_SOP_MENU ME ON MD.coMod=ME.coMod and EMP.coEmp=ME.coEmp /*and SUC.coSuc=ME.coSuc*/ and ME.stRegistro=1  
   LEFT JOIN ERP_SOP_SUBMENU SM ON SM.coMenu=ME.coMenu and EMP.coEmp=SM.coEmp /*and SUC.coSuc=SM.coSuc*/ and SM.stRegistro=1  
   LEFT JOIN ERP_SOP_SUBSUBMENU SSM ON SSM.coSubMenu=SM.coSubMenu and EMP.coEmp=SSM.coEmp /*and SUC.coSuc=SSM.coSuc*/ and SSM.stRegistro=1  
   LEFT JOIN ERP_SOP_PERMISOS PER ON PER.coEmp=EMP.coEmp and PER.coSuc=SUC.coSuc and PER.coMod=MD.coMod  
   and PER.coMenu=ME.coMenu and PER.coSubMenu=SM.coSubMenu and PER.coSubSubMenu=SSM.coSubSubMenu  
   --and PER.coUsu=USU.coUsu  
   WHERE EMP.coEmp='01' and SUC.coSuc='01' /*AND USU.coUsu=@coUsu*/ AND RTRIM('JBARRETO'+EMP.coEmp+SUC.coSuc+ isnull(MD.coMod,'')+isnull(ME.coMenu,'')+isnull(SM.coSubMenu,'')+isnull(SSM.coSubSubMenu,''))  
   NOT IN (select RTRIM(coUsu+coEmp+coSuc+isnull(coMod,'')+isnull(coMenu,'')+isnull(coSubMenu,'')+isnull(coSubSubMenu,'')) FROM ERP_SOP_PERMISOS WHERE coUsu='JBARRETO' and coEmp='01' and coSuc='01')  
    

---------PROCEDIMIENTOS ALMACENADOS


--SELECT * FROM ERP_ADM_EMPRESA
GO
CREATE PROC SP_ERP_ADM_EMPRESA_LS
@opcion int,
@criterio varchar(30)
AS
IF @opcion=1
BEGIN
	SELECT coEmp,noEmp FROM ERP_ADM_EMPRESA WHERE st_registro=1
END
IF @opcion=2
BEGIN
	SELECT coEmp,noEmp FROM ERP_ADM_EMPRESA WHERE st_registro=1 AND rucEmp+noEmp LIKE '%'+@criterio+'%'
END
IF @opcion=3
BEGIN
	SELECT * FROM ERP_ADM_EMPRESA WHERE st_registro=1 AND coEmp = @criterio
END
GO

--PROC. CRUD
CREATE PROC SP_ERP_ADM_EMPRESA_GB
	@opc int,
	@coEmp char(2),
	@rucEmp varchar(30),
	@noEmp varchar(100),
	@comEmp varchar(100),
	@dirEmp varchar(150),
	@telEmp varchar(30),
	@urlEmp varchar(100),
	@imgEmp image,
	@estado char(1),
	@co_usua_crea varchar(30),
	@varCoSuc char(2) OUTPUT
AS
if @opc = 1
begin
	DECLARE @COD CHAR(2);
	SET @COD=(SELECT RIGHT('00'+ CONVERT(VARCHAR,MAX(coEmp) + 1),2) FROM ERP_ADM_EMPRESA)
	INSERT INTO ERP_ADM_EMPRESA (coEmp,rucEmp,noEmp,comEmp,dirEmp,telEmp,urlEmp,imgEmp,estado,co_usua_crea,fe_usua_crea,st_registro)
	VALUES (@COD,@rucEmp,@noEmp,@comEmp,@dirEmp,@telEmp,@urlEmp,@imgEmp,@estado,@co_usua_crea,GETDATE(),1)
	SELECT @varCoSuc = @COD
end
if @opc = 2
begin
	UPDATE ERP_ADM_EMPRESA SET rucEmp=@rucEmp,noEmp=@noEmp,
	comEmp=@comEmp,dirEmp=@dirEmp,telEmp=@telEmp,urlEmp=@urlEmp,imgEmp=@imgEmp,estado=@estado,co_usua_modi=@co_usua_crea,fe_usua_modi=GETDATE()
	WHERE coEmp=@coEmp
	SELECT @varCoSuc = @coEmp
	
end
GO
CREATE PROC SP_ERP_ADM_EMPRESA_ELIM
@opc int,
@coEmp char(2)
AS
if @opc = 3
begin
	if exists(SELECT coSuc FROM ERP_ADM_SUCURSAL WHERE coEmp=@coEmp)
	begin
		UPDATE ERP_ADM_SUCURSAL SET st_registro=0, estado='X' WHERE coEmp=@coEmp
	end

	UPDATE ERP_ADM_EMPRESA SET st_registro=0, estado='X' WHERE coEmp=@coEmp
end
GO

--sp_help 'ERP_ADM_EMPRESA'

CREATE PROC SP_ERP_ADM_SUCURSAL_LS
@opcion int,
@criterio varchar(30),
@coEmp char(2)
AS
IF @opcion=1
BEGIN
	SELECT * FROM ERP_ADM_SUCURSAL WHERE st_registro=1 AND coEmp=@criterio
END
IF @opcion=2
BEGIN
	SELECT * FROM ERP_ADM_SUCURSAL WHERE st_registro=1 AND coSuc LIKE '%'+@criterio+'%'
END
IF @opcion=3
BEGIN
	SELECT * FROM ERP_ADM_SUCURSAL WHERE st_registro=1 AND coEmp=@coEmp AND coSuc=@criterio
END
GO
CREATE PROC SP_ERP_ADM_SUCURSAL_GB
@opc int,
@id int,
@coSuc char(2),
@noSuc varchar(50),
@coEmp char(2),
@dirSuc varchar(150),
@telSuc varchar(30),
@estado char(1),
@co_usua_crea varchar(30)
AS
if (@opc = 1) OR (@opc = 2)
begin
	if not exists(select coSuc from ERP_ADM_SUCURSAL where id=@id)
	begin
		DECLARE @COD CHAR(2)
		SET @COD=(SELECT RIGHT('00'+ CONVERT(VARCHAR, MAX(coSuc) + 1),2) FROM ERP_ADM_SUCURSAL)
		INSERT INTO ERP_ADM_SUCURSAL (coSuc,noSuc,coEmp,dirSuc,telSuc,estado,co_usua_crea,fe_usua_crea,st_registro)
		VALUES (@COD,@noSuc,@coEmp,@dirSuc,@telSuc,@estado,@co_usua_crea,GETDATE(),1)
	end
	else
	begin
		UPDATE ERP_ADM_SUCURSAL SET noSuc=@noSuc,coEmp=@coEmp,dirSuc=@dirSuc,telSuc=@telSuc,estado=@estado,co_usua_modi=@co_usua_crea,fe_usua_modi=GETDATE()
		WHERE coSuc=@coSuc
	end
	SELECT @COD
end

GO
CREATE PROC SP_ERP_ADM_SUCURSAL_ELIM
@opc int,
@coSuc int
AS
if @opc = 3 
begin 
	UPDATE ERP_ADM_SUCURSAL SET st_registro=0, estado='X' WHERE coSuc=@coSuc
end
GO
CREATE PROC SP_ERP_SOP_LOGEO 
@coEmp char(2),    
@coUsu varchar(30),    
@noClave varchar(30)    
as     
IF EXISTS(SELECT * FROM ERP_SOP_USUARIO WHERE coUsu=@coUsu and noclave=@noClave and coEmp=@coEmp)    
BEGIN     
 SELECT *  
 FROM ERP_SOP_USUARIO USU     
 INNER JOIN ERP_ADM_EMPRESA EMP ON USU.coEmp=EMP.coEmp    
 INNER JOIN ERP_ADM_SUCURSAL SUC ON SUC.coSuc=USU.coSuc AND SUC.coEmp=EMP.coEmp    
 INNER JOIN ERP_ADM_AREA ARE ON ARE.coAre=USU.coAre AND ARE.coEmp=EMP.coEmp    
 INNER JOIN ERP_ADM_CARGO CAR ON CAR.coCar=USU.coCar AND CAR.coEmp=EMP.coEmp AND USU.coAre=ARE.coAre    
 WHERE USU.coUsu=@coUsu and USU.noclave=@noClave and USU.coEmp=@coEmp     
END
GO

CREATE PROC SP_ERP_SOP_USUARIO_BUSCAR  
@opcion int,  
@criterio varchar(30),  
@coEmp char(2),  
@coSuc char(2)  
AS  
IF @opcion=1  
BEGIN  
 SELECT coUsu,noUsu,coSuc FROM ERP_SOP_USUARIO WHERE estado='A' AND coEmp=@coEmp and st_registro=1 AND coUsu+noUsu like '%'+@criterio+'%'   
END
GO
----222
--SP_HELPTEXT 'SP_ERP_SOP_LISTAR_PERMISOS'

CREATE PROC SP_ERP_SOP_LISTAR_PERMISOS    
@opcion int,    
@coUsu varchar(30),    
@coEmp char(2),    
@coSuc char(2),    
@coMod char(4),    
@coMenu char(5),    
@coSubMenu char(6),    
@coSubSubMenu char(7)    
as    
if @opcion=0    
begin    
 /*PASO 02: AGREGAREMOS REGISTROS NUEVOS DE LAS TABLAS PRINCIPALES AL DETALLE PERMISOS*/    
  INSERT INTO ERP_SOP_PERMISOS (coUsu,coEmp,coSuc,coMod,/*noMod,*/coMenu,/*noMenu,*/coSubMenu,/*noSubMenu,*/coSubSubMenu,/*noSubSubMenu,*/    
  stMod,stMenu,stSubMenu,stSubSubMenu/*,stRegistro*/)    
   SELECT DISTINCT @coUsu as 'coUsu',EMP.coEmp,SUC.coSuc,MD.coMod,/*MD.noMod,*/ME.coMenu,/*ME.noMenu,*/SM.coSubMenu,    
   /*SM.noSubMenu,*/SSM.coSubSubMenu,/*SSM.noSubSubMenu,*/    
   0 AS 'stMod',0 AS 'stMenu',0 AS 'stSubMenu',0 AS 'stSubSubMenu'/*,1*/    
   FROM ERP_ADM_EMPRESA EMP    
   INNER JOIN ERP_ADM_SUCURSAL SUC ON EMP.coEmp=SUC.coEmp    
   --LEFT JOIN U_USUARIO USU ON EMP.coEmp=USU.coEmp and SUC.coSuc=USU.coSuc    
   LEFT JOIN ERP_SOP_MODULO MD ON EMP.coEmp=MD.coEmp /*and SUC.coSuc=MD.coSuc*/ and MD.stRegistro=1    
   LEFT JOIN ERP_SOP_MENU ME ON MD.coMod=ME.coMod and EMP.coEmp=ME.coEmp /*and SUC.coSuc=ME.coSuc*/ and ME.stRegistro=1    
   LEFT JOIN ERP_SOP_SUBMENU SM ON SM.coMenu=ME.coMenu and EMP.coEmp=SM.coEmp /*and SUC.coSuc=SM.coSuc*/ and SM.stRegistro=1    
   LEFT JOIN ERP_SOP_SUBSUBMENU SSM ON SSM.coSubMenu=SM.coSubMenu and EMP.coEmp=SSM.coEmp /*and SUC.coSuc=SSM.coSuc*/ and SSM.stRegistro=1    
   LEFT JOIN ERP_SOP_PERMISOS PER ON PER.coEmp=EMP.coEmp and PER.coSuc=SUC.coSuc and PER.coMod=MD.coMod    
   and PER.coMenu=ME.coMenu and PER.coSubMenu=SM.coSubMenu and PER.coSubSubMenu=SSM.coSubSubMenu    
   --and PER.coUsu=USU.coUsu    
   WHERE EMP.coEmp=@coEmp and SUC.coSuc=@coSuc /*AND USU.coUsu=@coUsu*/ AND RTRIM(@coUsu+EMP.coEmp+SUC.coSuc+ isnull(MD.coMod,'')+isnull(ME.coMenu,'')+isnull(SM.coSubMenu,'')+isnull(SSM.coSubSubMenu,''))    
   NOT IN (select RTRIM(coUsu+coEmp+coSuc+isnull(coMod,'')+isnull(coMenu,'')+isnull(coSubMenu,'')+isnull(coSubSubMenu,'')) FROM ERP_SOP_PERMISOS WHERE coUsu=@coUsu and coEmp=@coEmp and coSuc=@coSuc)    
end    
if @opcion=1    
begin       
 select tab.*,MOD.nuOrd from (    
 SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coMod,MODU.noMod,    
 CONVERT(BIT,MAX(CONVERT(INT,ISNULL(stMod,0)))) AS 'stMod' FROM ERP_SOP_PERMISOS P   
  LEFT JOIN ERP_SOP_MODULO MODU ON MODU.coMod=P.coMod    
 WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc AND stRegistro=1 AND P.coMod is not null    
 GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coMod,MODU.noMod    
 ) as tab INNER JOIN ERP_SOP_MODULO MOD ON MOD.coMod=tab.coMod     
 WHERE MOD.stRegistro=1    
 order by MOD.nuOrd asc  
end    
if @opcion=2    
begin       
 select tab.*,ME.nuOrd,ME.form from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coMenu,MNU.noMenu,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stMenu,0)))) AS 'stMenu' FROM ERP_SOP_PERMISOS P  LEFT JOIN ERP_SOP_MENU MNU  
  ON MNU.coMenu=P.coMenu   
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod /*AND P.stRegistro=1*/ and P.coMenu is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coMenu,MNU.noMenu    
 ) as tab INNER JOIN ERP_SOP_MENU ME ON ME.coMenu=tab.coMenu     
 WHERE ME.stRegistro=1    
 order by ME.nuOrd asc  
end    
if @opcion=3    
begin    
  select tab.*,SM.nuOrd,SM.form from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coSubMenu,SM.noSubMenu,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stSubMenu,0)))) AS 'stSubMenu' FROM ERP_SOP_PERMISOS P  LEFT JOIN ERP_SOP_SUBMENU SM  
  ON SM.coSubMenu=P.coSubMenu  
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod and P.coMenu=@coMenu /*AND stRegistro=1*/ and P.coSubMenu is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coSubMenu,SM.noSubMenu    
 ) as tab INNER JOIN ERP_SOP_SUBMENU SM ON SM.coSubMenu=tab.coSubMenu     
 WHERE SM.stRegistro=1    
 order by SM.nuOrd asc    
end    
if @opcion=4    
begin    
  select tab.*,SSM.nuOrd,SSM.form from (    
   SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coSubSubMenu,SSM.noSubSubMenu,    
   CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stSubSubMenu,0)))) AS 'stSubSubMenu' FROM ERP_SOP_PERMISOS P LEFT JOIN ERP_SOP_SUBSUBMENU SSM  
   ON SSM.coSubSubMenu=P.coSubSubMenu  
   WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod and P.coMenu=@coMenu and P.coSubMenu=@coSubMenu /*AND stRegistro=1*/ and P.coSubSubMenu is not null    
   GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coSubSubMenu,SSM.noSubSubMenu    
  ) as tab INNER JOIN ERP_SOP_SUBSUBMENU SSM ON SSM.coSubSubMenu=tab.coSubSubMenu     
  WHERE SSM.stRegistro=1    
  order by SSM.nuOrd asc     
end    
if @opcion=5    
begin    
 select tab.*,MOD.nuOrd from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coMod,M.noMod,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stMod,0)))) AS 'stMod' FROM ERP_SOP_PERMISOS P  LEFT JOIN ERP_SOP_MODULO M  
  ON M.coMod=P.coMod    
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc /*AND stRegistro=1*/ and P.stMod=1 AND P.coMod is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coMod,M.noMod    
 ) as tab INNER JOIN ERP_SOP_MODULO MOD ON MOD.coMod=tab.coMod     
 WHERE MOD.stRegistro=1    
 order by MOD.nuOrd asc  
end    
if @opcion=6    
begin     
  select tab.*,ME.nuOrd from (    
   SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coMenu,noMenu,    
   CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stMenu,0)))) AS 'stMenu' FROM ERP_SOP_PERMISOS P LEFT JOIN ERP_SOP_MENU MNU  
   ON MNU.coMenu=P.coMenu   
   WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod /*AND stRegistro=1*/ and P.stMenu=1  and P.coMenu is not null    
   GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coMenu,MNU.noMenu    
  ) as tab INNER JOIN ERP_SOP_MENU ME ON ME.coMenu=tab.coMenu     
  WHERE ME.stRegistro=1    
  order by ME.nuOrd asc   
end    
if @opcion=7    
begin    
 select tab.*,SM.nuOrd from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coSubMenu,SM.noSubMenu,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stSubMenu,0)))) AS 'stSubMenu' FROM ERP_SOP_PERMISOS P  LEFT JOIN ERP_SOP_SUBMENU SM  
  ON SM.coSubMenu=P.coSubMenu  
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod and P.coMenu=@coMenu /*AND stRegistro=1*/ and P.stSubMenu=1 and P.coSubMenu is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coSubMenu,SM.noSubMenu    
 ) as tab INNER JOIN ERP_SOP_SUBMENU SM ON SM.coSubMenu=tab.coSubMenu     
 WHERE SM.stRegistro=1    
 order by SM.nuOrd asc  
end    
if @opcion=8    
begin    
 select tab.*,SSM.nuOrd from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coSubSubMenu,SSM.noSubSubMenu,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stSubSubMenu,0)))) AS 'stSubSubMenu' FROM ERP_SOP_PERMISOS P LEFT JOIN ERP_SOP_SUBSUBMENU SSM  
  ON SSM.coSubSubMenu=P.coSubSubMenu  
  --WHERE coUsu='YABAD' AND coEmp='01' AND coSuc='01' and coMod='0001' and coMenu='00001' and coSubMenu='000001' and coSubSubMenu is not null    
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc and P.coMod=@coMod and P.coMenu=@coMenu and P.coSubMenu=@coSubMenu /*AND stRegistro=1*/ and P.stSubSubMenu=1 and P.coSubSubMenu is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coSubSubMenu,SSM.noSubSubMenu    
 ) as tab INNER JOIN ERP_SOP_SUBSUBMENU SSM ON SSM.coSubSubMenu=tab.coSubSubMenu     
 WHERE SSM.stRegistro=1    
 order by SSM.nuOrd asc    
end  
GO

CREATE PROC SP_ERP_SOP_LISTAR_PERMISOS_LISTAR_MODULOS  
@opcion int, 
@criterio varchar(20),
@coUsu varchar(30),    
@coEmp char(2),    
@coSuc char(2),    
@coMod char(4),    
@coMenu char(5),    
@coSubMenu char(6),    
@coSubSubMenu char(7) 
AS
IF @opcion=1
BEGIN
 select tab.*,MOD.nuOrd from (    
  SELECT distinct P.coUsu,P.coEmp,P.coSuc,P.coMod,M.noMod,    
  CONVERT(BIT,MAX(CONVERT(INT,ISNULL(P.stMod,0)))) AS 'stMod' FROM ERP_SOP_PERMISOS P  LEFT JOIN ERP_SOP_MODULO M  
  ON M.coMod=P.coMod    
  WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coSuc=@coSuc /*AND stRegistro=1*/ and P.stMod=1 AND P.coMod is not null    
  GROUP BY P.coUsu,P.coEmp,P.coSuc,P.coMod,M.noMod    
 ) as tab INNER JOIN ERP_SOP_MODULO MOD ON MOD.coMod=tab.coMod    
 and MOD.noMod LIKE '%'+@criterio+'%'
 WHERE MOD.stRegistro=1    
 order by MOD.nuOrd asc 
END
GO

/*SELECT * FROM ERP_SOP_MODULO
SELECT * FROM ERP_SOP_MENU
SELECT * FROM ERP_SOP_SUBMENU
SELECT * FROM ERP_SOP_SUBSUBMENU
SELECT * FROM ERP_SOP_PERMISOS
GO*/
CREATE PROC SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO
@opcion int,
@criterio varchar(30),
@coUsu varchar(30),
@coSuc char(2),
@coEmp char(2)
AS
if @opcion = 1
begin
	SELECT SOP.coMod 'codForm',M.noMod 'nomForm',SOP.* FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MODULO M ON M.coMod=SOP.coMod
	WHERE SOP.coMod=@criterio AND M.form=1 AND SOP.coMenu IS NULL AND SOP.coSubMenu IS NULL AND SOP.coSubSubMenu IS NULL
	AND SOP.coUsu=@coUsu AND SOP.coEmp=@coEmp and SOP.coSuc=@coSuc
end
if @opcion = 2
begin
	SELECT SOP.coMenu 'codForm',M.noMenu 'nomForm',
	ISNULL(SOP.stGrabar,0) 'stGrabar',ISNULL(SOP.stEditar,0) 'stEditar',ISNULL(SOP.stEliminar,0) 'stEliminar',ISNULL(SOP.stReporte,0) 'stReporte'
	FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MENU M ON M.coMenu=SOP.coMenu
	WHERE SOP.coMenu=@criterio AND M.form=1 AND SOP.coSubMenu IS NULL AND SOP.coSubSubMenu IS NULL
	AND SOP.coUsu=@coUsu AND SOP.coEmp=@coEmp and SOP.coSuc=@coSuc
end
if @opcion = 3
begin
	SELECT SOP.coSubMenu 'codForm',M.noSubMenu 'nomForm',
	ISNULL(SOP.stGrabar,0) 'stGrabar',ISNULL(SOP.stEditar,0) 'stEditar',ISNULL(SOP.stEliminar,0) 'stEliminar',ISNULL(SOP.stReporte,0) 'stReporte'
	FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBMENU M ON M.coSubMenu=SOP.coSubMenu
	WHERE SOP.coSubMenu=@criterio AND M.form=1 AND SOP.coSubSubMenu IS NULL
	AND SOP.coUsu=@coUsu AND SOP.coEmp=@coEmp and SOP.coSuc=@coSuc
end
if @opcion = 4
begin
	SELECT SOP.coSubSubMenu 'codForm',M.noSubSubMenu 'nomForm',
	ISNULL(SOP.stGrabar,0) 'stGrabar',ISNULL(SOP.stEditar,0) 'stEditar',ISNULL(SOP.stEliminar,0) 'stEliminar',ISNULL(SOP.stReporte,0) 'stReporte'
	FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBSUBMENU M ON M.coSubSubMenu=SOP.coSubSubMenu
	WHERE SOP.coSubSubMenu=@criterio AND M.form=1
	AND SOP.coUsu=@coUsu AND SOP.coEmp=@coEmp and SOP.coSuc=@coSuc
end

GO
CREATE PROC SP_ERP_SOP_PERMISOS_BUSCAR_FORMULARIO_GB
@nivel int,
@coForm varchar(10),
@stGrabar bit,
@stEditar bit,
@stEliminar bit,
@stReporte bit,
@coUsu varchar(30),
@coSuc char(2),
@coEmp char(2)
AS
if @nivel = 1
begin
	UPDATE ERP_SOP_PERMISOS SET stGrabar=@stGrabar,stEditar=@stEditar,stEliminar=@stEliminar,stReporte=@stReporte
	WHERE coMod=@coForm AND coMenu IS NULL AND coSubMenu IS NULL AND coSubSubMenu IS NULL
	AND coUsu=@coUsu AND coEmp=@coEmp and coSuc=@coSuc
end
if @nivel = 2
begin
	UPDATE ERP_SOP_PERMISOS SET stGrabar=@stGrabar,stEditar=@stEditar,stEliminar=@stEliminar,stReporte=@stReporte
	WHERE coMenu=@coForm AND coSubMenu IS NULL AND coSubSubMenu IS NULL
	AND coUsu=@coUsu AND coEmp=@coEmp and coSuc=@coSuc
end
if @nivel = 3
begin
	UPDATE ERP_SOP_PERMISOS SET stGrabar=@stGrabar,stEditar=@stEditar,stEliminar=@stEliminar,stReporte=@stReporte
	WHERE coSubMenu=@coForm AND coSubSubMenu IS NULL
	AND coUsu=@coUsu AND coEmp=@coEmp and coSuc=@coSuc
end
if @nivel = 4
begin
	UPDATE ERP_SOP_PERMISOS SET stGrabar=@stGrabar,stEditar=@stEditar,stEliminar=@stEliminar,stReporte=@stReporte
	WHERE coSubSubMenu=@coForm
	AND coUsu=@coUsu AND coEmp=@coEmp and coSuc=@coSuc	
end

GO
-------GRABAR PERMISOS

CREATE PROC SP_ERP_SOP_GRABAR_PERMISOS  
@opc int,  
@coUsu varchar(30),  
@coEmp char(2),  
@coSuc char(2),  
@coMod char(4),  
@coMenu char(5),  
@coSubMenu char(6),  
@coSubSubMenu char(7),  
@estado bit  
AS  
IF @opc=1  
BEGIN   
 UPDATE ERP_SOP_PERMISOS SET stMod=@estado WHERE coMod=@coMod and coEmp=@coEmp and coSuc=@coSuc and coUsu=@coUsu  
END  
IF @opc=2  
BEGIN   
 UPDATE ERP_SOP_PERMISOS SET stMenu=@estado WHERE coMenu=@coMenu and coMod=@coMod and coEmp=coEmp and coSuc=@coSuc and coUsu=@coUsu  
END  
IF @opc=3  
BEGIN   
 UPDATE ERP_SOP_PERMISOS SET stSubMenu=@estado WHERE coSubMenu=@coSubMenu and coMenu=@coMenu and coMod=@coMod and coEmp=coEmp and coSuc=@coSuc and coUsu=@coUsu  
END  
IF @opc=4  
BEGIN   
 UPDATE ERP_SOP_PERMISOS SET stSubSubMenu=@estado WHERE coSubSubMenu=@coSubSubMenu and coSubMenu=@coSubMenu and coMenu=@coMenu and coMod=@coMod and coEmp=coEmp and coSuc=@coSuc and coUsu=@coUsu  
END

GO

/*SELECT * FROM ( 
	 SELECT M.noMod AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte' FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MODULO M ON M.coMod=SOP.coMod
	 WHERE M.stRegistro=1 AND M.form=1 AND SOP.coMod IS NOT NULL AND SOP.coEmp='01' AND SOP.coSuc='01' AND SOP.coUsu='JBARRETO' AND M.noMod=''
	 UNION ALL
	 SELECT M.noMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte' FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_MENU M ON M.coMenu=SOP.coMenu
	 WHERE M.stRegistro=1 AND M.form=1 AND SOP.coMenu IS NOT NULL AND SOP.coEmp='01' AND SOP.coSuc='01' AND SOP.coUsu='JBARRETO'  AND M.noMenu=''
	 UNION ALL
	 SELECT M.noSubMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte' FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBMENU M ON M.coSubMenu=SOP.coSubMenu
	 WHERE M.stRegistro=1 AND M.form=1 AND SOP.coSubMenu IS NOT NULL AND SOP.coEmp='01' AND SOP.coSuc='01' AND SOP.coUsu='JBARRETO' AND M.noSubMenu='' 
	 UNION ALL 
	 SELECT M.noSubSubMenu AS 'noForm', ISNULL(SOP.stGrabar,0) 'stGrabar', ISNULL(SOP.stEditar,0) 'stEditar', ISNULL(SOP.stEliminar,0) 'stEliminar', ISNULL(SOP.stReporte,0) 'stReporte' FROM ERP_SOP_PERMISOS SOP LEFT JOIN ERP_SOP_SUBSUBMENU M ON M.coSubSubMenu=SOP.coSubSubMenu
	 WHERE M.stRegistro=1 AND M.form=1 AND SOP.coSubSubMenu IS NOT NULL AND SOP.coEmp='01' AND SOP.coSuc='01' AND SOP.coUsu='JBARRETO' AND M.noSubSubMenu=''
) TAB 
 
 
 SELECT * FROM ERP_SOP_PERMISOS
 SELECT * FROM ERP_SOP_MENU
 SELECT * FROM ERP_SOP_SUBMENU*/

 
 /********************************************************************************************************/
 /********************************************************************************************************/
 /********************************************************************************************************/
 CREATE PROC SP_ERP_SOP_MODULO
 @opcion int,
 @criterio varchar(30),
 @coEmp char(2)
 AS
 if @opcion=1
 begin
	SELECT coMod,noMod,nuOrd,form FROM ERP_SOP_MODULO WHERE stRegistro=1 and coEmp=@coEmp
	ORDER BY nuOrd
 end
 if @opcion=2
 begin
	SELECT coMod,noMod,nuOrd,form FROM ERP_SOP_MODULO WHERE stRegistro=1 and coEmp=@coEmp and coMod=@criterio
	ORDER BY nuOrd
 end
 if @opcion=3
 begin
	DECLARE @COD CHAR(4); 
	SET @COD=(SELECT RIGHT('0000'+ CONVERT(VARCHAR, CONVERT(INT,MAX(coMod)) + 1),4) FROM ERP_SOP_MODULO WHERE coEmp=@coEmp)
	SELECT @COD 'coMod'
 end
 GO
create PROC SP_ERP_SOP_MODULO_GB
	@opc int,
	@coMod char(4),
	@noMod varchar(50),
	@coEmp char(2),
	@coSuc char(2),
	@form bit,
	@nuOrd int
AS
if @opc = 1
begin
	/*DECLARE @COD CHAR(4); 
	SET @COD=(SELECT RIGHT('0000'+ CONVERT(VARCHAR, CONVERT(INT,MAX(coMod)) + 1),4) FROM ERP_SOP_MODULO)*/
	INSERT INTO ERP_SOP_MODULO (coMod,noMod,coEmp,coSuc,form,nuOrd,stRegistro)
	VALUES (/*@COD*/@coMod,@noMod,@coEmp,@coSuc,@form,@nuOrd,1)
end
if @opc = 2
begin
	UPDATE ERP_SOP_MODULO SET noMod=@noMod,coEmp=@coEmp,coSuc=@coSuc,form=@form,nuOrd=@nuOrd
	WHERE coMod=@coMod
end
GO
CREATE PROC SP_ERP_SOP_MODULO_ELIM
	@opc int,
	@coMod char(4),
	@coEmp char(2)
AS
if @opc = 3
begin
	if exists(SELECT coSubSubMenu FROM ERP_SOP_PERMISOS WHERE  coMod=@coMod AND coEmp=@coEmp)
	begin
		DELETE FROM ERP_SOP_PERMISOS WHERE coMod=@coMod AND coEmp=@coEmp
	end
	DELETE FROM ERP_SOP_MODULO WHERE coMod=@coMod and coEmp=@coEmp
end  
GO
 CREATE PROC SP_ERP_SOP_MENU
 @opcion int,
 @criterio varchar(30),
 @coEmp char(2),
 @coMod char(4)
 AS
 if @opcion=1
 begin
	SELECT coMenu,noMenu,form,nuOrd FROM ERP_SOP_MENU WHERE stRegistro=1 
	and coEmp=@coEmp and coMod=@coMod
	ORDER BY nuOrd
 end
 if @opcion=2
 begin
	SELECT coMenu,noMenu,form,nuOrd FROM ERP_SOP_MENU WHERE stRegistro=1 
	and coEmp=@coEmp and coMod=@coMod AND coMenu=@criterio
	ORDER BY nuOrd
 end
 GO
 
--sp_help 'ERP_SOP_MENU'
CREATE PROC SP_ERP_SOP_MENU_GB
	@opc int,
	@coMenu char(5),
	@noMenu varchar(50),
	@coMod char(4),
	@form bit,
	@nuOrd int,
	@coEmp char(2),
	@coSuc char(2)
AS
if @opc=1
begin
	DECLARE @COD CHAR(5); 
	SET @COD = (SELECT RIGHT('00000' + CONVERT(VARCHAR,MAX(CONVERT(INT,coMenu) + 1)),5) FROM ERP_SOP_MENU) 
	INSERT INTO ERP_SOP_MENU (coMenu,noMenu,coMod,form,nuOrd,coEmp,coSuc,stRegistro)
	VALUES (@COD,@noMenu,@coMod,@form,@nuOrd,@coEmp,@coSuc,1)
end
if @opc=2
begin
	UPDATE ERP_SOP_MENU SET noMenu=@noMenu,coMod=@coMod,form=@form,nuOrd=@nuOrd,coEmp=@coEmp,coSuc=@coSuc
	WHERE coMenu=@coMenu
end
GO
/*SELECT * FROM ERP_SOP_MODULO
SELECT * FROM ERP_SOP_MENU
GO
 SELECT * FROM ERP_SOP_SUBMENU*/
 
 CREATE PROC SP_ERP_SOP_SUBMENU
 @opcion int,
 @criterio varchar(30),
 @coEmp char(2),
 @coMod char(4),
 @coMenu char(5)
 AS
 if @opcion=1
 begin
	SELECT coSubMenu,noSubMenu,form,nuOrd FROM ERP_SOP_SUBMENU WHERE stRegistro=1 
	and coEmp=@coEmp and coMenu=@coMenu and coMod=@coMod
	ORDER BY nuOrd
 end
 if @opcion=2
 begin
	SELECT coSubMenu,noSubMenu,form,nuOrd FROM ERP_SOP_SUBMENU WHERE stRegistro=1 
	and coEmp=@coEmp and coMenu=@coMenu and coMod=@coMod AND coSubMenu=@criterio
	ORDER BY nuOrd
 end
 GO
 --SP_HELP 'ERP_SOP_SUBMENU'
-- SELECT * FROM ERP_SOP_SUBMENU
CREATE PROC SP_ERP_SOP_SUBMENU_GB
	@opc int,
	@coSubMenu char(6),
	@noSubMenu varchar(200),
	@coMod char(4),
	@coMenu char(5),
	@nuOrd int,
	@form bit,
	@coEmp char(2),
	@coSuc char(2)
AS
if @opc = 1
begin
	DECLARE @COD CHAR(6); 
	SET @COD = (select RIGHT('000000'+ CONVERT(varchar,MAX(CONVERT(int,coSubMenu)) + 1),6) from ERP_SOP_SUBMENU)
	INSERT INTO ERP_SOP_SUBMENU (coSubMenu,noSubMenu,coMod,coMenu,nuOrd,form,coEmp,coSuc,stRegistro)
	VALUES (@COD,@noSubMenu,@coMod,@coMenu,@nuOrd,@form,@coEmp,@coSuc,1)
end
if @opc = 2
begin
	UPDATE ERP_SOP_SUBMENU SET noSubMenu=@noSubMenu,coMod=@coMod,
	coMenu=@coMenu,nuOrd=@nuOrd,form=@form,coEmp=@coEmp,coSuc=@coSuc
	WHERE coSubMenu=@coSubMenu
end

GO

CREATE PROC SP_ERP_SOP_SUBMENU_ELIM
	@opc int,
	@coSubMenu char(6),
	@coMod char(4),
	@coMenu char(5),
	@coEmp char(2)
AS
if @opc = 3
begin
	--SELECT * FROM ERP_SOP_PERMISOS WHERE  coSubMenu='000001' AND coMod='0001' AND coMenu='00001' AND coUsu='JBARRETO' AND coEmp='01' AND coSuc='01'
	if exists(SELECT coSubSubMenu FROM ERP_SOP_PERMISOS WHERE  coSubMenu=@coSubMenu AND coMod=@coMod AND coMenu=@coMenu AND coEmp=@coEmp)
	begin
		DELETE FROM ERP_SOP_PERMISOS WHERE coSubMenu=@coSubMenu AND coMod=@coMod AND coMenu=@coMenu AND coEmp=@coEmp
	end
	DELETE FROM ERP_SOP_SUBMENU WHERE coSubMenu=@coSubMenu AND coMod=@coMod AND coMenu=@coMenu AND coEmp=@coEmp
end
GO
 /*SELECT * FROM ERP_SOP_SUBSUBMENU
 EXEC SP_ERP_SOP_SUBSUBMENU 2,'','01','0001','00001','000001'*/
 
 CREATE PROC SP_ERP_SOP_SUBSUBMENU
 @opcion int,
 @criterio varchar(30),
 @coEmp char(2),
 @coMod char(4),
 @coMenu char(5),
 @coSubMenu char(6)
 AS
 if @opcion=1
 begin
	SELECT coSubSubMenu,noSubSubMenu,form,nuOrd FROM ERP_SOP_SUBSUBMENU WHERE stRegistro=1 
	and coEmp=@coEmp and coMod=@coMod and coSubMenu=@coSubMenu
	ORDER BY nuOrd
 end
 if @opcion=2
 begin
	SELECT coSubSubMenu,noSubSubMenu,form,nuOrd FROM ERP_SOP_SUBSUBMENU WHERE stRegistro=1 
	and coEmp=@coEmp and coSubMenu=@coSubMenu and coMod=@coMod and coSubSubMenu=@criterio
	ORDER BY nuOrd
 end 
 GO
/*SP_HELP 'ERP_SOP_SUBSUBMENU'
SELECT * FROM ERP_SOP_SUBSUBMENU*/

CREATE PROC SP_ERP_SOP_SUBSUBMENU_GB
	@opc int,
	@coSubSubMenu char(7),
	@noSubSubMenu varchar(50),
	@coMod char(4),
	@coSubMenu char(6),
	@nuOrd int,
	@form bit,
	@coEmp char(2),
	@coSuc char(2)
AS
if @opc = 1
begin
	DECLARE @COD CHAR(7)
	SET @COD = (SELECT RIGHT('0000000'+ CONVERT(VARCHAR,CONVERT(INT,ISNULL(MAX(coSubSubMenu),0)) + 1),7) FROM ERP_SOP_SUBSUBMENU)
	INSERT INTO ERP_SOP_SUBSUBMENU (coSubSubMenu,noSubSubMenu,coMod,coSubMenu,nuOrd,form,coEmp,coSuc,stRegistro)
	VALUES (@COD,@noSubSubMenu,@coMod,@coSubMenu,@nuOrd,@form,@coEmp,@coSuc,1)
end
if @opc = 2
begin
	UPDATE ERP_SOP_SUBSUBMENU SET noSubSubMenu=@noSubSubMenu,coMod=@coMod,coSubMenu=@coSubMenu,nuOrd=@nuOrd,form=@form,coEmp=@coEmp,coSuc=@coSuc
	WHERE coSubSubMenu=@coSubSubMenu
end

GO
CREATE PROC SP_ERP_SOP_SUBSUBMENU_ELIM
	@opc int,
	@coSubSubMenu char(7),
	@coMod char(4),
	@coMenu char(5),
	@coSubMenu char(6),
	@coEmp char(2)
AS
if @opc = 3
begin
	if exists(SELECT coSubSubMenu FROM ERP_SOP_PERMISOS WHERE coSubSubMenu=@coSubSubMenu AND coMod=@coMod AND coMenu=@coMenu AND coSubMenu=@coSubMenu AND coEmp=@coEmp)
	begin
		DELETE FROM ERP_SOP_PERMISOS WHERE coSubSubMenu=@coSubSubMenu AND coMod=@coMod AND coMenu=@coMenu AND coSubMenu=@coSubMenu AND coEmp=@coEmp
	end

	DELETE FROM ERP_SOP_SUBSUBMENU WHERE coSubSubMenu=@coSubSubMenu and coMod=@coMod and coSubMenu=@coSubMenu and coEmp=@coEmp
end
GO

CREATE PROC SP_ERP_SOP_MENU_ELIM
	@opc int,
	@coMenu char(5),
	@coMod char(4),
	@coEmp char(2)
AS
if @opc=3
begin
	if exists(SELECT coSubSubMenu FROM ERP_SOP_PERMISOS WHERE coMenu=@coMenu AND coMod=@coMod AND coEmp=@coEmp)
	begin
		DELETE FROM ERP_SOP_PERMISOS WHERE coMenu=@coMenu AND coMod=@coMod AND coEmp=@coEmp
	end
	
	DELETE FROM ERP_SOP_MENU WHERE coMenu=@coMenu AND coMod=@coMod AND coEmp=@coEmp
end
GO

/*CREATE PROC SP_ERP_SOP_PERMISOS_BOTONES
@opcion int,
@coUsu varchar(30),
@coMod char(4),
@coMenu char(5),
@coSubMenu char(6),
@coSubSubMenu char(7),
@coEmp char(2)
AS
IF @opcion=1 --PERMISO MODULO
BEGIN
	SELECT P.coUsu,M.noMod FROM ERP_SOP_PERMISOS P LEFT JOIN ERP_SOP_MODULO M ON M.coMod=P.coMod AND M.coEmp=P.coEmp AND M.coSuc=P.coSuc
	WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coMod=@coMod 
	AND P.coMenu IS NULL AND P.coSubMenu IS NULL AND P.coSubSubMenu IS NULL
END
IF @opcion=2 --PERMISO MENU
BEGIN
	SELECT P.coUsu,M.noMenu FROM ERP_SOP_PERMISOS P INNER JOIN ERP_SOP_MENU M ON M.coMenu=P.coMenu AND M.coMod=P.coMod AND M.coEmp=P.coEmp AND P.coSuc=M.coSuc
	WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coMod=@coMod AND P.coMenu=@coMenu AND P.coSubMenu IS NULL AND P.coSubSubMenu IS NULL
END
IF @opcion=3 --PERMISO SUB MENU
BEGIN
	SELECT P.coUsu,SM.noSubMenu FROM ERP_SOP_PERMISOS P INNER JOIN ERP_SOP_SUBMENU SM ON SM.coSubMenu=P.coSubMenu AND SM.coEmp=P.coEmp AND SM.coSuc=P.coSuc
	WHERE P.coUsu=@coUsu AND  P.coEmp=@coEmp AND  P.coMod=@coMod AND  P.coMenu=@coMenu AND P.coSubMenu=@coSubMenu AND P.coSubSubMenu IS NULL
END
IF @opcion=4 --PERMISO SUB SUB MENU
BEGIN
	SELECT P.coUsu,SSM.noSubSubMenu FROM ERP_SOP_PERMISOS P INNER JOIN ERP_SOP_SUBSUBMENU SSM ON SSM.coSubSubMenu=P.coSubSubMenu AND SSM.coEmp=P.coEmp AND SSM.coSuc=P.coSuc
	WHERE P.coUsu=@coUsu AND P.coEmp=@coEmp AND P.coMod=@coMod AND P.coMenu=@coMenu AND P.coSubMenu=@coSubMenu AND P.coSubSubMenu=@coSubSubMenu
END





/*SELECT * FROM ERP_SOP_MODULO
SELECT * FROM ERP_SOP_MENU
SELECT * FROM ERP_SOP_SUBMENU
SELECT * FROM ERP_SOP_SUBSUBMENU
SELECT * FROM ERP_SOP_PERMISOS*/


---------------------------------------------------------------------------------------------
---------------------------------------EMPRESA-----------------------------------------------


/*CREATE TABLE ERP_SOP_ACCESOS_DIRECTOS(
	idAd int identity(1,1),
)*/