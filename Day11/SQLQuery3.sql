use sql;

CREATE TABLE emp (
    emp_id INT PRIMARY KEY IDENTITY(1,1),
    emp_name VARCHAR(50),
    job VARCHAR(50),
    hire_date DATE,
    salary DECIMAL(10,2),
    commission DECIMAL(10,2),
    deptno INT
);


INSERT INTO emp (emp_name, job, hire_date, salary, commission, deptno) VALUES
('Amit', 'Manager', '2023-01-10', 5000, 500, 10),
('Rahul', 'Clerk', '2023-02-15', 2000, 3000, 20),
('Sneha', 'Clerk', '2023-02-15', 2500, 100, 20),
('Priya', 'Manager', '2023-03-01', 6000, 500, 10),
('Karan', 'Analyst', '2023-04-20', 4000, 200, 30),
('Riya', 'Clerk', '2023-02-15', 2200, 50, 20),
('Vikas', 'Analyst', '2023-04-20', 4200, 100, 30),
('Neha', 'Manager', '2023-05-05', 5500, 300, 10);


-- 1.select query

select * from emp;

--1. WRITE A QUERY TO DISPLAY TOTAL SALARY NEEDED TO PAY EACH JOB IN EMPLOYEE TABLE. 

SELECT job, SUM(salary) AS total_salary
FROM emp
GROUP BY job;

--2. WRITE A QUERY TO DISPLAY THE HIRE DATE ON WHICH AT LEAST 3 EMPLOYEES WHERE HIRED. 


SELECT hire_date
FROM emp 
GROUP BY hire_date
HAVING COUNT(*) >= 3;

-- 3. WRITE A QUERY TO DISPLAY THE DEPARTMENT NUMBER WHICH HAS MORE THAN 2 EMPLOYEES AND THE TOTAL AMOUNT REQUIRED TO PAY THE MONTHLY SALARIES OF ALL THE EMPLOYEES IN THAT DEPARTMENT SHOULD BE MORE THAN 9000. 

SELECT deptno, SUM(salary) AS total_salary
FROM emp
GROUP BY deptno
HAVING COUNT(*) > 2 AND SUM(salary) > 9000;

-- 4. WRITE A QUERY TO DISPLAY NUMBER OF EMPLOYEES WORKING IN EACH DEPARTMENT AND ITS’ AVERAGE SALARY BY EXCLUDING ALL THE EMPLOYEES WHOSE SALARY IS LESS THAN THEIR COMMISSION. 

SELECT deptno, COUNT(*) AS total_employees, AVG(salary) AS avg_salary
FROM emp
WHERE salary >= commission
GROUP BY deptno;
 
-- 5. WRITE A QUERY TO DISPLAY THE SALARIES WHICH HAS REPETITIONS IN THE SAL COLUMN OF EMPLOYEE TABLE. 

select salary,count(*) as noofrepetation
from emp
group by salary;
-- 6. WRITE A QUERY TO DISPLAY THE EMPLOYEE NAME ONLY IF MORE THAN ONE PERSON IN THE EMPLOYEES OF THE COMPANY HAS SAME NAME.

select emp_name
FROM emp
group BY emp_name
HAVING COUNT(emp_name) > 1;

 --7. WRITE A QUERY TO DISPLAY THE DEPARTMENT NUMBER WHOSE AVERAGE SALARY IS BETWEEN 2500 AND 3000. 

select deptno
from emp
group BY deptno
having AVG(salary) BETWEEN 2500 AND 3000;

--8. WRITE A QUERY TO DISPLAY THE NUMBER OF EMPLOYEES ONLY IF THEY ARE WORKING AS MANAGER OR ANALYST AND THEIR ANNUAL SAL SHOULD END WITH A ZERO, IN EACH DEPARTMENT. 

SELECT DEPTNO, COUNT(*) AS NumberOfEmployees
FROM emp
WHERE
    JOB IN ('Manager', 'Analyst')
    AND (SALARY * 12 %10) = 0
GROUP BY
    DEPTNO;

	select emp_name ,salary
	from emp
	where (emp_name like '%a%'
	or emp_name like 'v%')
	and salary  between 5000 and 10000;