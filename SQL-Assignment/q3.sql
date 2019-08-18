drop table RETAILER;
drop table WINE;
drop table SELLS;

create table RETAILER
(Retailer_ID CHAR(4) NOT NULL,
Retailer_Name CHAR(30) NOT NULL,
primary key(Retailer_ID));

create table WINE
(Wine_ID CHAR(4) NOT NULL,
Wine_Name CHAR(30) NOT NULL,
Wine_Vintage SMALLINT NOT NULL,
primary key (Wine_ID));

create table SELLS 
(Retailer_ID CHAR(4) NOT NULL,
Wine_ID CHAR(4) NOT NULL,
Wine_Price SMALLINT NOT NULL,
primary key (Retailer_ID, Wine_ID),
foreign key (Retailer_ID) references RETAILER(Retailer_ID),
foreign key (Wine_ID) references WINE (Wine_ID));

insert into RETAILER values('1001','Dan Murphys');
insert into RETAILER values('1002','Woolworths');

insert into WINE values('101','Grange','2010');
insert into WINE values('102','Grange','2006');
insert into WINE values('103','Reserve Shiraz','2013');
insert into WINE values('104','Grey Label Shiraz','2012');
insert into WINE values('105','Patricia Shiraz','2009');
insert into WINE values('106','Ten Acres Shiraz','2012');
insert into WINE values('107','Double Barrel Shiraz','2012');
insert into WINE values('108','Platinum Label Shiraz','2006');

insert into SELLS values('1001','101','750');
insert into SELLS values('1001','102','700');
insert into SELLS values('1001','103','10');
insert into SELLS values('1001','104','35');
insert into SELLS values('1001','105','50');
insert into SELLS values('1001','106','25');
insert into SELLS values('1001','107','15');
insert into SELLS values('1001','108','170');
insert into SELLS values('1002','103','9');
insert into SELLS values('1002','104','33');
insert into SELLS values('1002','105','44');
insert into SELLS values('1002','106','22');
insert into SELLS values('1002','107','12');

spool /home/kargenta/q3.txt
set echo on;

select Wine_Name, Wine_Vintage, Wine_Price
from WINE, SELLS
where SELLS.Wine_ID = Wine.Wine_ID and SELLS.Retailer_ID = Retailer_ID and Retailer_ID = 1001 AND SELLS.Wine_Price = Wine_Price and SELLS.Wine_Price < 20;

select Wine_Name, Wine_Price, Retailer_Name
from WINE, RETAILER, SELLS
where SELLS.Wine_ID = Wine.Wine_ID and SELLS.Retailer_ID = RETAILER.Retailer_ID AND Wine_Vintage = 2012 AND SELLS.Retailer_ID = 1001;

set echo off;
spool off;