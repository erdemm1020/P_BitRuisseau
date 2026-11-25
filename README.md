# BitRuisseau

Médiathèque audio partagée avec un protocole P2P. Projet réalisé à l'ETML, 2ème trimestre, 24 périodes.

## Informations

| | |
|---|---|
| Élève | Erdem Köse (CID3b) |
| Client | Xavier Carrel |
| Dates | 11.11.2026 au 23.12.2026 |

## Le projet

BitRuisseau est un lecteur de médiatheque. On choisit un dossier avec ses fichiers audio, on les consulte et on les joue. Une fois connectée au réseaux, on peux aussi voir les médiatheques des autres, regarder ce qu'elles contiennent et importer un son chez soi pour l'écouter même quand l'autre médiatheque est éteinte.

## Objectifs

Produit
- Pouvoir consulter et jouer ses fichiers audio depuis une seule application
- Pouvoir partager sa médiathèque avec d'autres utilisateurs, sans serveur central (P2P)
- Pouvoir importer un son d'une médiathèque distante pour l'écouter hors connexion

Pédagogiques
- **Travailler en groupe** : collaborer et se mettre d'accord avec les autres
- **Faire une analyse fonctionnelle en user stories** : décrire les besoins du point de vue de l'utilisateur
- **Tenir un journal de travail** : noter régulièrement l'avancement et les problèmes rencontrés
- **Livrer le projet** : rendre dans les délais une application qui fonctionne
- **Bien doser l'utilisation de l'IA** : s'en servir comme aide tout en comprenant son travail

## User stories

| # | User story | Critères d'acceptation |
|---|---|---|
| US1 | En tant qu' utilisateur, je veux choisir et voir où sont mes contenus locaux, afin de retrouver mes fichiers audio dans l'application. | - Au tout premier démarrage, un message m'invite à choisir un dossier- Au démarrage, j'arrive sur la page principale qui affiche le ou les dossiers choisis- Aux redémarrages, le dernier choix est retenu- Je peux changer de dossier plus tard- Si le dossier n'existe plus, un message d'erreur s'affiche |
| US2 | En tant qu' utilisateur, je veux voir la liste de mes contenus locaux, afin de savoir ce que je possède. | - Chaque contenu affiche le titre, l'artiste, l'année, la durée et la taille du fichier- La durée (mm:ss) et la taille (Ko/Mo) sont lisibles- Un dossier vide affiche « Aucun contenu » |
| US3 | En tant qu' utilisateur, je veux voir les médiathèques disponibles et consulter le contenu de l'une d'elles, afin de découvrir ce que les autres partagent. | - La liste des médiathèques du réseau s'affiche- Je peux actualiser la liste- Je peux ouvrir une médiathèque et voir ses contenus- Un message s'affiche si aucune médiathèque n'est trouvée ou si l'une devient injoignable |
| US4 | En tant qu' utilisateur, je veux importer un son d'une médiathèque distante dans ma médiathèque locale, afin de pouvoir l'écouter même quand la médiathèque distante est arrêtée. | - Je peux lancer l'import depuis la liste d'une médiathèque distante- Le fichier est copié dans mon dossier local et apparaît dans ma liste- Il reste lisible quand la médiathèque distante est éteinte- Un message s'affiche si l'import échoue (connexion coupée, fichier déjà présent) |
| US5 | En tant qu' utilisateur, je veux lire un contenu de ma médiathèque, afin de l'écouter ou le regarder. | - Je peux lancer la lecture depuis la liste- Je peux mettre en pause, reprendre et arrêter- Le titre en cours de lecture est affiché- Un fichier illisible affiche un message sans planter l'application |
| US6 | En tant qu' utilisateur, je veux que ma médiathèque apparaisse sur le réseau, afin de laisser les autres consulter et importer mes contenus. | - Au démarrage, ma médiathèque est annoncée sur le réseau- Un autre utilisateur la voit dans sa liste des médiathèques- Il peut consulter mes contenus (titre, artiste, année, durée, taille)- Quand je ferme l'application, elle disparaît de sa liste |
| US7 | En tant qu' utilisateur, je veux trier ou rechercher dans ma liste de contenus, afin de trouver un titre sans tout parcourir. | - Je peux trier par titre, artiste, année, durée ou taille- Je peux filtrer en tapant du texte (titre ou artiste)- « Aucun résultat » s'affiche si rien ne correspond- Effacer la recherche ramène la liste complète |

L'US7 n'est pas dans le cahier des charges, elle ne sera faite que s'il reste du temps.

## Planification

| Semaine | Travail prévu |
|---|---|
| 1 | Analyse UX/UI du standalone, maquettes et rédaction des US |
| 2 | Mediaplayer standalone : US1 (dossier des contenus) et US2 (liste des contenus) |
| 3 | Analyse UX/UI du connecté et US6 (ma médiathèque visible sur le réseau) |
| 4 | US3 (liste des médiathèques, contenu d'une médiathèque distante) |
| 5 | US4 (import d'un son) et US5 (lecture des contenus) |
| 6 | Tests, corrections, finitions et rendu. US7 s'il reste du temps |

Cette planification est une estimation, je la corrigerai dans le journal de travail si le rythme change.

## Architecture

```
+-------------------------------------------+
|                 Interface                 |
| page principale, listes, lecteur          |
+-------------------------------------------+
      |               |               |
      v               v               v
+-------------+ +-------------+ +-------------+
| Médiathèque | |   Lecteur   | |  Réseau P2P |
|   locale    | |             | |             |
+-------------+ +-------------+ +-------------+
      |                               |
      v                               v
+-------------+               +---------------+
|  Dossier    |               | Médiathèques  |
| des fichiers|               | des autres    |
+-------------+               +---------------+
```

L'interface ne fait que de l'affichage : elle appelle les trois autres parties.

- Médiathèque locale : lit le dossier choisi, retrouve le titre, l'artiste, l'année, la durée et la taille de chaque fichier (US1, US2).
- Lecteur : joue un fichier de la médiathèque, avec pause, reprise et arrêt (US5).
- Réseau P2P : annonce ma médiathèque, trouve celles des autres, lit leur contenu et importe un fichier dans mon dossier local (US3, US4, US6).

Un fichier importé est copié dans le dossier local, il passe ensuite par la médiathèque locale comme les autres. C'est ce qui permet de l'écouter quand l'autre médiathèque est éteinte.

Ce schéma est le plan de départ, je le corrigerai si la structure du code change.

## Installation

Pour commencer il faut cloner le repo : 
```sh
git clone https://github.com/erdemm1020/P_BitRuisseau.git

cd P_BitRuisseau

dotnet run
```

## Tests

pas fait encore

## Bilan par US

Le bilan sera rempli au fur et au mesure

| US | Résultat | Déroulement | Dette technique | Problèmes restants | Apprentissage |
|---|---|---|---|---|---|
| US1 | | | | | |
| US2 | | | | | |
| US3 | | | | | |
| US4 | | | | | |
| US5 | | | | | |
| US6 | | | | | |
| US7 | | | | | |

## Documentation

- Journal de travail : [`docs/JdT-Kose-P_BitRuisseau.xlsx`](docs/JdT-Kose-P_BitRuisseau.xlsx)

- Planification : voir la section [Planification](#planification)

- Maquettes : Dans le dossier docs/maquettes/*

## Utilisation de l'IA

J'ai utilisé l'IA (Claude) pour :
- créer les maquettes
- préparer le modèle du journal de travail (le contenu est écrit par moi)
- faire le dessin d'architecture dans le rapport
- relire mon README par rapport au cahier des charges

