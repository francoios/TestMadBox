# TestMadBox
TestForMadbox


Ce projet est un projet test pour l'entreprise MadBox,

Il contient un serveur node js contenant avec 3 services integrer a celui ci sur les routes suivantes : 

/TestServer (obsolete)
/GetScore (renvoie la liste des scores)
/AddScore (ajoute un user : score a la liste) 

ainsi qu'un projet Unity, comprenant un menu, avec sous menu.
Dans le menu il est possible d'envoyer un score, ainsi que de consulter la liste des scores.

L'application Unity est fait sous Observer pattern, pour compartimenté au maximum les features existante, et pouvoir branché de futur features si besoins sans avoir besoins de toucher au coeur de celle-ci.

Ce projet a ete réaliser en 4H de travail.

Pour des soucis de conaissances et de temps de réalisation de ce projet aucune base de données n'as été utiliser dans le cadre du stockage des données Json pour les scores. celles ci sont donc stocké a même le serveur dans un fichier .json

Aucun obstacle n'as été rencontrer pendant la réalisation de ce projet.


Les features pouvant avoir un impact et ajouter du contenu sur ce POC, serait l'ajout de la suppression d'un score, la possibilité de mettre a jour un score, ainsi que la possibilité de cherche le score en fonction du nom du joueur.

L'ui du menu est sensé être responsive toutes plateformes (non testé)
N'hesitez pas a me faire part de feedback.


