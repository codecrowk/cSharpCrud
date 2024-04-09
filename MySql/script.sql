CREATE TABLE Users (
  Id INT(11) AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(45),
  Lastname VARCHAR(45), 
  Email VARCHAR(120),
  Logo VARCHAR(150),
  CreatedAt TIMESTAMP
);

DROP TABLE Users;

INSERT INTO Users (`Name`, `Lastname`, `Email`, `CreatedAt`, `Logo`) VALUES 
('John', 'Doe', 'john@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Jane', 'Doe', 'jane@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Michael', 'Smith', 'michael@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Emily', 'Johnson', 'emily@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('David', 'Brown', 'david@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Sarah', 'Miller', 'sarah@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Matthew', 'Davis', 'matthew@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Jessica', 'Wilson', 'jessica@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Christopher', 'Martinez', 'christopher@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Amanda', 'Anderson', 'amanda@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('James', 'Taylor', 'james@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Jennifer', 'Thomas', 'jennifer@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Daniel', 'Hernandez', 'daniel@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Melissa', 'Moore', 'melissa@example.com', CURRENT_TIMESTAMP, "gato.jpeg"),
('Kevin', 'Jackson', 'kevin@example.com', CURRENT_TIMESTAMP, "gato.jpeg");