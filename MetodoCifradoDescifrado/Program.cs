using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MetodoCifradoDescifrado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YO SOY UN PROGRAMADOR Y EXPERTO EN REDES EXCELENTE Y RECONOCIDO");
            //Variables necesarias
            int opcion;
            bool repetir = true;
            string mensajeParaCifrar, contraseñaMensaje, mensajeCifrado;

            //Creamos el flujo/stream en la memoria RAM
            MemoryStream memoryStream1 = new MemoryStream();

            //Pedimos la cadena que se va a guardar en el flujo
            Console.Write("Ingresa el mensaje que quieres cifrar: ");
            mensajeParaCifrar = Console.ReadLine();

            //Pedimos una contraseña para proteger el mensaje privado
            Console.Write("Ingresa una contraseña para proteger el mensaje: ");
            contraseñaMensaje = Console.ReadLine();

            //Enviamos la cadena dada por el usuario para cifrarla
            mensajeCifrado = CifrarMensaje(mensajeParaCifrar);

            //Declaramos una matriz de bytes y le asignamos la codificacion del mensaje ya cifrado para obtener una secuencia de bytes
            byte[] matrizCadenaByte = Encoding.UTF8.GetBytes(mensajeCifrado);

            //Escribimos el mensajecifrado en el flujo
            memoryStream1.Write(matrizCadenaByte, 0, matrizCadenaByte.Length);

            //Mensaje para separar el antes y despues del write
            Console.WriteLine("El mensaje esta protegido, presiona cualquier tecla para continuar");
            Console.ReadKey();

            //Empezamos a leer el string cifrado almacenado en el memorystream

            //Buferpara almacenar los bytes leidos por Read
            byte[] buferBytesLeidos = new byte[100];
            //Mover elpuntero al inicio del flujo
            memoryStream1.Seek(0, SeekOrigin.Begin);
            //leemos el contenido de nuestro flujo usando el metodo read
            memoryStream1.Read(buferBytesLeidos, 0, (int)memoryStream1.Length);
            //Descodificamos la matriz debytes leida para convertirla en un string
            string cadenaDescodificadaCifrada = Encoding.UTF8.GetString(buferBytesLeidos);

            //Mostramos el menu
            do
            {
                //Limpiamos la consola
                Console.Clear();

                Console.WriteLine("1. Mostrar mensaje: ");
                Console.WriteLine("2.Descifrar mensaje: ");
                Console.WriteLine("3. Me rindo: ");

                Console.Write("Escoje una opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {

                    case 1:
                        //Mostramos la cadena descodificada pero todavia cifrada
                        Console.WriteLine($"Mensaje:  \"{cadenaDescodificadaCifrada}\"");

                        //Mensaje deespera
                        Console.WriteLine("Presiona cualquier tecla para continuar...");
                        Console.ReadKey();

                        break;

                    case 2:
                        Console.Write("Ingresa la contraseña para descifrar el mensaje: ");
                        string posibleContraseña = Console.ReadLine();

                        if(posibleContraseña == contraseñaMensaje)
                        {
                            //Mandamos la cadena codificada almetodo "DescifrarMensaje" para ser decifrada y la devolucion la guardamos en una variable local
                            string mensajeDescifrado = DescifrarMensaje(cadenaDescodificadaCifrada);

                            //Mostramos la cadena descodificada y ya esta descifrada
                            Console.WriteLine($"Mensaje:  \"{mensajeDescifrado}\"");
                            //Mensaje de espera
                            Console.WriteLine("Presiona cualquier tecla para continuar");
                            Console.ReadKey();

                            //Cerramos el flujo
                            memoryStream1.Close();

                            //Finalizamos el programa
                            repetir = false;

                        }
                        else
                        {
                            Console.WriteLine("Contraseña incorrecta. intente de nuevo");
                            //Mensaje de espera
                            Console.WriteLine("Presiona cualquier tecla para continuar...");
                            Console.ReadKey();
                        }

                        break;

                    case 3:
                        //Finalizamos el programa
                        repetir = false;
                        break;

                        default :
                        Console.WriteLine("Escoje una opcion valida");
                        break;




                }
                
                








            } while (repetir);


        }
        static string CifrarMensaje(string mensajeCifrarPa) //Metodos
        {
            //Variable que va a guardar el mensaje cifrado
            string mensajeCifrado;

            //Le asignamos el mensaje originak a nuestra variable local vacia
            mensajeCifrado = mensajeCifrarPa;

            //reemplazamos las vocales por numeros en nuestro mensaje almacenado variable local
            mensajeCifrado = mensajeCifrado.Replace('a', '1');
            mensajeCifrado = mensajeCifrado.Replace('e', '2');
            mensajeCifrado = mensajeCifrado.Replace('i', '3');
            mensajeCifrado = mensajeCifrado.Replace('o', '4');
            mensajeCifrado = mensajeCifrado.Replace('u', '5');

            //Devolvemos el mensaje ya cifrado
            return mensajeCifrado;
        }

        static string DescifrarMensaje(string mensajeCifradoPa)
        {
            //Variable que guardara el mensaje cifrado
            string mensajeDescifrado;
            //Le asignamos el mensaje cifrado a nuestra variable local vacia
            mensajeDescifrado = mensajeCifradoPa;

            //Reemplazamos los numeros por vocales en nuestro mensaje almacenado en variable local de esta forma revertimos el cifrado

            mensajeDescifrado = mensajeDescifrado.Replace('a', '1');
            mensajeDescifrado = mensajeDescifrado.Replace('e', '2');
            mensajeDescifrado = mensajeDescifrado.Replace('i', '3');
            mensajeDescifrado = mensajeDescifrado.Replace('o', '4');
            mensajeDescifrado = mensajeDescifrado.Replace('u', '5');

            //Devolvemos el mensaje ya descifrado
            return mensajeDescifrado;

        }


    }
}
