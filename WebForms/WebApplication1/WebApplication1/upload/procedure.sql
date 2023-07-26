DELIMITER $$
USE `profileapplication`$$
CREATE PROCEDURE `getRoleName` (name varchar(20))
BEGIN
	SELECT * FROM userrolestatic WHERE roleID = 
    (select roleId from userrole where userId = 
    (select userId from userdata where firstname=name)) ;
END$$

DELIMITER ;

DELIMITER $$
USE `profileapplication`$$
CREATE PROCEDURE `getCountryName` (id int)
BEGIN
	SELECT * FROM country WHERE countryID = 
    (select countryId from userdata where countryId=id) ;
END$$

DELIMITER ;

call getUserDetails(81);

call getRoleName("sujeet");

call getCountryName(91);
select * from state_view;