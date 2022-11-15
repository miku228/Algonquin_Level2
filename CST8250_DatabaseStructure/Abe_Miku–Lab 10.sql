SHOW databases;

CREATE DATABASE Lab10;

USE Lab10;

SHOW tables;

CREATE TABLE product (
  product_id INT auto_increment PRIMARY KEY,
  name VARCHAR(100),  
  quantity INT,  
  price DECIMAL(5,2)
);

DELIMITER &&

CREATE PROCEDURE insert_rows(IN v_name VARCHAR(100), IN v_qty INT, IN v_price DECIMAL(5,2))
BEGIN
	INSERT INTO product (name, quantity, price)
    VALUES(v_name, v_qty, v_price);
END &&

DELIMITER ;

CALL insert_rows('camera', 1, 300.00); 
CALL insert_rows('phone', 1, 200.00);
CALL insert_rows('pc', 1, 800.00); 
CALL insert_rows('TV', 1, 500.00); 
CALL insert_rows('display', 1, 300.00); 

SELECT * FROM product;


CREATE TABLE product_log (
	log_id int auto_increment PRIMARY KEY,
	product_id INT,
	name VARCHAR(100),  
	quantity INT,  
	price DECIMAL(5,2)
);

DROP TRIGGER IF EXISTS tr_up_pro;
DROP TRIGGER IF EXISTS tr_dl_pro;

CREATE TRIGGER tr_up_pro
BEFORE UPDATE ON product
FOR EACH ROW
	INSERT INTO product_log (product_id, name, quantity, price)
    VALUE(OLD.product_id, OLD.name, OLD.quantity, OLD.price);
    
CREATE TRIGGER tr_dl_pro
BEFORE DELETE ON product
FOR EACH ROW
	INSERT INTO product_log (product_id, name, quantity, price)
    VALUE(OLD.product_id, OLD.name, OLD.quantity, OLD.price);


UPDATE product
SET name = "DISPLAY"
WHERE product_id = 5;

UPDATE product
SET quantity = 4
WHERE product_id = 4;

DELETE FROM product
WHERE product_id = 3;



SELECT * FROM product_log;
