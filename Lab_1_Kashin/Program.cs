using System.Text.Json;
using System.IO;

int n;
bool working = true;

while(working)
{
    try
    {
        Console.WriteLine("Виберіть завдання (1,2,3)");
        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine();
        switch (n)
        {
            case 1:
                {
                    List<object> student1 = new List<object>() { "Петренко", "Іван", "Сергійович", 2003, 2, "ІК-41", new int[] { 85, 90, 78, 92, 88 } };
                    List<object> student2 = new List<object>() { "Іванов", "Олександр", "Миколайович", 2002, 3, "ІК-42", new int[] { 75, 87, 93, 67, 80 } };
                    List<object> student3 = new List<object>() { "Сидоренко", "Олена", "Василівна", 2001, 4, "ІК-41", new int[] { 90, 79, 85, 80, 75 } };
                    List<object> student4 = new List<object>() { "Коваленко", "Михайло", "Петрович", 2006, 2, "ІК-43", new int[] { 82, 79, 88, 90, 76 } };
                    List<object> student5 = new List<object>() { "Гончарова", "Марія", "Олегівна", 2009, 1, "ІК-44", new int[] { 92, 81, 100, 88, 99 } };
                    List<object> student6 = new List<object>() { "Новак", "Андрій", "Іванович", 2002, 3, "ІК-41", new int[] { 68, 74, 80, 90, 85 } };
                    List<object> student7 = new List<object>() { "Бойко", "Світлана", "Юріївна", 2000, 4, "ІК-42", new int[] { 85, 87, 69, 91, 93 } };
                    List<object> student8 = new List<object>() { "Мельник", "Сергій", "Олександрович", 2003, 2, "ІК-44", new int[] { 78, 82, 54, 88, 90 } };
                    List<object> student9 = new List<object>() { "Шевченко", "Анна", "Володимирівна", 2007, 1, "ІК-44", new int[] { 55, 90, 92, 76, 84 } };
                    List<object> student10 = new List<object>() { "Ткаченко", "Василь", "Григорович", 2002, 3, "ІК-41", new int[] { 80, 79, 85, 87, 82 } };
                    List<object> student11 = new List<object>() { "Павленко", "Людмила", "Сергіївна", 1997, 4, "ІК-42", new int[] { 65, 93, 90, 94, 77 } };
                    List<object> student12 = new List<object>() { "Лисенко", "Олексій", "Павлович", 2005, 2, "ІК-43", new int[] { 76, 80, 78, 82, 79 } };
                    List<object> student13 = new List<object>() { "Данилюк", "Ірина", "Михайлівна", 2004, 1, "ІК-43", new int[] { 87, 90, 83, 35, 89 } };
                    List<object> student14 = new List<object>() { "Соколова", "Наталія", "Андріївна", 1998, 4, "ІК-43", new int[] { 72, 74, 76, 68, 90 } };
                    List<object> student15 = new List<object>() { "Мартинюк", "Роман", "Володимирович", 2002, 3, "ІК-42", new int[] { 99, 75, 80, 84, 90 } };
                    List<object> student16 = new List<object>() { "Кучеренко", "Олена", "Василівна", 2003, 2, "ІК-41", new int[] { 61, 91, 93, 95, 83 } };

                    List<List<object>> students = new List<List<object>>
                                {
                                    student1, student2, student3, student4,
                                    student5, student6, student7, student8,
                                    student9, student10, student11, student12,
                                    student13, student14, student15, student16
                                };

                    students.Sort(delegate (List<object> a, List<object> b)
                    {
                        int course_a = (int)a[4];
                        int course_b = (int)b[4];

                        if (course_a != course_b)
                            return course_a.CompareTo(course_b);

                        string lastName_a = (string)a[0];
                        string lastName_b = (string)b[0];

                        return lastName_a.CompareTo(lastName_b);
                    });

                    Console.WriteLine("Відсортований список студентів за курсом та прізвищем:");
                    foreach (var student in students)
                    {
                        int[] grades = (int[])student[6];
                        string studentGrades = "";
                        for (int i = 0; i < grades.Length; i++)
                        {
                            studentGrades += grades[i];
                            if (i < grades.Length - 1)
                            {
                                studentGrades += ", ";
                            }
                        }

                        Console.WriteLine($"\n{student[0]} {student[1]} {student[2]}, {student[3]} р.н., Курс: {student[4]}, Група: {student[5]}, " + $"Оцінки: {studentGrades}");
                    }

                    Dictionary<string, List<List<object>>> groups = new Dictionary<string, List<List<object>>>();
                    foreach (var student in students)
                    {
                        string group = (string)student[5];
                        if (!groups.ContainsKey(group))
                        {
                            groups[group] = new List<List<object>>();
                        }
                        groups[group].Add(student);
                    }

                    Console.WriteLine("\nСередній бал кожної групи по кожному предмету:");
                    foreach (var i in groups)
                    {
                        string groupName = i.Key;
                        List<List<object>> groupStudents = i.Value;
                        Console.WriteLine($"\nГрупа: {groupName}");
                        for (int subj = 0; subj < 5; subj++)
                        {
                            string[] disciplines = { "ЧМ", "ТА", "Вищмат", "Фізика", "Укр.мова" };
                            double sum = 0;
                            int count = 0;
                            foreach (var student in groupStudents)
                            {
                                int[] grades = (int[])student[6];
                                sum += grades[subj];
                                count++;
                            }
                            double avg = sum / count;
                            Console.WriteLine($"{disciplines[subj]}: {avg}");
                        }
                    }

                    List<object> oldest = students[0];
                    List<object> youngest = students[0];
                    foreach (var student in students)
                    {
                        int year = (int)student[3];
                        if (year < (int)oldest[3])
                        {
                            oldest = student;
                        }
                        if (year > (int)youngest[3])
                        {
                            youngest = student;
                        }
                    }
                    Console.WriteLine($"\nНайстарший студент: {oldest[0]} {oldest[1]} {oldest[2]}, {oldest[3]} р.н., Курс: {oldest[4]}, Група: {oldest[5]}");
                    Console.WriteLine($"Наймолодший студент: {youngest[0]} {youngest[1]} {youngest[2]}, {youngest[3]} р.н., Курс: {youngest[4]}, Група: {youngest[5]}");


                    Console.WriteLine("\nНайуспішніші студенти по групах:");
                    foreach (var j in groups)
                    {
                        string groupName = j.Key;
                        List<List<object>> groupStudents = j.Value;
                        List<object> bestStudent = new List<object>() {};
                        double bestAvg = 0;
                        foreach (var student in groupStudents)
                        {
                            int[] grades = (int[])student[6];
                            double sum = 0;
                            for (int i = 0; i < grades.Length; i++)
                            {
                                sum += grades[i];
                            }
                            double avg = sum / grades.Length;
                            if (avg > bestAvg)
                            {
                                bestAvg = avg;
                                bestStudent = student;
                            }
                        }
                        Console.WriteLine($"Група {groupName}: {bestStudent[0]} {bestStudent[1]} {bestStudent[2]}, Середній бал: {bestAvg}");
                    }
                }
                break;

            case 2:
                {
                    Dictionary<int, int> dic = new Dictionary<int, int>() { };
                    Random r = new Random();
                    int stop = r.Next(6, 22);
                    int repeat = 1;
                    while (repeat < stop)
                    {
                        dic[repeat] = r.Next(-100, 101);
                        repeat++;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Дано словник:");
                    foreach (KeyValuePair<int, int> i in dic)
                    {
                        Console.WriteLine($"{i.Key}: {i.Value}");
                    }
                    Console.WriteLine();

                    int minKey = dic.Keys.Min();
                    int maxKey = dic.Keys.Max();
                    int maxValue = dic[maxKey];
                    dic.Remove(maxKey);
                    dic[minKey] = maxValue;

                    Console.WriteLine("Модифікований словник:");
                    foreach (KeyValuePair<int, int> i in dic)
                    {
                        Console.WriteLine($"{i.Key}: {i.Value}");
                    }
                    string JSON = JsonSerializer.Serialize(dic);
                    File.WriteAllText("Результат.json", JSON);
                }
                break;

            case 3:
                {
                    Dictionary<string, double> products = new Dictionary<string, double>
                    {
                        { "Фісташки", 900 },
                        { "Молоко", 35 },
                        { "Шоколад Milka", 200 },
                        { "М'ясо", 350 },
                        { "Сир", 400 },
                        { "Яблука Ред Чіф", 50 },
                        { "Вода Borjomi", 68 },
                        { "Морозиво Три Ведмеді", 149 }
                    };

                    var cheapProducts = from i in products
                                        where i.Value < 300
                                        select i;

                    var expensiveProducts = from i in products
                                        where i.Value > 300
                                        select i;

                    Console.WriteLine("Дешеві товари:");
                    foreach (var chPr in cheapProducts)
                    {
                        Console.WriteLine($"{chPr.Key}: {chPr.Value} грн");
                    }
                    Console.WriteLine();

                    Console.WriteLine("Дорогі товари:");
                    foreach (var exPr in expensiveProducts)
                    {
                        Console.WriteLine($"{exPr.Key}: {exPr.Value} грн");
                    }

                }
                break;

            default:
                {
                    Console.WriteLine("Такого завдання немає");
                }
                break;
        }
    }
    catch (Exception Error)
    {
        Console.WriteLine(Error.Message);
    }
    Console.WriteLine();
    Console.WriteLine("Повторити виконання програми? y/n");
    string choise = Console.ReadLine();
    if (choise != "y")
        working = false;
    Console.WriteLine();
    Console.WriteLine("--------------------");
}