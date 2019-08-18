drop table WINE;
drop table WINEMAKER;

create table WINEMAKER
(Winemaker_ID CHAR(4) NOT NULL,
Winemaker_Name CHAR(30) NOT NULL,
primary key(Winemaker_ID));

create table WINE
(Wine_ID CHAR(4) NOT NULL,
Wine_Name CHAR(30) NOT NULL,
Wine_Vintage SMALLINT NOT NULL,
Wine_Price SMALLINT NOT NULL,
Winemaker_ID CHAR(4) NOT NULL,
primary key (Wine_ID),
foreign key(Winemaker_ID) references WINEMAKER(Winemaker_ID));

insert into WINEMAKER values('1','Penfolds');
insert into WINEMAKER values('2','Jacobs Creek');
insert into WINEMAKER values('3','Wolf Blass');
insert into WINEMAKER values('4','Browns Brothers');
insert into WINEMAKER values('5','Barrabool Hills');

insert into WINE values('101','Grange','2010','750','1');
insert into WINE values('102','Grange','2006','700','1');
insert into WINE values('103','Reserve Shiraz','2013','10','2');
insert into WINE values('104','Grey Label Shiraz','2012','35','3');
insert into WINE values('105','Patricia Shiraz','2009','50','4');
insert into WINE values('106','Ten Acres Shiraz','2012','25','4');
insert into WINE values('107','Double Barrel Shiraz','2012','15','2');
insert into WINE values('108','Platinum Label Shiraz','2006','170','3');

spool /home/kargenta/q1.txt
set echo on;

select Wine_Name, Wine_Vintage, Wine_Price
from WINE
where Wine_Price < 20;

select Wine_Name, Wine_Price, Winemaker_Name
from WINE, WINEMAKER
where WINE.Winemaker_ID = WINEMAKER.Winemaker_ID and Wine_Vintage = 2012;

set echo off;
spool off;