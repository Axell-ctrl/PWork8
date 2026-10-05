//********************************************************************
//*Практическая работа №8                                            *
//*Сделал Егоров Н.Н, группа 2-ИСП                                   *
//*Задание: определить кол-во баллов школ, лучшую школу и участника  *
//********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа__8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №8";//задаёт значение в заголовок консоли

            int students;
            bool ExitProgram = false;//объявление выхода из программы как ложное выражение
            Console.WriteLine("Здравствуйте!");
            while (true)//повторное выполнение программы
            {
                try
                {
                    Console.Write("Введите количество участников в 3 школах: ");
                    students = Int32.Parse(Console.ReadLine());
                    if (students <= 0)
                    {
                        Console.WriteLine("Вы ввели некорректное число студентов. Попробуйте ещё раз.");
                        continue;
                    }
                    else
                    {
                        int MaxStudentScore = 0, BestStudentNumber = 0, BestSchool = 0, i = 1, score1 = 0, score2 = 0, score3 = 0;
                        while (i <= 3)
                        {
                            int j = 1;//обновление счётчика для студентов
                            while (j <= students)
                            {
                                int score = i * 10 + j * 3;//формула для вычисления баллов
                                if (i == 1)
                                    score1 += score;
                                else if (i == 2)
                                    score2 += score;
                                else
                                    score3 += score;

                                Console.WriteLine($"Школа {i}, участник {j}: {score}");//вывод строки со школой, участником и кол-вом его баллов

                                if (score > MaxStudentScore)//если счёт больше максимального
                                {
                                    MaxStudentScore = score;//максимальный счёт равен данному
                                    BestStudentNumber = j;//записывается номер студента в зависимости значения j
                                    BestSchool = i;//записывается номер школы в зависимости значения i
                                }
                                j++;
                            }
                            i++;
                        }
                        Console.WriteLine("\nИтоговая таблица:");
                        Console.WriteLine($"Школа 1: {score1}");
                        Console.WriteLine($"Школа 2: {score2}");
                        Console.WriteLine($"Школа 3: {score3}");
                        Console.WriteLine($"Победитель: Школа {BestSchool}");
                        Console.WriteLine($"Лучший участник: Школа {BestSchool}, участник {BestStudentNumber} ({MaxStudentScore} баллов).\n");
                    }
                }
                catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                    Console.ForegroundColor = ConsoleColor.White;
                }

                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                ExitProgram = true;//флаг выхода из программы становится истинным
                                Console.WriteLine("Завершение программы.");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)//обработчик исключения FormatException (входная строка имела неправильный формат)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (OverflowException ofex)//обработчик исключения OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    catch (Exception ex)//обработка исключения Exception (все ошибки в целом)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: сообщение об ошибке из ex.Message.
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }
                if (ExitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }
            Console.ReadKey();//задержка экрана
        }
    }
}
