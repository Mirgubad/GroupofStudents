namespace GroupofStudents
{
    using System;
    using static Helpers;
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new();
            string grname;
            while (true)
            {
            ChooseMenu:
                PrintCol("<1>.<<Add Group>>", ConsoleColor.Blue);
                PrintCol("<2>.<<See Groups>>", ConsoleColor.Blue);
                PrintCol("<3>.<<Add Student to Group>>", ConsoleColor.DarkRed);
                PrintCol("<4>.<<See Students>>", ConsoleColor.DarkRed);
                PrintCol("<5>.<<Search on Students>>", ConsoleColor.DarkRed);
                PrintCol("<6>.<<Remove Student from Group>>", ConsoleColor.Green);
                PrintCol("<7>.<<Edit Student in the Group>>", ConsoleColor.Green);
                string chooseMenuoption = ReadLine();

                if (string.IsNullOrWhiteSpace(chooseMenuoption))
                {
                    PrintCol("<<Choose option!!!>>", ConsoleColor.Red);
                }
                switch (chooseMenuoption)
                {
                    case "1":
                    #region AddGroup
                    name:
                        PrintCol("<<Name for group>>", ConsoleColor.Yellow);
                        grname = ReadLine();

                        if (string.IsNullOrWhiteSpace(grname))
                        {
                            PrintCol($"<<Write name>>", ConsoleColor.Red);
                            goto name;
                        }
                        foreach (var item in course.groups)
                        {
                            if (item.Name.ToUpper() == grname.ToUpper())
                            {
                                PrintCol($"<<{grname} cannot created,already this gorup has created>>", ConsoleColor.Red);
                                goto ChooseMenu;
                            }
                        }
                        Group group = new(grname);
                        course.groups.Add(group);
                        PrintCol($"<<{grname} Successfully created>>", ConsoleColor.Green);
                        goto ChooseMenu;
                    #endregion
                    case "2":
                        #region SeeGroup
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<There is no any group created>>", ConsoleColor.Red);
                        }
                        foreach (var item in course.groups)
                        {
                            PrintCol(item.Name, ConsoleColor.DarkBlue);
                        }
                        break;
                    #endregion
                    case "3":
                        #region AddStudentTogroup
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<There is no any group created>>", ConsoleColor.Red);
                            goto ChooseMenu;
                        }
                        foreach (var item in course.groups)
                        {
                            PrintCol(item.Name, ConsoleColor.DarkCyan);
                        }
                    group:
                        PrintCol("<<Choose the group>>", ConsoleColor.DarkGreen);
                        string choosegr = ReadLine();
                        if (string.IsNullOrEmpty(choosegr))
                        {
                            PrintCol($"<<Group name was incorrect!!!>>", ConsoleColor.Red);
                            goto group;
                        }
                        Student student = new();
                        foreach (var item in course.groups)
                        {
                            if (item.Name.ToUpper() == choosegr.ToUpper())
                            {
                                PrintCol($"{item.Name} have choosen", ConsoleColor.DarkCyan);
                            stname:
                                PrintCol("<<Student name:>>", ConsoleColor.DarkGreen);
                                student.Name = ReadLine();
                                if (string.IsNullOrWhiteSpace(student.Name))
                                {
                                    PrintCol("<<You can't next name!!!>>", ConsoleColor.Red);
                                    goto stname;
                                }
                            stsurname:
                                PrintCol("<<Student SurName:>>", ConsoleColor.DarkGreen);
                                student.SurName = ReadLine();
                                if (string.IsNullOrWhiteSpace(student.SurName))
                                {
                                    PrintCol("<<You can't next surname!!!>>", ConsoleColor.Red);
                                    goto stsurname;
                                }
                            age:
                                PrintCol("<<Student Age:>>", ConsoleColor.DarkGreen);
                                string stage = ReadLine();
                                bool age = int.TryParse(stage, out int ages);
                                student.Age = ages;
                                if (!age||ages<=0)
                                {
                                    PrintCol("<<Age was incorrect!!!>>", ConsoleColor.Red);
                                    goto age;
                                }
                            grade:
                                PrintCol("<<Student Grade:>>", ConsoleColor.DarkGreen);
                                string stgrade = ReadLine();
                                bool grade = int.TryParse(stgrade, out int grades);
                                student.Grade = grades;
                                if (!grade|| grades<0||grades>=100)
                                {
                                    PrintCol("<<Grade was incorrect!!!>>", ConsoleColor.Red);
                                    goto grade;
                                }
                                item.students.Add(student);
                                PrintCol($"<<{student.Name} is added group {item.Name}>>", ConsoleColor.Green);
                                goto ChooseMenu;
                            }
                        }
                        PrintCol("<<There is no such as group>>", ConsoleColor.DarkCyan);
                        break;
                    #endregion
                    case "4":
                        #region SeeStudent  
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<Group list is empty>>", ConsoleColor.Red);
                            goto ChooseMenu;
                        }
                        foreach (var item in course.groups)
                        {
                            PrintCol($"{item.Name}", ConsoleColor.Yellow);
                        }
                    groupchoose:
                        PrintCol("Choose Which group you want see:", ConsoleColor.Green);
                        string grpname = ReadLine();
                        if (string.IsNullOrWhiteSpace(grpname))
                        {
                            PrintCol($"<<Group name was incorrect!!!>>", ConsoleColor.Red);
                            goto groupchoose;
                        }
                        foreach (var item in course.groups)
                        {
                            if (grpname.ToUpper() == item.Name.ToUpper())
                            {
                                if (item.students.Count == 0)
                                {
                                    PrintCol($"<<There is no Student in <<{item.Name}>>", ConsoleColor.Red);
                                    goto ChooseMenu;
                                }
                                if (item.students.Count != 0)
                                {
                                    foreach (var item1 in item.students)
                                    {

                                        PrintCol($"<< Name:{item1.Name} <<>> SurNAme:{item1.SurName} <<>> Age:{item1.Age} <<>> Grade:{item1.Grade} >>", ConsoleColor.DarkYellow);

                                    }
                                }
                                goto ChooseMenu;
                            }
                        }
                        PrintCol($"<<There is no <<{grpname}>> group in Group list>>", ConsoleColor.Red);
                        break;
                    #endregion
                    case "5":
                        #region Search Student  
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<There is no any group created>>", ConsoleColor.Red);
                            goto ChooseMenu;
                        }
                    stsearch:
                        PrintCol($"<<Search on Students>>", ConsoleColor.Red);
                        string stsearch = ReadLine();
                        if (string.IsNullOrWhiteSpace(stsearch))
                        {
                            PrintCol($"<<Input was incorrect!!!>>", ConsoleColor.Red);
                            goto stsearch;
                        }
                        foreach (var item in course.groups)
                        {
                            foreach (var st in item.students)
                            {
                                if (stsearch.ToUpper().Contains(st.Name.ToUpper()))
                                {
                                    PrintCol($"<<Result = <<Name:{st.Name} ID:{st.ID}>> >>", ConsoleColor.DarkCyan);
                                }

                            }
                            goto ChooseMenu;
                        }
                        PrintCol(" <<There is no result>>", ConsoleColor.Red);

                        break;
                    #endregion
                    case "6":
                        #region Search on Students
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<Group list is empty>>", ConsoleColor.Red);
                            goto ChooseMenu;
                        }
                        PrintCol($"<<Group List:>>", ConsoleColor.Red);
                        foreach (var item in course.groups)
                        {
                            PrintCol($"<<{item.Name}>>", ConsoleColor.Green);
                        }
                    choosegroup:
                        PrintCol($"<<Choose Group>>", ConsoleColor.Red);
                        string choosegroup = ReadLine();
                        if (string.IsNullOrWhiteSpace(choosegroup))
                        {
                            PrintCol($"<<Input was incorrect!!!>>", ConsoleColor.Red);
                            goto choosegroup;
                        }

                        foreach (var item in course.groups)
                        {
                            if (choosegroup == item.Name)
                            {
                                foreach (var item1 in item.students)
                                {
                                    PrintCol($"<<ID:{item1.ID} Name:{item1.Name}>>", ConsoleColor.Yellow);
                                }
                            }
                            else if (choosegroup != item.Name)
                            {
                                PrintCol($"<<There is no {choosegroup} in group list>>", ConsoleColor.Red);
                                goto choosegroup;
                            }
                        }
                    id:
                        PrintCol($"<<Remove Student with ID>>", ConsoleColor.Red);
                        string removeid = ReadLine();
                        bool id = int.TryParse(removeid, out int stid);
                        if (!id)
                        {
                            PrintCol($"<<Incorrect ID!!!>>", ConsoleColor.Red);
                            goto id;
                        }
                        foreach (var item in course.groups)
                        {
                            foreach (var item1 in item.students)
                            {
                                if (stid == item1.ID)
                                {
                                    PrintCol($"<<Are You Sure? yes/no>>", ConsoleColor.Red);
                                    string result = ReadLine();
                                    if (result == "yes")
                                    {
                                        item.students.Remove(item1);
                                        PrintCol($"<<{item1.Name} {item1.SurName} is removed from list>>", ConsoleColor.Red);
                                        break;
                                    }
                                }
                                else if (stid != item1.ID)
                                {
                                    PrintCol($"<<ID isn't maching>>", ConsoleColor.Red);
                                    goto id;
                                }
                            }
                        }
                        break;
                    #endregion
                    case "7":
                        #region Edit Students
                        if (course.groups.Count == 0)
                        {
                            PrintCol($"<<There is no any group created>>", ConsoleColor.Red);
                            goto ChooseMenu;
                        }
                        PrintCol($"<<Group List:>>", ConsoleColor.Red);
                        foreach (var item in course.groups)
                        {
                            PrintCol($"<<{item.Name}>>", ConsoleColor.Green);
                        }
                    choosegroup1:
                        PrintCol($"<<Choose Group>>", ConsoleColor.Red);
                        string choosegroup1 = ReadLine();
                        if (string.IsNullOrWhiteSpace(choosegroup1))
                        {
                            PrintCol($"<<Input was incorrect!!!>>", ConsoleColor.Red);
                            goto choosegroup1;
                        }

                        foreach (var item in course.groups)
                        {
                            if (choosegroup1 == item.Name)
                            {
                                foreach (var item1 in item.students)
                                {
                                    PrintCol($"<<ID:{item1.ID} Name:{item1.Name}>>", ConsoleColor.Yellow);
                                }
                            }
                        }
                    id1:
                        PrintCol($"<<Edit Student with ID>>", ConsoleColor.Red);
                        string editid1 = ReadLine();
                        bool id1 = int.TryParse(editid1, out int stid1);
                        if (!id1)
                        {
                            PrintCol($"<<Incorrect ID!!!>>", ConsoleColor.Red);
                            goto id1;
                        }
                        foreach (var item in course.groups)
                        {
                            foreach (var item1 in item.students)
                            {
                                if (stid1 == item1.ID)
                                {
                                    PrintCol($"<<Are You Sure? yes/no>>", ConsoleColor.Red);
                                    string result = ReadLine();
                                    if (result == "yes")
                                    {
                                        PrintCol($"<<Enter the new name>>", ConsoleColor.Yellow);
                                        string newname = ReadLine();
                                        item1.Name = newname;
                                        PrintCol($"<<Enter the new Surname>>", ConsoleColor.Yellow);
                                        string newsurname = ReadLine();
                                        item1.SurName = newsurname;
                                    age:
                                        PrintCol("<<Student's new Age:>>", ConsoleColor.DarkGreen);
                                        string newstage = ReadLine();
                                        bool newage = int.TryParse(newstage, out int newages);
                                        item1.Age = newages;
                                        if (!newage)
                                        {
                                            PrintCol("<<Age was incorrect!!!>>", ConsoleColor.Red);
                                            goto age;
                                        }
                                    grade:
                                        PrintCol("<<Student Grade:>>", ConsoleColor.DarkGreen);
                                        string newstgrade = ReadLine();
                                        bool newgrade = int.TryParse(newstgrade, out int newgrades);
                                        item1.Grade = newgrades;
                                        if (!newgrade)
                                        {
                                            PrintCol("<<Grade was incorrect!!!>>", ConsoleColor.Red);
                                            goto grade;
                                        }
                                        PrintCol($"<<{item1.Name} {item1.SurName} is edited>>", ConsoleColor.Red);
                                    }
                                    break;
                                }
                                else if (stid1 != item1.ID)
                                {
                                    PrintCol($"<<{stid1}is wrong id!!!>>", ConsoleColor.DarkGreen);
                                    goto id1;
                                }
                            }
                        }
                        break;
                    #endregion                    
                    default:
                        break;
                }
            }
        }
    }
}
