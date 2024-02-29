﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public double AverageScore { get; private set; }
        public string AcademicPerformance { get; private set; }

        public Student(int id, string name, string gender, int age, double mathScore, double physicsScore,
            double chemistryScore)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            MathScore = mathScore;
            PhysicsScore = physicsScore;
            ChemistryScore = chemistryScore;
            CalculateAverageScore();
            DetermineAcademicPerformance();
        }

        public void CalculateAverageScore()
        {
            AverageScore = (MathScore + PhysicsScore + ChemistryScore) / 3;
        }

        public void DetermineAcademicPerformance()
        {
            if (AverageScore >= 8.0)
            {
                AcademicPerformance = "Gioi";
            }
            else if (AverageScore >= 6.5)
            {
                AcademicPerformance = "Kha";
            }
            else if (AverageScore >= 5.0)
            {
                AcademicPerformance = "Trung binh";
            }
            else
            {
                AcademicPerformance = "Yeu";
            }
        }
    }

    public class StudentManager
    {
        private List<Student> students = new List<Student>();
        private int nextId = 1;

        public void AddStudent(string name, string gender, int age, double mathScore, double physicsScore,
            double chemistryScore)
        {
            Student student = new Student(nextId++, name, gender, age, mathScore, physicsScore, chemistryScore);
            students.Add(student);
        }

        public void UpdateStudent(int id, string name, string gender, int age, double mathScore, double physicsScore,
            double chemistryScore)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.Gender = gender;
                student.Age = age;
                student.MathScore = mathScore;
                student.PhysicsScore = physicsScore;
                student.ChemistryScore = chemistryScore;
                student.CalculateAverageScore();
                student.DetermineAcademicPerformance();
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ID " + id);
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Da xoa sinh vien co ID " + id);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ID " + id);
            }
        }

        public void SearchStudent(string name)
        {
            var foundStudents = students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();
            if (foundStudents.Count > 0)
            {
                Console.WriteLine("Danh sach sinh vien co ten chua '" + name + "':");
                DisplayStudentList(foundStudents);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ten chua '" + name + "'");
            }
        }

        public void SortStudentsByGPA()
        {
            var sortedStudents = students.OrderByDescending(s => s.AverageScore).ToList();
            Console.WriteLine("Danh sach sinh vien duoc sap xep theo GPA:");
            DisplayStudentList(sortedStudents);
        }

        public void SortStudentsByName()
        {
            var sortedStudents = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("Danh sach sinh vien duoc sap xep theo ten:");
            DisplayStudentList(sortedStudents);
        }

        public void SortStudentsById()
        {
            var sortedStudents = students.OrderBy(s => s.Id).ToList();
            Console.WriteLine("Danh sach sinh vien duoc sap xep theo ID:");
            DisplayStudentList(sortedStudents);
        }

        public void DisplayAllStudents()
        {
            Console.WriteLine("Danh sach sinh vien:");
            DisplayStudentList(students);
        }

        private void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-10} {5,-10} {6,-10} {7,-10} {8,-15}",
                "ID", "Ten", "Gioi tinh", "Tuoi", "Toan", "Ly", "Hoa", "Diem TB", "Hoc luc");
            foreach (var student in studentList)
            {
                Console.WriteLine("{0,-5} {1,-20} {2,-10} {3,-5} {4,-10} {5,-10} {6,-10} {7,-10:0.##} {8,-15}",
                    student.Id, student.Name, student.Gender, student.Age, student.MathScore, student.PhysicsScore,
                    student.ChemistryScore, student.AverageScore, student.AcademicPerformance);
            }
        }
    }
}

        
        
    