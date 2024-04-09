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
("Kitori SAS", "cats.img", "Senior C#", "Senior for this position net", 23000, 2, "Avalible", "Colombia", "Spanish, English");