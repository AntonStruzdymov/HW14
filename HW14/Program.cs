using HW14Library;
var pers1 = new Person("Иван", "Иванов", 11);
var validation = pers1.IsValid();
var pers2 = new Person("Ivan", "Ivanov", 1000);
var validation2 = pers2.IsValid();
Console.ReadLine();