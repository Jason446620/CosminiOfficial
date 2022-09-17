create schema Cosminis;

create table Cosminis.users(
		userId int identity primary key,
		username varchar(50) unique not null,
		password varchar(30) not null,
		account_age datetime not null default getdate(),
		goldCount int not null default 0,
  		eggCount int not null default 0,
  		gemCount int not null default 0,
  		eggTimer datetime not null default getdate(),
  		notifications int not null default 0,
  		aboutMe varchar(500) not null default 'Enter about me here'
 		);

create table Cosminis.companions(
		companionId int identity primary key,
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		species_fk int not null foreign key references Cosminis.species(speciesId) on delete cascade on update cascade,
		emotion int not null foreign key references Cosminis.emotionChart(emotionId) on delete cascade on update cascade default 5 ,
		nickname varchar(30) not null default '',
		hunger int not null default 69,
		mood int not null default 69,
		timeSinceLastChangedMood datetime not null default getdate(),
		timeSinceLastChangedHunger datetime not null default getdate(),
		timeSinceLastPet datetime not null default getdate(),
		companion_birthday datetime not null default getdate()
		);
	
insert into Cosminis.companions (user_fk, species_fk, emotion, nickname) values (2, 2, 7, 'Jason');
	
create table Cosminis.conversation(
		conversationId int identity primary key,
		species_fk int not null foreign key references Cosminis.species(speciesId),
		quality int not null,
		message varchar (150) not null
		);
	
create table Cosminis.species(
		speciesId int identity primary key,
		element_fk int not null foreign key references Cosminis.elements(elementId) on delete cascade on update cascade,
		opposingEle int not null foreign key references Cosminis.elements(elementId),
		foodElement_fk int not null foreign key references Cosminis.foodElement(foodElementId) on delete cascade on update cascade default 7,
		oppFoodElement_fk int not null foreign key references Cosminis.foodElement(foodElementId) default 7,
		class_fk int  not null foreign key references Cosminis.class(classId) on delete cascade on update cascade default 4,
		speciesName varchar(25) not null,
		description varchar(255) not null,
		isMega bit not null default 0
		);	
	
create table Cosminis.class(
		classId int identity primary key,
		className varchar(15) not null,
		baseStr int not null default 10,
		baseDex int not null default 10,
		baseInt int not null default 10
		);
	
create table Cosminis.elements(
		elementId int identity primary key,
		elementType varchar(15) not null
		);
	
create table Cosminis.foodElement(
		foodElementId int identity primary key,
		foodElement varchar(15) not null
		);
		
create table Cosminis.foodStats(
		foodStatsId int identity primary key,
		foodElement_fk int not null foreign key references Cosminis.foodElement(foodElementId) on delete cascade on update cascade,
		description varchar(255) not null,
		foodName varchar(45) not null,
		hungerRestore int not null
		);
	
create table Cosminis.foodInventory(
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		foodStats_fk int not null foreign key references Cosminis.foodStats(foodStatsId) on delete cascade on update cascade,
		foodCount int not null default 0,
		primary key (user_fk, foodStats_fk)
		);
	
create table Cosminis.friends(
		userFrom_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		userTo_fk int not null foreign key references Cosminis.users(userId),
		status varchar(8) not null check (status in ('Pending', 'Accepted', 'Removed', 'Blocked')),
		primary key (userFrom_fk, userTo_fk)
		);
	
create table Cosminis.posts(
		postId int identity primary key,
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		content varchar(600) not null
		);
		
create table Cosminis.likes(
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		post_fk int not null foreign key references Cosminis.posts(postId),
		primary key (user_fk, post_fk)
		);
	
create table Cosminis.comments(
		commentId int identity primary key,
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		post_fk int not null foreign key references Cosminis.posts(postId),
		content varchar(255) not null
		);
	
create table Cosminis.orders(
		orderId int identity primary key,
		user_fk int not null foreign key references Cosminis.users(userId) on delete cascade on update cascade,
		cost money not null default 0.00,
		gems int not null default 0,
		timeOrdered datetime not null default getdate()
		);

create table Cosminis.emotionChart(
		emotionId int identity primary key,
		quality int not null,
		emotion varchar (15) not null
		);

/*COMMAND TO SCAFFOLD
 * 
 * dotnet ef dbcontext scaffold "Server=tcp:cosminis.database.windows.net,1433;Initial Catalog=Cosminis;Persist Security Info=False;User ID=cosmega;Password=qaw4avp4ABY@pjn1mhu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer --startup-project ../ComsiniAPI --force --output-dir Entities --no-onconfiguring
 * 
 * ^Force output dir part might not have the right syntax...
 * 
 */	
insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (6,'Wear floaties.', 'Devil Fruit', 50);		

insert into Cosminis.foodInventory (user_fk, foodStats_fk, foodCount) values (4, 1, -49999);

insert into Cosminis.friends (userTo_Fk, userFrom_fk, status) values (5, 3, 'Accepted');

select * from Cosminis.companions;
delete from Cosminis.users where userId = 1;

update Cosminis.users set showcaseCompanion_Fk = 3 where userId = 4;

drop table Cosminis.foodStats;

--Entries for EmotionChart--
insert into Cosminis.emotionChart (quality, emotion) values (0, 'Hopeless');
insert into Cosminis.emotionChart (quality, emotion) values (1, 'Fear');
insert into Cosminis.emotionChart (quality, emotion) values (2, 'Hostile');
insert into Cosminis.emotionChart (quality, emotion) values (3, 'Depressed');
insert into Cosminis.emotionChart (quality, emotion) values (4, 'Irritable');
insert into Cosminis.emotionChart (quality, emotion) values (5, 'Calm');
insert into Cosminis.emotionChart (quality, emotion) values (6, 'Chill');
insert into Cosminis.emotionChart (quality, emotion) values (7, 'Happy');
insert into Cosminis.emotionChart (quality, emotion) values (8, 'Excited');
insert into Cosminis.emotionChart (quality, emotion) values (9, 'Blissful');
insert into Cosminis.emotionChart (quality, emotion) values (10, 'Hopeful');
--Entries for POSTS--

insert into Cosminis.posts (user_fk, content) values (1, 'Hey everyone, this is my first post!');

insert into Cosminis.posts (user_fk, content) values (5, 'My name is Jimmy and I really love this social app.');

insert into Cosminis.posts (user_fk, content) values (4, 'I just LOVE the companions in this app!');

insert into Cosminis.posts (user_fk, content) values (5, 'Hey yall, its me again Jimmy.  I really want to get all the companions this site has to offer.  The graphics are obviously super cool and all my friends wanna register on this website too!');

--Entries for FRIENDS--

insert into Cosminis.friends (userFrom_fk, userTo_fk, status) values (7, 2, 'Accepted');

insert into Cosminis.friends (userFrom_fk, userTo_fk, status) values (5, 4, 'Pending');

insert into Cosminis.friends (userFrom_fk, userTo_fk, status) values (3, 10, 'Blocked');

insert into Cosminis.friends (userFrom_fk, userTo_fk, status) values (10, 1, 'Accepted');

insert into Cosminis.friends (userFrom_fk, userTo_fk, status) values (10, 7, 'Accepted');

--Entries for LIKES--

insert into Cosminis.likes (user_fk, post_fk) values (1, 4);

insert into Cosminis.likes (user_fk, post_fk) values (2, 4);

insert into Cosminis.likes (user_fk, post_fk) values (3, 2);

--Entries for FOODINVENTORY--

insert into Cosminis.foodInventory (user_fk, foodStats_fk, foodCount) values (2, 1, 10);

--Entries for CLASS--

insert into Cosminis.class (className, BaseStr, BaseDex, BaseInt) values ('Witch', 5, 10, 15);

insert into Cosminis.class (className, BaseStr, BaseDex, BaseInt) values ('Marauder', 15, 10, 5);

insert into Cosminis.class (className, BaseStr, BaseDex, BaseInt) values ('Gladiator', 10, 15, 5);

insert into Cosminis.class (className, BaseStr, BaseDex, BaseInt) values ('Generalist', 10, 10, 10);

--Entries for FOODELEMENT--

insert into Cosminis.foodElement (foodElement) values ('Spicy');

insert into Cosminis.foodElement (foodElement) values ('Cold');

insert into Cosminis.foodElement (foodElement) values ('Leafy');	

insert into Cosminis.foodElement (foodElement) values ('Fluffy');	

insert into Cosminis.foodElement (foodElement) values ('Blessed');	

insert into Cosminis.foodElement (foodElement) values ('Cursed');

insert into Cosminis.foodElement (foodElement) values ('Generic');

--Entries for Elements--

insert into Cosminis.elements (elementType) values ('Volcanic');

insert into Cosminis.elements (elementType) values ('Glacial');

insert into Cosminis.elements (elementType) values ('Forest');	

insert into Cosminis.elements (elementType) values ('Air');	

insert into Cosminis.elements (elementType) values ('Light');	

insert into Cosminis.elements (elementType) values ('Dark');

--Entries for FOODSTATS--

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (1,'Better have [soy] milk!', 'Chili', 50);

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (2,'I bet you wanted a hot lunch but your boss only bought cold cuts...', 'Cold cut sandwich', 50);

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (3,'A salad that gives you rose colored glasses.', '*Special* salad', 50);

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (4,'Make some smores, better have Infernog around.', 'Marshmallows', 50);

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (5,'Become blessed with this beverage.', 'Holy water', 50);

insert into Cosminis.foodStats (foodElement_fk, description, foodName, hungerRestore) values (6,'Wear floaties!', 'Devil fruit', 50);		

--Entries for USERS--

insert into Cosminis.users (username, password, goldCount, eggCount, account_age, eggTimer) values ('WaterMelon', 'F1re', 2, 2, GETDATE(), GETDATE());

insert into Cosminis.users (username, password, goldCount, eggCount, account_age, eggTimer) values ('Bruh', 'BoIIIIIIIIIIIIII', 32, 27, GETDATE(), GETDATE());

insert into Cosminis.users (username, password, goldCount, eggCount) values ('Idiot', 'Sandwich', 0, 0);

insert into Cosminis.users (username, password, goldCount, eggCount) values ('Sally', 'zionz546', 10005, 4);

insert into Cosminis.users (username, password, goldCount, eggCount) values ('Jimmy', 'doggo402', 31, 0);

--Entries for COMPANIONS--


insert into Cosminis.species (user_fk, species_fk, nickname, mood, hunger) values (3, 1, 'Supernovog!', 'Happy', 50);

insert into Cosminis.species (user_fk, species_fk, nickname, mood, hunger) values (1, 4, 'Seth', 'Chill', 69);

insert into Cosminis.species (user_fk, species_fk, nickname, mood, hunger) values (6, 6, 'Asmodeus', 'Angry', 6);

insert into Cosminis.species (user_fk, species_fk, nickname, mood, hunger) values (4, 3, 'Test', 'Chill', 100);

--Entries for SPECIES--

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (1, 2, 1, 2, 1, 'Infernog', 'Blasts off at the speed of light!');

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (2, 1, 2, 1, 2, 'Pluto', 'Chills shall overcome you!');

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (3, 4, 3, 4, 3, 'Buds', 'What they lack in focus, they make up for in chilllllll!');

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (4, 3, 4, 3, 3, 'Cosmo', 'A nebulous personality!');

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (5, 6, 5, 6, 2, 'Librian', 'May your rest be eternal.');

insert into Cosminis.species (element_fk, opposingEle, foodElement_fk, oppFoodElement_fk, class_fk, speciesName, description) values (6, 5, 6, 5, 1, 'Cancer', 'Blursed friend.');


delete from Cosminis.foodStats where foodStats = 4;

delete from Cosminis.companions where companion = 2;

delete from Cosminis.friends where userTo_fk = 15;

create table Cosminis.users;

alter table Cosminis.users drop column showcaseCompanion_fk;

alter table Cosminis.users add showcaseCompanion_fk int foreign key references Cosminis.companions(companionId);

alter table sublanguages.users drop constraint likes_cilantro;

--These are for our changes right now on 8/13

alter table Cosminis.companions add TimeSinceLastFed datetime not null default getdate();

alter table Cosminis.companions add TimeSinceLastPet datetime;

alter table Cosminis.users drop column showcaseCompanion_fk;

alter table Cosminis.companions add TimeSinceLastPet datetime;

alter table Cosminis.companions drop column TimeSinceLastPet;
alter table Cosminis.companions drop column TimeSinceLastFed;
alter table Cosminis.companions drop column timeSinceLastChangedMood;
alter table Cosminis.companions drop column timeSinceLastChangedHunger;
alter table Cosminis.companions drop column companion_birthday;

truncate table Cosminis.companions;

alter table Cosminis.users drop constraint FK__users__showcaseC__625A9A57;

alter table Cosminis.species add opposingEle int foreign key references WALS_P2.foodElement(foodElementId);

update Cosminis.species set opposingEle = 1 where speciesId = 4;

update Cosminis.species set opposingEle = 2 where speciesId = 3;

update Cosminis.species set opposingEle = 3 where speciesId = 6;

update Cosminis.species set opposingEle = 4 where speciesId = 5;

update Cosminis.species set opposingEle = 5 where speciesId = 8;

update Cosminis.species set opposingEle = 6 where speciesId = 7;