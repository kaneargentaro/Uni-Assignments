drop table WINE;
drop table RETAILER;

create table RETAILER
(Retailer_ID CHAR(4) NOT NULL,
Retailer_Name CHAR(30) NOT NULL,
primary key(Retailer_ID));

create table WINE
(Wine_ID CHAR(4) NOT NULL,
Wine_Name CHAR(30) NOT NULL,
Wine_Vintage SMALLINT NOT NULL,
Wine_Price SMALLINT NOT NULL,
Retailer_ID CHAR(4) NOT NULL,
primary key (Wine_ID, Retailer_ID),
foreign key(Retailer_ID) references RETAILER(Retailer_ID));

insert into RETAILER values('1001','Dan Murphys');
insert into RETAILER values('1002','Woolworths');

insert into WINE values('101','Grange','2010','750','1001');
insert into WINE values('102','Grange','2006','700','1001');
insert into WINE values('103','Reserve Shiraz','2013','10','1001');
insert into WINE values('104','Grey Label Shiraz','2012','35','1001');
insert into WINE values('105','Patricia Shiraz','2009','50','1001');
insert into WINE values('106','Ten Acres Shiraz','2012','25','1001');
insert into WINE values('107','Double Barrel Shiraz','2012','15','1001');
insert into WINE values('108','Platinum Label Shiraz','2006','170','1001');
insert into WINE values('103','Reserve Shiraz','2013','9','1002');
insert into WINE values('104','Grey Label Shiraz','2012','33','1002');
insert into WINE values('105','Patricia Shiraz','2009','44','1002');
insert into WINE values('106','Ten Acres Shiraz','2012','22','1002');
insert into WINE values('107','Double Barrel Shiraz','2012','12','1002');

spool /home/kargenta/q2.txt
set echo on;

select Wine_Name, Wine_Vintage, Wine_Price
from WINE
where Retailer_ID = 1001 AND Wine_Price < 20;

select Wine_Name, Wine_Price, Retailer_Name
from WINE, RETAILER
where WINE.Retailer_ID = RETAILER.Retailer_ID and Wine_Vintage = 2012 and RETAILER.Retailer_ID = 1001;

set echo off;
spool off;