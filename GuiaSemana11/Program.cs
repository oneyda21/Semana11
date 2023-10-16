using System;
using GuiaSemana11;

using(var contextdb = new Context())
{
    contextdb.Database.EnsureCreated();

    bool agregarMasRegistros = true;

    while (agregarMasRegistros)
    {
        Console.Write("Ingresa los nombres: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingresa los apellidos: ");
        string apellido = Console.ReadLine();

        Console.Write("Ingrese el sexo: ");
        string sexo = Console.ReadLine();

        Console.Write("Ingrese la edad: ");
        int edad = int.Parse(Console.ReadLine());

        var estudiante = new Student()
        {
            Nombres = nombre,
            Apellidos = apellido,
            Sexo = sexo,
            Edad = edad
        };

        contextdb.Add(estudiante);
        contextdb.SaveChanges();

        Console.Write("¿Desea agregar más registros? (S/N): ");
        string respuesta = Console.ReadLine();

        agregarMasRegistros = respuesta.Trim().Equals("S", StringComparison.OrdinalIgnoreCase);
    }

    Console.WriteLine("Datos de la tabla estudiante:");
    foreach (var estudiante in contextdb.Estudiante)
    {
        Console.WriteLine($"ID: {estudiante.Id}, Nombre: {estudiante.Nombres}, Apellido: {estudiante.Apellidos}, Sexo: {estudiante.Sexo}, Edad: {estudiante.Edad}");
    }
}
