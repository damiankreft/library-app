
delimiter //
CREATE TRIGGER insert_lease 
    AFTER INSERT ON Lease
    FOR EACH ROW 
    BEGIN 
        UPDATE Account SET Account.lease_counter = Account.lease_counter+1 WHERE Account.id = NEW.account_id; 
    END;//

CREATE PROCEDURE addLease (IN res_code VARCHAR(17), IN acc_id INT, IN lib_id INT, duration VARCHAR(10))
    BEGIN
    INSERT INTO Lease (account_id, librarian_id, resource_instance_id, lease_start, lease_duration)
    VALUES (acc_id, lib_id, res_code, CURDATE(), duration);
    END //

delimiter ;


-- 1 INSERT
INSERT INTO ACCOUNT (firstname, lastname, email) VALUES ('Admin', 'Admin', 'admin@example-library.com');

-- 1 UPDATE
UPDATE Account SET firstname = 'Administrator' WHERE email = 'admin@example-library.com';

-- 1 DELETE
DELETE FROM Account WHERE email = 'admin@example-library.com';

-- 1 podwojny JOIN
SELECT resource_code, generic_resource_name FROM ResourceInstance ri INNER JOIN Edition e ON ri.edition_id = e.id INNER JOIN GenericResource gr ON gr.id = e.generic_resource_id; 

-- 5 zapytan agregujacych
-- Zapytanie 1.
SELECT SEC_TO_TIME(lease_duration) FROM Lease;

-- Zapytanie 2
SELECT ADDTIME(lease_start, SEC_TO_TIME(lease_duration)) * FROM Lease;

-- Zapytanie 3.
SELECT sum(lease_counter) as "# of leased resources total" FROM Account;

-- Zapytanie 4
SELECT MAX(lease_counter) as "highest # of leased resources" FROM Account;

-- Zapytanie 5.
SELECT COUNT(*), generic_resource_name FROM Edition 
INNER JOIN GenericResource ON GenericResource.id = Edition.generic_resource_id 
GROUP BY generic_resource_id;