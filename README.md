# TP214E
Vous devez FORK ce repository pour commencer votre travail.


Nom des membres:
Joy Patrick Nguefouet, Hugo Mazéas


Correction d’un bogue:
L'erreur implenté par le professeur se situe dans le xaml et cs de la page commande. 
Il a créé un window à la place d'une page. Ce qui posait problème pour la navigation entre les pages.

 Le contrôle de fenêtre (Window.xaml) est utilisé pour l'application Windows tandis que le contrôle de page (Page.xaml) est utilisé pour créer des applications hébergées par navigateur.

Le contrôle de page peut être contenu dans le contrôle de fenêtre mais l'inverse n'est pas possible.

Pour régler le bug j'ai changé windows pour page dans le xaml et cs de la page commande




