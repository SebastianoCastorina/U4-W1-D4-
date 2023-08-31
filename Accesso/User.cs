using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesso
{
    internal static class User
    {
        static string Username;
        static string Password;
        static bool logged = false;

        static DateTime loginDate;

        static List<ListaUtenti> listaUtenti = new List<ListaUtenti>();

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("==========OPERAZIONI==========");
            Console.ForegroundColor = ConsoleColor.Purple;
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Verifica ora e data di login");
            Console.WriteLine("4. Lista degli accessi");
            Console.WriteLine("5. Esci");
            Console.WriteLine("==============================");
            try {
                int option = int.Parse(Console.ReadLine());
                if (option > 5 || option < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("L'operazione scelta non esiste!");
                    Menu();
                } else switch(option)
                    {
                        case 1: 
                            Login();
                            Menu();
                            break;

                        case 2:
                            Logout();
                            Menu();
                            break;
                        case 3:
                            VerificaData();
                            Menu();
                            break;
                        case 4:
                            ListaAccessi();
                            Menu();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Premi INVIO per uscire");
                            break;
                    }   
            }
            catch {
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("L'operazione scelta non esiste!");
                Console.ForegroundColor = ConsoleColor.White;
                Menu();
            }
        }
        public static void Login()
        {
            if(logged)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E' già presente un utente loggato");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Inserisci Username");
                Username = Console.ReadLine();
                if(Username == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Non hai inserito un Username");
                    Login();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Inserisci Password");
                    Password = Console.ReadLine();
                    Console.WriteLine("Ripeti Password");
                    string repeatPassword = Console.ReadLine();
                    if (repeatPassword != Password)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Le password non coincidono");
                        Login();
                    }
                    loginDate = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Username} ha effettuato il Login");
                    Console.ForegroundColor = ConsoleColor.white;
                    logged = true;
                    ListaUtenti utente = new ListaUtenti(Username, Password, DateTime.Now);
                    listaUtenti.Add(utente);
                }
            }
        }

        public static void Logout()
        {
            if (logged) { 
                logged = false; 
                Console.WriteLine($"{Username} ha effettuato il Logout");
            }
            else
            {
                Console.WriteLine("Nessun Utente è loggato");                
            }
        }

        public static void VerificaData()
        {
            if (logged)
            {
                Console.WriteLine($"L'Utente {Username} ha loggato in data {loginDate}");              
            } else {
                Console.WriteLine("Nessun Utente è loggato");                
                    }
        }

        public static void ListaAccessi()
        {
            if(listaUtenti[0].username != null) { 
                foreach (ListaUtenti utenti in listaUtenti) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{utenti.username} ha loggato in data {utenti.loginDate}");
                }
            }
            
            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Nessun utente ha loggato finora"); }
            Console.ForegroundColor = ConsoleColor.White;
        }


    }

}
