create database RoutesData;

use RoutesData;


create table Driver(
        DriverID int not null,
        primary key (DriverID),
        FIO varchar(255),
        JobStartedDate date,
        Description varchar(255)
        
);

create table Bus(
        BusID int not null,
        primary key (BusID),
        Number varchar(8),
        Color varchar(20),
        DriverID int,
        foreign key (DriverID) references Driver(DriverID)         
);


create table Route(
        RouteID int not null,
        primary key (RouteID),
        DestinationName varchar(255), 
        DepartureName varchar(255),
        DepartureDate datetime,
        ArrivalDate datetime,
        Status varchar(20), 
        BusID int,
        foreign key (BusID) references Bus(BusID)
);
             

insert into Driver values(678567, 'Karpenko Nikolay Borisovich', '2014-12-04', 'Empty');
insert into Bus values(427289, '2434AB-7', 'White', 678567);
insert into Route values(134523, 'Brest', 'Minsk', '2020-12-05 17:23:00', '2020-12-05 20:47:00', 'Scheduled', 427289);
insert into Route values(152378, 'Brest', 'Minsk', '2020-12-06 17:23:00', '2020-12-06 20:47:00', 'Scheduled', 427289);
insert into Route values(145278, 'Minsk', 'Brest', '2020-12-06 12:20:00', '2020-12-06 15:47:00', 'Scheduled', 427289);

insert into Driver values(678239, 'Lyadov Sergey Alexandrovich', '2020-02-04', 'Empty');
insert into Bus values(427834, '2495AB-7', 'White', 678239);
insert into Route values(177734, 'Mogilev', 'Minsk', '2020-12-06 10:13:00', '2020-12-06 13:49:00', 'Scheduled', 427834);



insert into Driver values(642385, 'Makov Vasiliy Borisovich', '2016-04-25', 'Empty');
insert into Bus values(482954, '9234AB-7', 'White', 642385);
insert into Route values(132374, 'Orsha', 'Mogilev', '2020-12-07 14:32:00', '2020-12-07 16:02:00', 'Scheduled', 482954);
insert into Route values(124122, 'Orsha', 'Vitebsk', '2020-12-09 09:30:00', '2020-12-09 10:42:00', 'Scheduled', 482954);


insert into Driver values(623494, 'Zhuk Pavel Alexeevich', '2009-10-04', 'Empty');
insert into Bus values(429525, '9345AB-7', 'Yellow', 623494);
insert into Route values(123743, 'Minsk', 'Grodno', '2020-12-01 10:23:00', '2020-12-01 13:47:00', 'Completed', 429525);
insert into Route values(124854, 'Grodno', 'Minsk', '2020-12-01 17:23:00', '2020-12-01 20:47:00', 'Completed', 429525);


insert into Driver values(672345, 'Hodko Svetlana Pavlovna', '2013-01-09', 'Empty');
insert into Bus values(478524, '1184AB-7', 'White', 672345);
insert into Route values(129435, 'Minsk', 'Rogachev', '2020-12-09 14:50:00', '2020-12-09 17:15:00', 'Scheduled', 478524);
insert into Route values(123235, 'Rogachev', 'Minsk', '2020-12-09 17:50:00', '2020-12-09 20:15:00', 'Scheduled', 478524);

insert into Bus values(478555, '9934AB-7', 'White', 672345);
insert into Route values(117834, 'Minsk', 'Rogachev', '2020-12-02 14:50:00', '2020-12-02 17:15:00', 'Completed', 478555);
