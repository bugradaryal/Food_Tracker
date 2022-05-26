create database yemek_takip;

drop database yemek_takip;

use yemek_takip;

select * from Foods;
select * from Users;
select * from Fridges;
select * from My_Foods; 
select * from Notifications; 
select * from User_articles;
select * from Notification_Counts;
select * from NotificationType;

delete from Foods;
delete from Users;
delete from Fridges;
delete from My_Foods;
delete from Notifications;
delete from User_articles;
delete from Notification_Counts;
delete from NotificationType;

insert into Users(Ad,Soyad,Eposta,Sifre,Cinsiyet) values ('Buğra','Daryal','oyuasx@gmail.com','123asd','Erkek');
