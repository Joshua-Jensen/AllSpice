CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    recipes(
        id SMALLINT primary KEY AUTO_INCREMENT,
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(2000) NOT NULL,
        img VARCHAR(300) NOT NULL,
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8;

CREATE TABLE
    ingredients(
        id BIGINT PRIMARY KEY AUTO_INCREMENT,
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId SMALLINT NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
    ) default charset utf8;

SELECT r.*, creator.*
FROM recipes r
    JOIN accounts creator ON creator.id = r.creatorId
WHERE r.id = 1;

ALTER TABLE recipes DROP FOREIGN KEY `creatorId`;

DROP TABLE recipes;

DROP TABLE ingredients;