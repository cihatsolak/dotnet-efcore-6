-- parameteresiz (table-valued function)

--create function fc_student_teacher_full()
--returns table
--as
--return (
--select 
--st.Age as 'StudentAge',
--ts.ClassName as 'TeacherClassName'
--from Students st
--join Teachers ts on st.Id = ts.Id
--)

-- select * from fc_student_teacher_full

------------

-- parametreli (table-valued function)

--create function fc_student_teacher_full_id(@age int)
--returns table
--as
--return (
--select 
--st.Age as 'StudentAge',
--ts.ClassName as 'TeacherClassName'
--from Students st
--join Teachers ts on st.Id = ts.Id
--where st.Age < @age
--)

-- select * from fc_student_teacher_full_id(55)

------------

