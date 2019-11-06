--TaskSQL.EX #1
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
WHERE price> 1000

--TASK SQL.EX #4
SELECT*
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