﻿create database yemek_takip;

drop database yemek_takip;

use yemek_takip;

select * from Foods;
select * from Users;
select * from Fridges;
select * from My_Foods; 
select * from Notification; 

delete from Foods;
delete from Users;
delete from Fridges;
delete from My_Foods;
delete from Notification;

insert into Users(Ad,Soyad,Eposta,Sifre) values ('Buğra','Daryal','oyuasx@gmail.com','123asd')
insert into My_Foods(Fridges_id,Foods_id,bozulma_tarihi,eklenme_tarihi) values (1,1,'11.11.1111','11.11.1111')
insert into Foods(yemek_ismi,protein_yüzde) values ('Erik',7)
