use yemek_takip;



create table Foods(
id int PRIMARY KEY IDENTITY(1,1),
yemek_ismi varchar(40) NOT NULL,

protein_y�zde int,
ya�_y�zde int,
karbonhidrat_y�zde int,

kalori int,

/* burada kullanaca��m yemek verilerini https://www.diyetkolik.com sitesinden buldum. */

protein_gr int,
ya�_gr int,
karbonhidrat_gr int,
sodyum_gr int,
potasyum_gr int,
kalsiyum_gr int,
lif_gr int,
kollestrol_gr int,
);



create table Users(
id int PRIMARY KEY IDENTITY(1,1),
Ad varchar(30) NOT NULL,
Soyad varchar(30) NOT NULL,
Eposta varchar(30) UNIQUE NOT NULL,
Sifre varchar(30) NOT NULL,
);

create table Fridges(
id int PRIMARY KEY FOREIGN KEY REFERENCES Users(id),
buzdolab�_id int IDENTITY(1,1) UNIQUE,
);

create table My_Foods(
id int PRIMARY KEY IDENTITY(1,1) FOREIGN KEY REFERENCES Fridges(buzdolab�_id),
yemek_no int FOREIGN KEY REFERENCES Foods(id),
);
