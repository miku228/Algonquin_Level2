USE sakila;

UPDATE film SET description ='A Epic @Drama of a Feminist And a Mad Scientist who must Battle a Teacher in The Canadian Rockies'  WHERE film_id = 1;

UPDATE film SET description = 'A Astounding Epistle of a Database Administrator And a Explorer who must Find a #Car in Ancient China' WHERE film_id = 2;

UPDATE film SET description = 'A Astounding Reflection of a Lumberjack And a Car who must Sink a Lumberjack #% in A Baloon Factory' WHERE film_id = 3;

UPDATE film SET description = 'A Fanciful Documentary of a Frisbee And a Lumberjack who must Chase a

Monkey in.; A Shark Tank' WHERE film_id = 4;

UPDATE film SET description = 'A Fast-Paced! Documentary of a Pastry Chef And a Dentist who must Pursue a Forensic Psychologist* in The Gulf of Mexico' WHERE film_id = 5; commit;

SHOW tables;

DESCRIBE film;

ALTER TABLE film ADD urlsafe VARCHAR(255);

DROP FUNCTION IF EXISTS clean_string;

DELIMITER :

CREATE FUNCTION clean_string (oldString varchar(255)) 
RETURNS varchar(255)
DETERMINISTIC 
BEGIN
	RETURN REPLACE(oldString, ' ', '');
END:

DELIMITER ;

SELECT clean_string(" this is a test");

SELECT clean_string(" this is a test for step4 ;`*^-!#$%)('&%$");


DROP FUNCTION IF EXISTS clean_string;

DELIMITER :

CREATE FUNCTION clean_string (oldString varchar(255)) 
RETURNS varchar(255)
DETERMINISTIC 
BEGIN
	declare newString01 varchar(255);
	set newString01 =  REGEXP_REPLACE(oldString,'[: .;!@#$%* ]', '');
	RETURN REPLACE(newString01, ' ', '');
END:

DELIMITER ;

SELECT film_id, title, description, clean_string(description) AS NewDescription 
FROM film LIMIT 5;
