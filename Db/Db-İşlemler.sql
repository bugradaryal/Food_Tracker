create database yemek_takip;

drop database yemek_takip;

use yemek_takip;

select * from Foods;
select * from Users;
select * from Fridges;
select * from My_Foods;

delete from Foods;
delete from Users;
delete from Fridges;
delete from My_Foods;


insert into Users(Ad,Soyad,Eposta,Sifre) values ('Buðra','Daryal','bugradaryal@hotmail.com','123asd')
