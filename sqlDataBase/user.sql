UPDATE TABLE Users (
     IdUser INT(11) AUTO_INCREMENT PRIMARY KEY,
     NameUser VARCHAR(45),
     LastName VARCHAR(45), 
     Email VARCHAR(120),
     CreatedAt TIMESTAMP,
);


DROP TABLE Users;

INSERT INTO Users (name_user, lastname, email, created_at) VALUES 
('John', 'Doe', 'john@example.com', CURRENT_TIMESTAMP),
('Jane', 'Doe', 'jane@example.com', CURRENT_TIMESTAMP),
('Michael', 'Smith', 'michael@example.com', CURRENT_TIMESTAMP),
('Emily', 'Johnson', 'emily@example.com', CURRENT_TIMESTAMP),
('David', 'Brown', 'david@example.com', CURRENT_TIMESTAMP),
('Sarah', 'Miller', 'sarah@example.com', CURRENT_TIMESTAMP),
('Matthew', 'Davis', 'matthew@example.com', CURRENT_TIMESTAMP),
('Jessica', 'Wilson', 'jessica@example.com', CURRENT_TIMESTAMP),
('Christopher', 'Martinez', 'christopher@example.com', CURRENT_TIMESTAMP),
('Amanda', 'Anderson', 'amanda@example.com', CURRENT_TIMESTAMP),
('James', 'Taylor', 'james@example.com', CURRENT_TIMESTAMP),
('Jennifer', 'Thomas', 'jennifer@example.com', CURRENT_TIMESTAMP),
('Daniel', 'Hernandez', 'daniel@example.com', CURRENT_TIMESTAMP),
('Melissa', 'Moore', 'melissa@example.com', CURRENT_TIMESTAMP),
('Kevin', 'Jackson', 'kevin@example.com', CURRENT_TIMESTAMP);