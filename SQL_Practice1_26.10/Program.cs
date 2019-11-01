--TASK1 - Create table
CREATE TABLE Planets1(
    ID INT Identity(1, 1) PRIMARY KEY
    , PlanetName VARCHAR(50) NOT NULL
     , Radius INT NOT NULL
	,SunSeason FLOAT
    , OpeningYear SMALLINT
	,HavingRings BIT
    , Opener VARCHAR(50)
	)

INSERT INTO Planets1
VALUES(
	'Mars'

    ,3396
	,687
	,1659
	,0
	,'Christiaan Huygens'
	)
	,(
	'Saturn'
	,60268
	,10759.22
	,NULL
	,1
	,NULL
	)
	,(
	'Neptune'
	,24764
	,60190
	,1846
	,1
	,'John Couch Adams'
	)
	,(
	'Mercury'
	,2439
	,115.88
	,1631
	,0
	,'Nicolaus Copernicus'
	)
	,(
	'Venus'
	,6051
	,243
	,1610
	,0
	,'Galileo Galilei'
	)

--TASK2
SELECT*
FROM Planets1
WHERE Radius BETWEEN 3000
		AND 5000;

--TASK3
SELECT PlanetName
	,OpeningYear
	,Opener
FROM Planets1
WHERE PlanetName NOT LIKE 'S%'
	OR PlanetName NOT LIKE '%s';

--TASK4
SELECT*
FROM Planets1
WHERE Radius< 10000

    AND OpeningYear> 1620;

--TASK5
SELECT*
FROM Planets1
WHERE PlanetName LIKE 'N%'
	OR(
        PlanetName LIKE '%s'

        AND HavingRings = 0
        )

--TASK6
UPDATE Planets1
SET PlanetName = 'Pluton'
WHERE PlanetName = 'Neptune'

--TASK7
UPDATE Planets1
SET HavingRings = 0
WHERE ID IN(
		1

        ,3
		)

--TASK8
SELECT*
INTO PlanetsWithRings
FROM Planets1
WHERE HavingRings = 1;

--TASK9
SELECT*
FROM PlanetsWithRings

--TASK10
DELETE
FROM PlanetsWithRings
WHERE HavingRings = 0

    OR(
        OpeningYear = NULL

        OR opener = NULL
        )
		
--SQL.EX 1
SELECT model, speed, hd
FROM PC
WHERE price<500

--TASK SQL.EX #2
SELECT DISTINCT maker
FROM Product
WHERE type = 'Printer'

--TASK SQL.EX #3
SELECT model, ram, screen
FROM Laptop
WHERE price > 1000

--TASK SQL.EX #4
SELECT *
FROM Printer
WHERE color = 'y'

--TASK SQL.EX #5
SELECT model, speed, hd
FROM PC
WHERE price<600 AND (cd='12x' OR cd='24x')

--TASK SQL.EX #6
SELECT DISTINCT Product.maker, Laptop.speed
FROM Product inner join Laptop
ON Product.model = Laptop.model
WHERE Laptop.hd >= 10

--TASK SQL.EX #7
SELECT PC.model, price
FROM Product
INNER JOIN PC on Product.model = PC.model
WHERE maker = 'B'
UNION
SELECT Laptop.model, price
FROM Product
INNER JOIN Laptop on Product.model = Laptop.model
WHERE maker = 'B'
UNION
SELECT Printer.model, price
FROM Product
INNER JOIN Printer on Product.model = Printer.model
WHERE maker = 'B'

--TASK SQL.EX #8
SELECT DISTINCT Product.maker
FROM Product
WHERE Product.type= 'PC' AND Product.maker NOT IN (
 SELECT Product.maker
 FROM Product
 WHERE Product.type = 'Laptop')
 
 --TASK SQL.EX #9
 SELECT DISTINCT Product.maker
FROM Product JOIN PC ON Product.model = PC.model
WHERE PC.speed >= 450

--TASK SQL.EX #10
SELECT DISTINCT model, price
FROM Printer
WHERE price IN(
 SELECT MAX(price)
 FROM Printer)