--TASK1
SELECT CONCAT(
        first_name

        ,' '
		, last_name

        )
	,hire_date
	,salary
	,department_id
FROM employees
WHERE first_name != '%m'
ORDER BY department_id ASC

-- TASK2

SELECT*
FROM employees
WHERE(
        (
            salary BETWEEN 8000

                AND 12000
			)

        AND(commission_pct IS NOT NULL)
		)
	OR(
        department_id NOT IN (
			40
			,120
			,70
			)

        AND hire_date <= '2002-05-06'
		)


--TASK3
SELECT CONCAT(
        first_name

        ,' '
		, last_name

        ) AS Full_Name
    , CONCAT (
		phone_number
        , '-'
        , email
		) AS Contact_Details
    , salary AS Remuneration
FROM employees
WHERE salary BETWEEN 9000
		AND 17000

--TASK4
SELECT CONCAT(
        first_name

        ,' '
		, last_name

        ) AS Full_Name
    , salary AS Remuneration
FROM employees
WHERE salary< 7000
	OR salary > 15000
ORDER BY Full_Name ASC

--TASK5

SELECT CONCAT (
        first_name
        ,' '
		, last_name

        ) AS Full_Name
    , job_id
    , hire_date
FROM employees
WHERE hire_date BETWEEN '2007-05-11'
		AND '2009-05-07'

--TASK6
SELECT CONCAT(
        first_name

        ,' '
		, last_name

        ) AS Full_Name
    , hire_date
    , commission_pct
    , CONCAT (
		email
        , '-'
        , phone_number
		) AS ContactInfo
    , salary
FROM employees
WHERE salary > 11000
	OR phone_number LIKE '______3'
ORDER BY first_name DESC

--TASK7

SELECT emplyee_id
	,first_name
	,job_id
	,department_id
FROM employees
WHERE department_id NOT IN(
		50

        ,30
		,80
		)
ORDER BY first_name DESC

--TASK8

SELECT employee_id
FROM job_history
GROUP BY employee_id
HAVING COUNT(*) >= 2;

--TASK9
    SELECT CONCAT(
        first_name

        , last_name

        ) AS FullName
FROM employees
WHERE salary > (
        SELECT salary

        FROM employees
        WHERE emplyee_id = 163
		);

--TASK10
SELECT CONCAT(
        first_name

        , last_name

        ) AS FullName
    , salary
    , department_id
    , job_id
FROM employees
WHERE job_id = (
        SELECT job_id
        FROM employees
        WHERE emplyee_id = 169
		);

--TASK11
SELECT CONCAT(
        first_name

        , last_name

        ) AS FullName
    , salary
    , department_id
FROM employees
WHERE salary = (
        SELECT MIN(salary)

        FROM employees
		);

--TASK12

SELECT emplyee_id
	,CONCAT(
        first_name

        , last_name

        ) AS FullName
FROM employees
WHERE salary > (
        SELECT AVG(salary)
        FROM employees
		);

--TASK13
SELECT CONCAT(
        first_name

        , last_name

        ) AS FullName
    , emplyee_id
    , salary
FROM employees
WHERE manager_id = (
        SELECT emplyee_id
        FROM employees
        WHERE first_name = 'Payam'
		);

--TASK14

SELECT d.department_id
	,CONCAT(
        e.first_name

        , e.last_name

        ) AS FullName
    , e.emplyee_id
	,e.job_id
	,d.department_name
FROM employees e
    , departments d
 WHERE e.department_id = d.department_id
     AND d.department_name = 'Finance'

--TASK15

SELECT*
FROM employees
WHERE salary > 300
	AND manager_id = 121

--TASK16
--not sure that i correctly understand this task
SELECT *
FROM employees
WHERE emplyee_id IN (
        SELECT emplyee_id

        FROM employees
        WHERE emplyee_id = 134

            OR emplyee_id = 159

            OR emplyee_id = 183
		);

--TASK17

SELECT *
FROM employees
WHERE salary IN (
		SELECT salary
        FROM employees
        WHERE salary BETWEEN 1000
				AND 3000
		);

--TASK18

--NOT CORRECT
SELECT *
FROM employees
WHERE emplyee_id IN (
		SELECT emplyee_id
        FROM employees
        WHERE salary BETWEEN MIN(salary)
				AND 2500
		)

--CORRECT
SELECT *
FROM employees
WHERE salary BETWEEN (
				SELECT MIN(salary)
				FROM employees
				)
		AND 2500

--TASK19

SELECT *
FROM employees
WHERE department_id NOT IN (
		SELECT department_id
        FROM departments
        WHERE manager_id BETWEEN 100
				AND 200
		)

--TASK20

SELECT *
FROM employees
WHERE emplyee_id IN (
		SELECT emplyee_id
        FROM employees
        WHERE salary = (
				SELECT MAX(salary)
				FROM employees
                WHERE salary < (
						SELECT MAX(salary)
						FROM employees
						)
				)
		)