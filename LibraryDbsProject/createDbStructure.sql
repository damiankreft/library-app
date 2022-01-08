CREATE TABLE Account (
    id INT NOT NULL AUTO_INCREMENT,
    lastname VARCHAR(40) NOT NULL,
    firstname VARCHAR(60) NOT NULL,
    lease_counter MEDIUMINT UNSIGNED DEFAULT 0,
    email VARCHAR(255),
    rating FLOAT DEFAULT 10,
    password VARCHAR(64),
    salt VARCHAR(255),
    token VARCHAR(255),
    PRIMARY KEY (id)
);

CREATE TABLE Author (
    id INT NOT NULL AUTO_INCREMENT,
    fullname VARCHAR(120) NOT NULL,
    INDEX (fullname),
    PRIMARY KEY (id)
);

CREATE TABLE Nationality (
    id INT NOT NULL AUTO_INCREMENT,
    country VARCHAR(61) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE ResourceType (
    id INT NOT NULL AUTO_INCREMENT,
    type_name VARCHAR(255),
    PRIMARY KEY(id)
);

CREATE TABLE Translator (
    id INT NOT NULL AUTO_INCREMENT,
    lastname VARCHAR(40) NOT NULL,
    firstname VARCHAR(60),
    PRIMARY KEY (id)
);

CREATE TABLE Institution (
    id INT NOT NULL AUTO_INCREMENT,
    institution_name VARCHAR(255),
    INDEX (institution_name),
    PRIMARY KEY (id)
);

CREATE TABLE Librarian (
    account_id INT NOT NULL AUTO_INCREMENT,
    access_level TINYINT NOT NULL,
    PRIMARY KEY (account_id),
    FOREIGN KEY (account_id) REFERENCES Account(id)
);

CREATE TABLE GenericResource (
    id INT NOT NULL AUTO_INCREMENT,
    resource_type INT NOT NULL,
    generic_resource_name VARCHAR(255) NOT NULL,
    INDEX (generic_resource_name),
    PRIMARY KEY (id),
    FOREIGN KEY (resource_type) REFERENCES ResourceType(id)
);

CREATE TABLE GenericResourceHold (
    generic_resource_id INT NOT NULL,
    resource_reservation_date DATETIME NOT NULL,
    FOREIGN KEY (generic_resource_id) REFERENCES GenericResource(id)
);

CREATE TABLE Edition (
    id INT NOT NULL AUTO_INCREMENT,
    generic_resource_id INT NOT NULL,
    recompense DECIMAL(19, 4),
    leaseable BOOLEAN,
    isbn_13 VARCHAR(13) NOT NULL,
    date_published SMALLINT,
    PRIMARY KEY (id),
    FOREIGN KEY (generic_resource_id) REFERENCES GenericResource(id)
);

CREATE TABLE ResourceInstance (
    resource_code VARCHAR(17) NOT NULL,
    edition_id INT NOT NULL,
    institution_id INT NOT NULL,
    PRIMARY KEY (resource_code),
    FOREIGN KEY (edition_id) REFERENCES Edition(id),
    FOREIGN KEY (institution_id) REFERENCES Institution(id)
);

CREATE TABLE ResourceInstanceHold (
    resource_instance_id VARCHAR(17) NOT NULL,
    resource_reservation_date DATETIME NOT NULL,
    FOREIGN KEY (resource_instance_id) REFERENCES ResourceInstance(resource_code)
);

CREATE TABLE Lease (
    id INT NOT NULL AUTO_INCREMENT,
    account_id INT NOT NULL,
    librarian_id INT NOT NULL,
    resource_instance_id VARCHAR(17) NOT NULL,
    lease_start DATE NOT NULL,
    lease_end DATE,
    lease_duration VARCHAR(10) NOT NULL, -- 1 month = 2629743, 1 week = 604800
    PRIMARY KEY (id),
    FOREIGN KEY (account_id) REFERENCES Account(id),
    FOREIGN KEY (librarian_id) REFERENCES Librarian(account_id),
    FOREIGN KEY (resource_instance_id) REFERENCES ResourceInstance(resource_code)
);

CREATE TABLE EditionHold (
    id INT NOT NULL AUTO_INCREMENT,
    edition_id INT NOT NULL,
    resource_reservation_date DATETIME NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (edition_id) REFERENCES Edition(id)
);

CREATE TABLE Edition_Translator (
    edition_id INT NOT NULL,
    translator_id INT NOT NULL,
    FOREIGN KEY (edition_id) REFERENCES Edition(id),
    FOREIGN KEY (translator_id) REFERENCES Translator(id)
);

CREATE TABLE GenericResource_Author (
    generic_resource_id INT NOT NULL,
    author_id INT NOT NULL,
    PRIMARY KEY (generic_resource_id, author_id),
    FOREIGN KEY (generic_resource_id) REFERENCES GenericResource(id),
    FOREIGN KEY (author_id) REFERENCES Author(id)
);

CREATE TABLE Author_Nationality (
    author_id INT NOT NULL,
    nationality_id INT NOT NULL,
    PRIMARY KEY (author_id, nationality_id),
    FOREIGN KEY (author_id) REFERENCES Author(id),
    FOREIGN KEY (nationality_id) REFERENCES Nationality(id)
);

-- indices and stuff
-- https://stackoverflow.com/questions/561446/mysql-index-keyword-in-create-table-and-when-to-use-it

-- Empty tables:
-- 1. GenericResourceHold
-- 2. ResourceInstanceHold
-- 3. Lease
-- 4. EditionHold
