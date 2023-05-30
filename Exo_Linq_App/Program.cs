using Exo_Linq_Context;

Console.WriteLine("Exercice Linq");
Console.WriteLine("*************");

DataContext context = new DataContext();

//1 Opérateur « Select »

//Exercice 1.1 Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la
//date de naissance, le login et le résultat pour l’année de l’ensemble des étudiants.
var result_1_1a = context.Students.Select(s => new
{
    Nom = s.Last_Name,
    DateNaissance = s.BirthDate,
    Login = s.Login,
    Resultat = s.Year_Result

});

//Console.WriteLine("1.1a");
//foreach (var item in result_1_1a)
//{
//    Console.WriteLine(item);
//}

var result_1_1b = from Student s in context.Students
                  select new
                  {
                      Nom = s.Last_Name,
                      DateNaissance = s.BirthDate,
                      Login = s.Login,
                      Resultat = s.Year_Result
                  };

//Console.WriteLine("1.1b");
Console.WriteLine("1.1");
foreach (var item in result_1_1b)
{
    Console.WriteLine(item);
}


//Exercice 1.2 Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom
//et prénom séparés par un espace), son id et sa date de naissance.

var result_1_2a = context.Students
                    .Select(s => new
                    {
                        NomComplet = s.First_Name + " " + s.Last_Name,
                        ID = s.Student_ID,
                        DateDeNaissance = s.BirthDate
                    });

//Console.WriteLine("1.2a");
//foreach (var item in result_1_2a)
//{
//    Console.WriteLine(item);
//}


var result_1_2b = from s in context.Students
                  select new
                  {
                      NomComplet = s.First_Name + " " + s.Last_Name,
                      ID = s.Student_ID,
                      DateDeNaissance = s.BirthDate
                  };
//Console.WriteLine("1.2b");
Console.WriteLine("1.2");
foreach (var item in result_1_2b)
{
    Console.WriteLine(item);
}



//Exercice 1.3 Ecrire une requête pour présenter, pour chaque étudiant, dans une seule chaine de
//caractère l’ensemble des données relatives à un étudiant séparées par le symbole |.

IEnumerable<string> result_1_3a = from s in context.Students
                                  select $" {s.Student_ID}|{s.First_Name}|{s.Last_Name}|{s.BirthDate}|{s.Login}|{s.Section_ID}|{s.Year_Result}|{s.Course_ID}| ";

IEnumerable<string> result_1_3b = context.Students
                                  .Select(s => $" {s.Student_ID}|{s.First_Name}|{s.Last_Name}|{s.BirthDate}|{s.Login}|{s.Section_ID}|{s.Year_Result}|{s.Course_ID}| ");

Console.WriteLine("1.3");
foreach( string item in result_1_3b )
{
    Console.WriteLine(item);
}
Console.WriteLine();





//2 Opérateurs « Where » et « OrderBy »

//Exercice 2.1 Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut.
//Le statut prend la valeur « OK » si l’étudiant à obtenu au moins 12 comme résultat annuel
//et « KO » dans le cas contraire






//Exercice 2.2 Donner pour chaque étudiant entre 1955 et 1965 le nom, le résultat annuel et la
//catégorie à laquelle il appartient. La catégorie est fonction du résultat annuel obtenu ; un
//résultat inférieur à 10 appartient à la catégorie « inférieure », un résultat égal à 10 appartient
//à la catégorie « neutre », un résultat autre appartient à la catégorie « supérieure ».







//Exercice 2.3 Ecrire une requête pour présenter le nom, l’id de section et de tous les étudiants
//qui ont un nom de famille qui termine par r






//Exercice 2.4 Ecrire une requête pour présenter le nom et le résultat annuel classé par résultats
//annuels décroissant de tous les étudiants qui ont obtenu un résultat annuel inférieur ou égal
//à 3.






//Exercice 2.5 Ecrire une requête pour présenter le nom complet (nom et prénom séparés par un
//espace) et le résultat annuel classé par nom croissant sur le nom de tous les étudiants
//appartenant à la section 1110






//Exercice 2.6 Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel
//classé par ordre croissant sur la section de tous les étudiants appartenant aux sections 1010
//et 1020 ayant un résultat annuel qui n’est pas compris entre 12 et 18






//Exercice 2.7 Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur
//100 (nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les
//étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100
//inférieur ou égal à 60





