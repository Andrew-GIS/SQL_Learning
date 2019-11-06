--TASK 11
--Найдите среднюю скорость ПК.
SELECT AVG(speed) AS 'Average speed'
FROM PC

--TASK 12
--Найдите среднюю скорость ПК-блокнотов, цена которых превышает 1000 дол.
SELECT AVG(speed)
FROM Laptop
WHERE price>1000

--TASK 13
--Найдите среднюю скорость ПК, выпущенных производителем A.
--correct
SELECT AVG(speed)
FROM PC
WHERE model IN (
 SELECT model
 FROM Product
 WHERE (type = 'PC') AND(maker = 'A'))

--TASK 14
--Найдите класс, имя и страну для кораблей из таблицы Ships, имеющих не менее 10 орудий.
--with WHERE only support(show's that not correct)
SELECT Ships.class, Ships.name, Classes.country
FROM Ships, Classes
WHERE(Ships.class = Classes.class AND numGuns>10)

--сorrect
SELECT Ships.class, Ships.name, Classes.country
FROM Ships
INNER JOIN Classes ON(Ships.class = Classes.class)
WHERE numGuns>=10

--TASK15
--Найдите размеры жестких дисков, совпадающих у двух и более PC.Вывести: HD
SELECT hd
FROM PC
GROUP BY hd

--TASK19
--Для каждого производителя, имеющего модели в таблице Laptop, найдите средний размер экрана выпускаемых им ПК-блокнотов.
--Вывести: maker, средний размер экрана.
SELECT DISTINCT Product.maker, AVG(Laptop.screen)
FROM Product
INNER JOIN Laptop ON(Laptop.model = Product.model)
GROUP BY Product.maker
HAVING  COUNT(*) > 1

--TASK21
--Найдите максимальную цену ПК, выпускаемых каждым производителем, у которого есть модели в таблице PC.
--Вывести: maker, максимальная цена.
SELECT DISTINCT Product.maker, MAX(PC.price)
FROM Product
INNER JOIN PC ON (PC.model = Product.model)
GROUP BY Product.maker
Question: why didn't work without GROUP BY???

--TASK22
--Для каждого значения скорости ПК, превышающего 600 МГц, определите среднюю цену ПК с такой же скоростью.
--Вывести: speed, средняя цена.

SELECT DISTINCT PC.speed, AVG(PC.price)
FROM PC
WHERE PC.speed>600
GROUP BY PC.speed

--TASK28
--Используя таблицу Product, определить количество производителей, выпускающих по одной модели.
--show correct data, but didn't contains some conditions
SELECT COUNT (Product.maker)
FROM Product
GROUP BY Product.maker
HAVING COUNT(model) = 1

--correct
SELECT COUNT (Product.maker)
FROM Product
WHERE maker IN(
       SELECT Product.maker
       FROM Product
       GROUP BY Product.maker
       HAVING COUNT(model) = 1
)

--TASK31
--Для классов кораблей, калибр орудий которых не менее 16 дюймов, укажите класс и страну.
--show correct dataset, but didn't contains some conditions, maybe
SELECT DISTINCT Ships.class, Classes.country
FROM Classes
INNER JOIN Ships ON(Ships.class = Classes.class)
WHERE bore>=16

--correct
SELECT DISTINCT Classes.class, Classes.country
FROM Classes
WHERE bore>=16

--TASK33
--Укажите корабли, потопленные в сражениях в Северной Атлантике(North Atlantic). Вывод: ship.
SELECT Outcomes.ship
FROM Outcomes
WHERE battle = 'North Atlantic' AND result = 'sunk'


--TASK38
--Найдите страны, имевшие когда-либо классы обычных боевых кораблей ('bb') и имевшие когда-либо классы крейсеров('bc').
SELECT DISTINCT country
FROM Classes
WHERE type = 'bb'
INTERSECT
SELECT DISTINCT country
FROM Classes
WHERE type = 'bc'

--TASK42
---Найдите названия кораблей, потопленных в сражениях, и название сражения, в котором они были потоплены.
SELECT ship, battle
FROM Outcomes
WHERE result = 'sunk'

--TASK44
--Найдите названия всех кораблей в базе данных, начинающихся с буквы R.
SELECT DISTINCT name
FROM Ships
WHERE name LIKE 'R%'
UNION
SELECT DISTINCT ship
FROM Outcomes
WHERE ship LIKE 'R%'

--TASK45
--Найдите названия всех кораблей в базе данных, состоящие из трех и более слов
SELECT name
FROM Ships
WHERE name LIKE '% % %'
UNION
SELECT ship
FROM Outcomes
WHERE ship LIKE '% % %'

--TASK49
--Найдите названия кораблей с орудиями калибра 16 дюймов (учесть корабли из таблицы Outcomes).
SELECT DISTINCT name
FROM Ships
INNER JOIN Classes ON(Ships.class = Classes.class)
WHERE bore = '16'
UNION
SELECT DISTINCT ship
FROM Outcomes
INNER JOIN Classes ON(Outcomes.ship = Classes.class)
WHERE bore = '16'

--TASK50
--Найдите сражения, в которых участвовали корабли класса Kongo из таблицы Ships.
SELECT DISTINCT battle
FROM Outcomes
INNER JOIN Ships ON (Outcomes.ship = Ships.name)
WHERE Ships.class = 'Kongo'