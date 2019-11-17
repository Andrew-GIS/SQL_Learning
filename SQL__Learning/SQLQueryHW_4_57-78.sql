--TASK_57
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, departments.department_id, departments.department_name 
FROM employees 
INNER JOIN departments ON employees.department_id = departments.department_id

--TASK_58
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, departments.department_id, departments.department_name, locations.city, locations.state_province
FROM employees 
INNER JOIN departments ON employees.department_id = departments.department_id 
INNER JOIN locations ON departments.location_id = locations.location_id

--TASK_59
SELECT CONCAT(first_name, ' ', last_name) AS NameInfo, salary, grade_level
FROM employees
INNER JOIN job_grades ON employees.salary BETWEEN job_grades.lowest_sal AND job_grades.highest_sal

--TASK_60
SELECT CONCAT (first_name, ' ', last_name) AS NameInfo, departments.department_id, departments.department_name
FROM employees 
INNER JOIN departments ON employees.department_id = departments.department_id 
WHERE departments.department_id = 80 OR departments.department_id = 40

--TASK_61
SELECT employees.first_name, employees.last_name, departments.department_name, locations.city, locations.state_province
FROM employees 
INNER JOIN departments ON employees.department_id = departments.department_id 
INNER JOIN locations ON departments.location_id = locations.location_id
WHERE employees.first_name LIKE '%z%' OR employees.first_name LIKE 'Z%'

--TASK_62
SELECT employees.first_name, employees.last_name, departments.department_name
FROM employees 
RIGHT OUTER JOIN departments ON employees.department_id = departments.department_id

--TASK_63
SELECT employees.first_name, employees.last_name, employees.salary
FROM employees 
WHERE salary  <
	(
	SELECT salary
	FROM employees
	WHERE emplyee_id = 182
	)
--with JOIN support
SELECT e1.first_name, e1.last_name, e1.salary
FROM employees e1 
INNER JOIN employees e2 ON e1.salary < e2.salary AND e2.emplyee_id = 182

--TASK64
SELECT e1.first_name AS Eml_Name, e2.first_name  AS Manager
FROM  employees e1
INNER JOIN employees e2 ON e1.emplyee_id = e2.manager_id

--TASK65
SELECT department_name, city, state_province
FROM  departments
INNER JOIN locations ON departments.location_id = locations.location_id

--TASK66
SELECT CONCAT(first_name, ' ', last_name) AS NameInfo, departments.department_id, departments.department_name
FROM  employees
INNER JOIN departments ON employees.department_id = departments.department_id

--TASK67
SELECT CONCAT(e1.first_name, ' ', e1.last_name) AS EMPL_NameInfo, e2.first_name AS ManegerName
FROM  employees e1
LEFT JOIN employees e2 ON e1.manager_id = e2.emplyee_id

--TASK68
SELECT e1.first_name, e1.last_name, e1.department_id
FROM  employees e1
INNER JOIN employees e2 ON e1.department_id = e2.department_id
AND e2.last_name = 'Taylor'

--TASK69 
SELECT j.job_title, d.department_name, e.first_name, e.last_name, jh.start_date
FROM jobs j
INNER JOIN employees e ON j.job_id = e.job_id
INNER JOIN departments d ON e.department_id = d.department_id
INNER JOIN job_history jh ON jh.employee_id=e.emplyee_id
WHERE jh.start_date >= '1993-01-01' AND jh.start_date <= '1997-08-31';

--TASK70
SELECT j.job_title, CONCAT (e.first_name, ' ', e.last_name) AS NameInfo, (j.max_salary-e.salary) AS Salary_differents
FROM jobs j
INNER JOIN employees e ON  j.job_id = e.job_id

--TASK71
SELECT d.department_name, AVG(e.salary) AS Avg_salary, COUNT(e.emplyee_id) AS Impl_count
FROM departments d
JOIN employees e ON  d.department_id=e.department_id
WHERE e.commission_pct IS NOT NULL
GROUP BY d.department_name

--TASK72
SELECT job_title, first_name, (j.max_salary)-e.salary AS salary_diff 
FROM employees e
INNER JOIN jobs j ON e.job_id= j.job_id
WHERE department_id = 80;

--TASK73
SELECT country_name, city, department_name
FROM countries
INNER JOIN locations ON countries.country_id = locations.country_id
INNER JOIN departments ON locations.location_id = departments.location_id

--TASK74
SELECT department_name, CONCAT(first_name, ' ', last_name) As NameInfo
FROM departments
INNER JOIN employees ON departments.department_id = employees.department_id
WHERE departments.manager_id = employees.emplyee_id

--TASK75
SELECT job_title, (AVG(salary)) AS AvgSalary
FROM jobs
INNER JOIN employees ON jobs.job_id=employees.job_id
GROUP BY job_title

--TASK76
SELECT e.emplyee_id, j.start_date, end_date, j.job_id, j.department_id
FROM job_history j
INNER JOIN employees e ON j.employee_id = e.emplyee_id
WHERE e.salary >= 12000

--TASK77
SELECT country_name, city, COUNT(departments.department_id)
FROM countries
INNER JOIN locations  ON countries.country_id = locations.country_id
INNER JOIN departments ON locations.location_id = departments.location_id
WHERE departments.department_id IN
 (SELECT department_id
 FROM employees
 --WHERE COUNT (department_id) >=2
 GROUP BY department_id
 HAVING COUNT(department_id) >= 2
 )
 GROUP BY country_name, city
 
 --TASK78
 SELECT department_name, CONCAT(first_name, ' ', last_name) AS NameInfo, city
FROM locations
INNER JOIN departments ON locations.location_id=departments.location_id
INNER JOIN employees ON departments.manager_id = employees.emplyee_id