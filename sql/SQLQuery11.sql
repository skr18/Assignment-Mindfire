ALTER TABLE IdsOfRolesAndUsers
ADD foreign  KEY (RoleId) references Roles(RoleId);

ALTER TABLE IdsOfRolesAndUsers
ADD foreign  KEY (UserId) references UserDetails(UserId);



ALTER TABLE UserDetails
ADD foreign  KEY (PresentCountryId) references Country(CountryId);

ALTER TABLE UserDetails
ADD foreign  KEY (PermanentCountryId) references Country(CountryId);

ALTER TABLE UserDetails
ADD foreign  KEY (PresentStateId) references State(StateId);

ALTER TABLE UserDetails
ADD foreign  KEY (PermanentStateId) references State(StateId);

ALTER TABLE State
ADD foreign  KEY (CountryId) references Country(CountryId);

insert into Country values(1,'India')

insert into Country values(2,'Pakistan')

insert into Country values(3,'Uk')

insert into Country values(4,'Usa')

drop table state

insert into States values(1,1,'Odisha')

insert into states values(2,2,'Lahore')

insert into states values(3,3,'NewYork')

insert into states values(4,4,'England')

select * from state
select * from country