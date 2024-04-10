-- Table for jobs
DROP TABLE Jobs;

CREATE TABLE Jobs (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  NameCompany VARCHAR(255),
  LogoCompany VARCHAR(255),
  OfferTitle VARCHAR(255),
  Description VARCHAR(255),
  Salary DOUBLE, 
  Positions INT,
  Status VARCHAR(45),
  Country VARCHAR(45),
  Languages VARCHAR(45)
)

INSERT INTO Jobs (`NameCompany`, `LogoCompany`, `OfferTitle`, `Description`, `Salary`, `Positions`, `Status`, `Country`, `Languages`) VALUES
("Kitori SAS", "cats.jpeg", "Senior C#", "Senior for this position net", 23000, 2, "Avalible", "Colombia", "Spanish, English");

-- Table for employees
DROP TABLE Employees;

CREATE TABLE Employees (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Names VARCHAR(45),
  LastNames VARCHAR(45) NOT NULL,
  Email VARCHAR(125) UNIQUE,
  ProfilePicture VARCHAR(255), 
  Cv VARCHAR(255),
  Gender VARCHAR(20),
  Phone VARCHAR(25),
  BirthDate DATETIME,
  Address VARCHAR(125),
  CivilStatus VARCHAR(45),
  Salary DOUBLE, 
  About VARCHAR(225),
  AcademicTitle VARCHAR(125),
  Languages VARCHAR(125),
  Area VARCHAR(45)
)

INSERT INTO Employees (`Names`, `LastNames`, `Email`, `ProfilePicture`, `Cv`, `Gender`, `Phone`, `Address`, `CivilStatus`, `Salary`, `About`, `AcademicTitle`, `Languages`, `Area`, `BirthDate`) VALUES
("Martha", "Kimen", "marta@example.com", "martha.jpeg", "Martha.pdf", "Female", "304 2942431", "Bogota - Colombia", "Single", 25000, "I am really workall", "Secretary", "English", "Customer expirence", UTC_DATE)