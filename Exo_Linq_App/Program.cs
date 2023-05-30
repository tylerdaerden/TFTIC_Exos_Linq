using Exo_Linq_Context;

Console.WriteLine("Exercice Linq");
Console.WriteLine("*************");

DataContext context = new DataContext();

//1 Opérateur « Select »

//Exercice 1.1 Ecrire une requête pour présenter, pour chaque étudiant, le nom de l’étudiant, la
//date de naissance, le login et le résultat pour l’année de l’ensemble des étudiants.






//Exercice 1.2 Ecrire une requête pour présenter, pour chaque étudiant, son nom complet (nom
//et prénom séparés par un espace), son id et sa date de naissance.






//Exercice 1.3 Ecrire une requête pour présenter, pour chaque étudiant, dans une seule chaine de
//caractère l’ensemble des données relatives à un étudiant séparées par le symbole |.






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





