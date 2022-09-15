CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  subtitle VARCHAR(255),
  img VARCHAR(255),
  category VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8 COMMENT '';

-- NOTE deletes the table and all of its content.
DROP TABLE recipes;

-- NOTE creates new data entry
INSERT INTO recipes(title, subtitle, img, category, creatorId)
VALUES('Spooky Cupcakes', 'Now made with Gluten!', 'https://images.unsplash.com/photo-1638258682206-0a95e15e4030?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mjd8fGhhbGxvd2VlbiUyMGN1cGNha2VzfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=400&q=60', 'Dessert', '63059889588984525e6be97d');

-- NOTE join tables (recipes and accounts)
SELECT * FROM recipes r
JOIN accounts a ON a.id = r.creatorId;

-- NOTE join tables (recipes, ingredients, steps, and accounts)
SELECT * FROM recipes r
JOIN ingredients i ON r.id = i.recipeId
JOIN steps s ON r.id = s.recipeId
JOIN accounts a ON a.id = r.creatorId;
