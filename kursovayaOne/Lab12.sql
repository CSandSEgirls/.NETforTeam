CREATE TABLE READERS(
	f_name varchar(30) not null,
	l_name varchar(30) not null,
	tel_num int unique,
	email varchar(30) unique, 
	reader_id int identity(1,1) Primary key
)

create table Authors(
	author_id int identity(1,1) Primary key,
	f_name varchar(30) not null,
	l_name varchar(30) not null,
	country varchar(20)
)

select * from readers_view 

Create table Publishers(
	publisher_id int identity(1,1) Primary key,
	p_address varchar(30) not null,
	tel int Unique,
	email varchar(30) Unique,
	country varchar(30) not null
)

create table Books(
	book_id int identity(1,1) Primary key,
	book_name varchar(30) not null,
	author_id int,
	CONSTRAINT auth_id FOREIGN KEY(author_id) REFERENCES Authors(author_id),
	publisher_id int,
	CONSTRAINT pub_id FOREIGN KEY(publisher_id) REFERENCES Publishers(publisher_id),
	publician_year date not null
)

Create table Employeees(
	emp_id int identity(1,1) Primary key,
	f_n varchar(30) not null,
	l_n varchar(30) not null,
	tel int unique,
	job_id int,
	email varchar(30) unique
)

CREATE TABLE Borrowers(
	reader_id int,
	CONSTRAINT r_id FOREIGN KEY(reader_id) REFERENCES READERS(reader_id),
	date_1 date,
	date_2 date,
	book_id int,
	CONSTRAINT b_id FOREIGN KEY(book_id) REFERENCES Books(book_id),
	emp_id int,
	CONSTRAINT em_id FOREIGN KEY(emp_id) REFERENCES Employeees(emp_id)
)

create sequence sequence
increment by 1
start with 1
minvalue 1
maxvalue 100
no cycle
no cache

INSERT INTO READERS(f_name, l_name, tel_num, email) VALUES('Jim','Oliver',613346, 'oliver@gmail.com')
INSERT INTO Borrowers(reader_id, date_1, date_2, book_id, emp_id) 
	VALUES(1, 'APR 25 2017','MAY 23 2017', 2, 1)
INSERT INTO Books(book_name, publisher_id, author_id, publician_year) VALUES('Harry Potter', 1, 2, 'APR 25 2017')
INSERT INTO Publishers VALUES('Backer Street',1568965,'123@gmail','US' )
INSERT INTO Employeees VALUES('Dr','Black',465312,98,'kaisa')
INSERT INTO Authors Values('Marry', 'Poppins', 'US')

select * from Books

Create index bookID on Books(book_id)
Create index empID on Employeees(emp_id)
Create index readerID on READERS(reader_id)
Create index publisherID on Publishers(publisher_id)

Create view lib_view_1
As select * from READERS
Create view lib_view_2
As select * from Borrowers
Create view lib_view_3
As select * from Books
Create view lib_view_4
As select * from Publishers
Create view lib_view_5
As select * from Employeees
create view emp_view_for_books
as select * from Books
create view emp_view_for_readers
as select * from READERS

sp_rename 'lib_view_1', 'readers_view';
sp_rename 'lib_view_2', 'borrowers_view';
sp_rename 'lib_view_3', 'books_view';
sp_rename 'lib_view_4', 'publishers_view';
sp_rename 'employees_view', 'emp_view_for_bor';

alter view readers_view as select * from Books;
alter view borrowers_view as select * from Books;
drop view books_view
alter view publishers_view as select * from Books
alter view emp_view_for_bor as select * from Borrowers

drop view readers_view
drop view borrowers_view
drop view books_view
drop view publishers_view
drop view emp_view_for_books
drop view emp_view_for_bor
drop view emp_view_for_readers

select * from readers_view
alter view readers_view as select b.book_name, b.publician_year, a.f_name, a.l_name from Books b, Authors a, Publishers p 
	where b.author_id = a.author_id and p.publisher_id = b.publisher_id

drop table readers
drop table Employeees
drop table Borrowers
drop table Books
drop table Publishers
