using Exo_Linq_Context;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;

Console.WriteLine("Exercice Linq");
Console.WriteLine("*************");

DataContext context = new DataContext();


#region Exos 1 et 2


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
foreach (string item in result_1_3b)
{
    Console.WriteLine(item);
}
Console.WriteLine();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();



//2 Opérateurs « Where » et « OrderBy »

//Exercice 2.1 Pour chaque étudiant né avant 1955, donner le nom, le résultat annuel et le statut.
//Le statut prend la valeur « OK » si l’étudiant à obtenu au moins 12 comme résultat annuel
//et « KO » dans le cas contraire








//Exercice 2.2 Donner pour chaque étudiant entre 1955 et 1965 le nom, le résultat annuel et la
//catégorie à laquelle il appartient. La catégorie est fonction du résultat annuel obtenu ; un
//résultat inférieur à 10 appartient à la catégorie « inférieure », un résultat égal à 10 appartient
//à la catégorie « neutre », un résultat autre appartient à la catégorie « supérieure ».


var result_2_2a = context.Students
                  .Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965)
                  .Select(s => new
                  {
                      Nom = s.Last_Name,
                      Resultat = s.Year_Result,
                      Categorie = s.Year_Result < 10 ? "inférieure" : (s.Year_Result > 10 ? "supérieure" : "neutre")
                  });


//var result_2_2b = from Student s in context.Students
//                  where s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965





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

var result_2_6a = context.Students
                  .Where(s => s.Section_ID == 1010 || s.Section_ID == 1020)
                  .Where(s => s.Year_Result < 12 || s.Year_Result > 18)
                  .OrderByDescending(s => s.Section_ID)
                  .Select(s => new
                  {
                      Nom = s.Last_Name,
                      Section = s.Section_ID,
                      Resultat = s.Year_Result
                  });


//var result_2_6b =





//Exercice 2.7 Ecrire une requête pour présenter le nom, l’id de section et le résultat annuel sur
//100 (nommer la colonne ‘result_100’) classé par ordre décroissant du résultat de tous les
//étudiants appartenant aux sections commençant par 13 et ayant un résultat annuel sur 100
//inférieur ou égal à 60

var result_2_7a = context.Students
                  .Where(s => s.Section_ID.ToString().StartsWith("13") && (s.Year_Result * 5) <= 60)
                  .OrderByDescending(s => s.Year_Result)
                  .Select(s => new
                  {
                      Nom = s.First_Name + " " + s.Last_Name,
                      Section = s.Section_ID,
                      Result_100 = s.Year_Result * 5
                  });

var result_2_7b = from s in context.Students
                  where Regex.IsMatch(s.Section_ID.ToString(), @"^13\d{2}$") //la regex avec @ veut dire commence par 13 , \d pour digits = chiffres et {2} pour 2 chiffres/digits $
                  && (s.Year_Result * 5) <= 60
                  orderby s.Year_Result descending
                  select new
                  {
                      Nom = s.First_Name + " " + s.Last_Name,
                      Section = s.Section_ID,
                      Result = s.Year_Result * 5
                  };




#endregion


#region Exos 3

//3 Opérateurs « Count », « Min », « Max », « Sum » et « Average »

Console.WriteLine("Exos 3");
Console.WriteLine();
Console.WriteLine();

//Exercice 3.1 Donner le résultat annuel moyen pour l’ensemble des étudiants.
double moyenneannuelle = context.Students.Average(s => s.Year_Result);
Console.WriteLine($"la moyenne annuelle des étudiant.e.s : {moyenneannuelle} ");
Console.WriteLine();


//Exercice 3.2 Donner le plus haut résultat annuel obtenu par un étudiant.

int maxresult = context.Students.Max(s => s.Year_Result);
Console.WriteLine($"le plus haut résultat annuel obtenu est de : {maxresult}");
Console.WriteLine();



//Exercice 3.3 Donner la somme des résultats annuels.

int sommeresultannuels = context.Students.Sum(s => s.Year_Result);
Console.WriteLine($"la somme des résultats annuel est de :  {sommeresultannuels}");
Console.WriteLine();


//Exercice 3.4 Donner le résultat annuel le plus faible.

int minresult = context.Students.Min(s => s.Year_Result);
Console.WriteLine($"le plus petit résultat annuel obtenu est de : {minresult}");
Console.WriteLine();


//Exercice 3.5 Donner le nombre de lignes qui composent la séquence « Students » ayant obtenu
//un résultat annuel impair.

int nbstudentimpairresult = context.Students.Count(s => s.Year_Result % 2 != 0);
Console.WriteLine($"Le nombre d'Etudiants ayant obtenu un résultat annuel impair : {nbstudentimpairresult}");
Console.WriteLine();




#endregion

Console.WriteLine("********************");
Console.WriteLine("Exercices 4 ");
Console.WriteLine();
#region Exos 4
//Opérateurs « GroupBy », « Join » et « GroupJoin »

//Exercice 4.1 Donner pour chaque section, le résultat maximum (« Max_Result ») obtenu par les étudiants.
Console.WriteLine("4.1");
Console.WriteLine();

var maxresultparsection = context.Students
    .GroupBy(s => s.Section_ID)
    .Select(s => new
    {
        Section = s.Key,
        Max_Result = s.Max(s => s.Year_Result)
    });

foreach (var result in maxresultparsection)
{
    Console.WriteLine($"Section: {result.Section},  Resultat Max: {result.Max_Result}");
}
Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.2 Donner pour toutes les sections commençant par 10, le résultat annuel moyen (« AVGResult ») obtenu par les étudiants.
Console.WriteLine("4.2");
Console.WriteLine();

var moyennedes10 = context.Students
    .Where(s => s.Section_ID.ToString().StartsWith("10")) 
    .GroupBy(s => s.Section_ID)
    .Select(group => new
    {
        Section = group.Key,
        ResultatAnnuelMoyen = group.Average(s => s.Year_Result) 
    });

foreach (var result in moyennedes10)
{
    Console.WriteLine($"La section {result.Section} a la moyenne de : {result.ResultatAnnuelMoyen} ");
}

Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.3 Donner le résultat moyen (« AVGResult ») et le mois en chiffre (« BirthMonth ») pour les étudiants né le même mois entre 1970 et 1985.
Console.WriteLine("4.3");
Console.WriteLine();

var resultmoyenneGenX = from student in context.Students
                        where student.BirthDate.Year >= 1970 && student.BirthDate.Year <= 1985
             group student by student.BirthDate.Month into g
             select new
             {
                 BirthMonth = g.Key,
                 AVGResult = g.Average(s => s.Year_Result)
             };
foreach (var item in resultmoyenneGenX)
{
    Console.WriteLine(  );

    string mois;
    switch (item.BirthMonth)
    {
        case 1:
            mois = "Janvier";
            break;
        case 2:
            mois = "Février";
            break;
        case 3:
            mois = "Mars";
            break;
        case 4:
            mois = "Avril";
            break;
        case 5:
            mois = "Mai";
            break;
        case 6:
            mois = "Juin";
            break;
        case 7:
            mois = "Juillet";
            break;
        case 8:
            mois = "Août";
            break;
        case 9:
            mois = "Septembre";
            break;
        case 10:
            mois = "Octobre";
            break;
        case 11:
            mois = "Novembre";
            break;
        case 12:
            mois = "Décembre";
            break;
        default:
            mois = "Mois inconnu";
            break;
    }

    Console.WriteLine($"Les élèves GEN_X nés au mois de {mois} ont eu une moyenne de {item.AVGResult}");
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.4 Donner pour toutes les sections qui compte plus de 3 étudiants, la moyenne des résultats annuels (« AVGResult »).
Console.WriteLine("4.4");
Console.WriteLine();

var SectionsDeTrio = from sectionGroup in
                     (from s in context.Students
                      group s by s.Section_ID into g
                      where g.Count() > 3
                      select g)
                     select new
                     {
                         Section = sectionGroup.Key,
                         AverageResult = sectionGroup.Average(s => s.Year_Result)
                     };

foreach (var section in SectionsDeTrio)
{
    Console.WriteLine($"La section {section.Section} compte plus de 3 étudiants et sa moyenne de resultat annuel est de {section.AverageResult}");
    Console.WriteLine();
}


Console.WriteLine("********************");
//Exercice 4.5 Donner pour chaque cours, le nom du professeur responsable ainsi que la section dont le professeur fait partie.
Console.WriteLine("4.5");
Console.WriteLine();

var InfoCours = context.Courses.Join(
                    context.Professors,
                    c => c.Professor_ID,
                    p => p.Professor_ID,
                    (cours, professeur) => new
                    {
                        CourseName = cours.Course_Name,
                        ProfessorName = professeur.Professor_Name,
                        Section = professeur.Section_ID
                    });

foreach (var info in InfoCours)
{
    Console.WriteLine();
    Console.WriteLine($"Le Cours : {info.CourseName} , section : {info.Section}  est sous la responsabilité du Professeur : {info.ProfessorName}");
    Console.WriteLine();
}




Console.WriteLine("********************");
//Exercice 4.6 Donner pour chaque section, l’id, le nom et le nom de son délégué. Classer les sections dans l’ordre inverse des id de section.
Console.WriteLine("4.6");
Console.WriteLine();

var InfoSectionDelegue = context.Sections.Join(
                            context.Students,
                            sec => sec.Delegate_ID,
                            s => s.Student_ID,
                            (section, student) => new
                            {
                                SectionID = section.Section_ID,
                                SectionNom = section.Section_Name,
                                DelegueNom = student.Last_Name + " " + student.First_Name
                            }).OrderByDescending(section => section.SectionID);

foreach (var info in InfoSectionDelegue)
{
    Console.WriteLine();
    Console.WriteLine($" La Section {info.SectionID} : {info.SectionNom} a pour délégué : {info.DelegueNom} ");
    Console.WriteLine();
}

Console.WriteLine("********************");
//Exercice 4.7 Donner, pour toutes les sections, le nom des professeurs qui en sont membres
//Section_ID - Section_Name :
//-Professor_Name1
//- Professor_Name2
//- …
Console.WriteLine("4.7");
Console.WriteLine();

var ProfParSection = context.Sections.GroupJoin(
                        context.Professors,
                        s => s.Section_ID,
                        p => p.Section_ID,
                        (section, professors) => new
                        {
                            SectionID = section.Section_ID,
                            SectionName = section.Section_Name,
                            Professors = professors.Select(p => p.Professor_Surname + " " + p.Professor_Name).ToList()
                        });

foreach (var item in ProfParSection)
{
    Console.WriteLine();
    Console.WriteLine($"La section {item.SectionID} : {item.SectionName} a pour membre(s) :");

    if (item.Professors.Any())
    {
        foreach (var professor in item.Professors)
        {
            Console.WriteLine($"- {professor}");
        }
    }
    else
    {
        Console.WriteLine("- Aucun professeur membre");
    }
}
Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.8 Même objectif que la question 4.7, mais seules les sections comportant au moins un professeur doivent être reprises.
Console.WriteLine("4.8");
Console.WriteLine();

var ProfParSection2 = context.Sections
    .Join(
        context.Professors,
        s => s.Section_ID,
        p => p.Section_ID,
        (section, professor) => new
        {
            SectionID = section.Section_ID,
            SectionName = section.Section_Name,
            NomProfesseur = professor.Professor_Surname + " " + professor.Professor_Name
        })
    .GroupBy(item => new { item.SectionID, item.SectionName })
    .Select(group => new
    {
        SectionID = group.Key.SectionID,
        SectionName = group.Key.SectionName,
        Professors = group.Select(item => item.NomProfesseur).ToList()
    });

foreach (var item in ProfParSection2)
{
    if (item.Professors.Any())
    {
        Console.WriteLine();
        Console.WriteLine($"La section {item.SectionID} : {item.SectionName} a pour membre(s) :");

        foreach (var professor in item.Professors)
        {
            Console.WriteLine($"- {professor}");
        }
    }
}
Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.9 Donner à chaque étudiant ayant obtenu un résultat annuel supérieur ou égal à 12 son grade en fonction de son résultat annuel et sur base de la table grade. La liste doit être classée dans l’ordre alphabétique des grades attribués.
Console.WriteLine("Exo 4.9");
Console.WriteLine();

var classementstudents = from s in context.Students
                         from g in context.Grades
                         where s.Year_Result >= g.Lower_Bound && s.Year_Result <= g.Upper_Bound && s.Year_Result >= 12
                         orderby g.GradeName ascending
                         select new
                         {
                             NomEtudiants = s.First_Name + " " + s.Last_Name,
                             Resultat = s.Year_Result,
                             Mention = g.GradeName,
                         };

foreach (var item in classementstudents)
{
    Console.WriteLine($"{item.NomEtudiants}: {item.Resultat} - {item.Mention}");
}
Console.WriteLine();
Console.WriteLine("********************");
//Exercice 4.10 Donner la liste des professeurs et la section à laquelle ils se rapportent ainsi que le(s) cour(s)(nom du cours et crédits) dont le professeur est responsable. La liste est triée par ordre décroissant des crédits attribués à un cours.
Console.WriteLine("4.10");
Console.WriteLine();




Console.WriteLine("********************");
//Exercice 4.11 Donner pour chaque professeur son id et le total des crédits ECTS (« ECTSTOT ») qui lui sont attribués. La liste proposée est triée par ordre décroissant de la somme des crédits alloués.
Console.WriteLine("4.11");
Console.WriteLine();



Console.WriteLine("********************");
// EXERCICE BONUS 1 afficher la liste des sections avec le nom  du prof et des élèves de celle-ci pour toutes les sections dont la moyenne est supérieure à la moyenne globale. Les sections dont la moyenne est supérieure à la moyenne globale. Les sections sont triées dans l'ordre des moyennes et les élèves sont classé en ordre décroissant sur base de leur résultat
Console.WriteLine("4.BONUS1");
Console.WriteLine();




Console.WriteLine("********************");
//EXERCICE BONUS 2 afficher la liste des sections (Id + Nom) avec le grade moyen de celle ci et le nom du (ou des) meilleurs étudiant(s) de celle ci .
Console.WriteLine("4.BONUS2");
Console.WriteLine(  );





Console.WriteLine("********************");
#endregion

