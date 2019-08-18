drop table WINE;
drop table RETAILER;
drop table SELLS;
drop table WINEMAKER;
drop table MANUFACTURES;
drop table FOOD;
drop table SCORE;
drop table RATING;

create table RETAILER
(Retailer_ID CHAR(4) NOT NULL,
Retailer_Name CHAR(30) NOT NULL,
primary key(Retailer_ID));

create table WINE
(Wine_ID CHAR(4) NOT NULL,
Wine_Name CHAR(30) NOT NULL,
Wine_Vintage SMALLINT NOT NULL,
primary key (Wine_ID));

create table FOOD
(Food_ID CHAR(4) NOT NULL,
Food_Desc CHAR(20) NOT NULL,
primary key(Food_ID));

create table SCORE
(Score_ID CHAR(4) NOT NULL,
Score_Desc CHAR(20) NOT NULL,
primary key(Score_ID));

create table WINEMAKER
(Winemaker_ID CHAR(4) NOT NULL,
Winemaker_Name CHAR(30) NOT NULL,
primary key(Winemaker_ID));

create table SELLS 
(Retailer_ID CHAR(4) NOT NULL,
Wine_ID CHAR(4) NOT NULL,
Wine_Price SMALLINT NOT NULL,
primary key (Retailer_ID, Wine_ID),
foreign key (Retailer_ID) references RETAILER(Retailer_ID),
foreign key (Wine_ID) references WINE (Wine_ID));

create table MANUFACTURES
(Winemaker_ID CHAR(4) NOT NULL,
Wine_ID CHAR(4) NOT NULL,
primary key(Winemaker_ID, Wine_ID),
foreign key (Winemaker_ID) references WINEMAKER(Winemaker_ID),
foreign key (Wine_ID) references WINE(Wine_ID));

create table RATING
(Food_ID CHAR(4) NOT NULL,
Wine_ID CHAR(4) NOT NULL,
Score_ID CHAR(4) NOT NULL,
primary key (Wine_ID, Food_ID, Score_ID));
foreign key (Wine_ID) references WINE(Wine_ID),
foreign key (Food_ID) references FOOD(Food_ID),
foreign key (Score_ID) references SCORE(Score_ID));

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

insert into WINEMAKER values('1','Penfolds');
insert into WINEMAKER values('2','Jacobs Creek');
insert into WINEMAKER values('3','Wolf Blass');
insert into WINEMAKER values('4','Browns Brothers');
insert into WINEMAKER values('5','Barrabool Hills');

insert into MANUFACTURES values('1','101');
insert into MANUFACTURES values('1','102');
insert into MANUFACTURES values('2','103');
insert into MANUFACTURES values('3','104');
insert into MANUFACTURES values('4','105');
insert into MANUFACTURES values('4','106');
insert into MANUFACTURES values('2','107');
insert into MANUFACTURES values('3','108');

insert into FOOD values('1','Steak');
insert into FOOD values('2','Beef Sausage');
insert into FOOD values('3','Chicken');
insert into FOOD values('4','Fish');

insert into SCORE values('1','Try Another Wine');
insert into SCORE values('2','OK');
insert into SCORE values('3','Compatible');
insert into SCORE values('4','Very Compatible');
insert into SCORE values('5','Excellent');

insert into RATING values('1','101','5');
insert into RATING values('2','101','1');
insert into RATING values('3','101','1');
insert into RATING values('4','101','1');
insert into RATING values('1','102','5');
insert into RATING values('2','102','1');
insert into RATING values('3','102','1');
insert into RATING values('4','102','1');
insert into RATING values('1','103','5');
insert into RATING values('2','103','3');
insert into RATING values('3','103','1');
insert into RATING values('4','103','1');
insert into RATING values('1','104','4');
insert into RATING values('2','104','5');
insert into RATING values('3','104','1');
insert into RATING values('4','104','1');
insert into RATING values('1','105','4');
insert into RATING values('2','105','4');
insert into RATING values('3','105','1');
insert into RATING values('4','105','1');
insert into RATING values('1','106','4');
insert into RATING values('2','106','3');
insert into RATING values('3','106','1');
insert into RATING values('4','106','1');
insert into RATING values('1','107','5');
insert into RATING values('2','107','5');
insert into RATING values('3','107','1');
insert into RATING values('4','107','1');
insert into RATING values('1','108','4');
insert into RATING values('2','108','3');
insert into RATING values('3','108','1');
insert into RATING values('4','108','1');

spool /home/kargenta/q4.txt
set echo on;

UPDATE SELLS
SET Wine_Price = Wine_Price*1.1
WHERE Retailer_ID = 1001;

SELECT Wine_Name, Wine_Vintage, Wine_Price
FROM WINE, SELLS, RATING
WHERE SELLS.Wine_ID = RATING.Wine_ID and RATING.Wine_ID = WINE.Wine_ID and SELLS.Retailer_ID = Retailer_ID and Retailer_ID = 1001 AND RATING.Food_ID = Food_ID and RATING.Food_ID = 1 and RATING.Score_ID = Score_ID and RATING.Score_ID = 5;

SELECT Wine_Name, Wine_Price, Retailer_Name
FROM WINE, RATING, RETAILER, SELLS
WHERE SELLS.Wine_ID = RATING.Wine_ID and RATING.Wine_ID = WINE.Wine_ID and SELLS.Retailer_ID = RETAILER.Retailer_ID and RATING.Score_ID >= 3 AND RATING.Food_ID = 2;

set echo off;
spool off;