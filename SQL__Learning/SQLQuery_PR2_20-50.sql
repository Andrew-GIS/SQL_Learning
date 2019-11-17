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


--TASK21
SELECT CONCAT (first_name, ' ', last_name) AS Info, hire_date
FROM employees
WHERE department_id = (
SELECT department_id
FROM employees
WHERE first_name = 'Clara') AND first_name != 'Clara'

--TASK22
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info
FROM employees
WHERE department_id IN (
	SELECT department_id
	FROM employees
	WHERE first_name LIKE '%t%')

--TASK23
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, salary
FROM employees
WHERE salary >
(SELECT AVG(salary)
FROM employees)
AND 
department_id IN (
	SELECT department_id
	FROM employees
	WHERE first_name LIKE '%j%')

--TASK24
SELECT CONCAT (first_name, ' ', last_name) AS Info, emplyee_id,  job_id
FROM employees
WHERE department_id IN
	(SELECT department_id
	FROM departments
	WHERE location_id IN
		(SELECT location_id
		 FROM locations
		 WHERE city = 'Toronto'))

--TASK25
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, job_id
FROM employees
WHERE salary <
	(SELECT MIN(salary)
	FROM employees
	WHERE job_id = 'MK_MAN')

--TASK26
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, job_id
FROM employees
WHERE salary <
	(SELECT MIN(salary)
	FROM employees
	WHERE job_id = 'MK_MAN')
	AND job_id != 'MK_MAN'

--TASK27
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, job_id
FROM employees
WHERE salary >
	(SELECT MIN(salary)
	FROM employees
	WHERE job_id = 'PU_MAN')
	AND job_id != 'PU_MAN'

--TASK28
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, job_id
FROM employees
WHERE salary > ALL
	(SELECT AVG(salary)
	FROM employees
	GROUP BY department_id
	)

--TASK29
SELECT CONCAT (first_name, ' ', last_name) AS Info, department_id
FROM employees
WHERE  EXISTS
	(SELECT salary
	FROM employees
	WHERE salary>3700
	)

--TASK30?
SELECT departments.department_id, Total1.TotalSalary
FROM departments,
(SELECT employees.department_id, SUM(employees.salary) AS TotalSalary
FROM employees
GROUP BY department_id) AS Total1
WHERE Total1.department_id = departments.department_id	

--2nd variant
SELECT employees.department_id, SUM(employees.salary) AS TotalSalary
FROM employees
GROUP BY department_id

--TASK31
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS Info, CASE job_id
WHEN 'ST_MAN' THEN 'SALESMAN'
WHEN 'IT_PROG' THEN 'DEVELOPER'
ELSE job_id
END designation,
salary
FROM employees

--TASK 32
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS NameInfo, salary,
CASE WHEN salary >
	(SELECT AVG(salary)
	FROM employees) THEN 'High'
WHEN salary < 
	(SELECT AVG(salary)
	FROM employees) THEN 'Low'
END SalaryStatus
FROM employees

--TASK 33
SELECT emplyee_id, CONCAT (first_name, ' ', last_name) AS NameInfo, salary AS SalaryDrawn, (salary - (SELECT AVG(salary)
	FROM employees)) AS AvgCompare,
CASE WHEN salary >
	(SELECT AVG(salary)
	FROM employees) THEN 'High'
WHEN salary < 
	(SELECT AVG(salary)
	FROM employees) THEN 'Low'
END SalaryStatus
FROM employees

--TASK34.
SELECT department_name
FROM departments
WHERE department_id IN
	(SELECT department_id
	FROM employees
	GROUP BY department_id
	HAVING COUNT (emplyee_id)>=1)
	
--TASK35
SELECT first_name
FROM employees
WHERE department_id IN
	(SELECT department_id
	FROM departments
	WHERE location_id IN
	(SELECT location_id
	FROM locations
	WHERE country_id IN 
	(SELECT country_id
	FROM countries
	WHERE country_name = 'United Kingdom'
	)))
	
--TASK36
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, salary AS Salary
FROM employees
WHERE salary > 
	(SELECT salary
	FROM employees
	WHERE last_name = 'Ozer')
	
--TASK37
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo
FROM employees
WHERE manager_id IN
(   SELECT emplyee_id
	FROM employees
	WHERE department_id IN 
		(SELECT department_id
		FROM departments
		WHERE location_id IN
			(SELECT location_id 
			FROM locations
			WHERE country_id = 'US'	)))
			
--TASK38 - have a problem with this task
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo
FROM employees e1 
WHERE salary >
	(SELECT SUM(salary) * 0.5
	FROM employees e2
	WHERE e1.department_id = e2.department_id) 
	
--TASK39
SELECT *
FROM employees
WHERE job_id IN (SELECT job_id from jobs where job_title like '%Manager%');
	
--TASK40
SELECT *
FROM employees 
WHERE department_id IN 
	(SELECT department_id
	FROM departments
	WHERE manager_id IS NOT NULL AND emplyee_id LIKE (manager_id)
	)
	
--TASK41
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, salary, departments.department_name, locations.city
FROM employees, departments, locations 
WHERE employees.salary IN
	(SELECT MAX(employees.salary)
	FROM employees
	WHERE hire_date BETWEEN '01-01-2002' AND '12-31-2003'
	)
	AND employees.department_id = departments.department_id
	AND departments.location_id = locations.location_id
	
--TASK42
SELECT department_id, department_name
FROM departments
WHERE location_id IN
	(SELECT location_id
	FROM locations
	WHERE city = 'London'
	)
	
--TASK43
SELECT CONCAT(first_name, ' ', last_name) AS NameInfo, salary, department_id
FROM employees
WHERE salary >
	(SELECT AVG(salary)
	FROM employees
	)
	ORDER BY salary DESC
	
--TASK44
SELECT CONCAT(first_name, ' ', last_name) AS NameInfo, salary, department_id
FROM employees
WHERE salary >
	(SELECT AVG(salary)
	FROM employees
	WHERE department_id = 40
	)
	ORDER BY salary DESC
	
--TASK45
SELECT department_name , department_id
FROM departments
WHERE location_id IN
	(SELECT location_id
	FROM departments
	WHERE department_id=30
	)

--TASK46
SELECT CONCAT (first_name, ' ', last_name), salary, department_id
FROM employees
WHERE department_id IN
	(SELECT department_id
	FROM employees
	WHERE emplyee_id =201
	)

--TASK47
SELECT CONCAT (first_name, ' ', last_name), salary, department_id
FROM employees
WHERE salary IN
	(SELECT salary
	FROM employees
	WHERE department_id =40
	)
	
--TASK48
SELECT CONCAT (first_name, ' ', last_name), salary, department_id
FROM employees
WHERE department_id IN
	(SELECT department_id
	FROM departments
	WHERE department_name = 'Marketing'
	)
	
--TASK49
SELECT CONCAT (first_name, ' ', last_name), salary, department_id
FROM employees
WHERE salary >
	(SELECT AVG(salary)
	FROM employees
	WHERE department_id =40
	)
	
--TASK50
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, email, hire_date
FROM employees
WHERE hire_date >
	(SELECT hire_date
	FROM employees
	WHERE emplyee_id = 165
	)