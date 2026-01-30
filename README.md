# RealTime - TShock Plugin

[English](#english) | [Français](#français)

---

## English

### Description
RealTime is a TShock plugin that synchronizes your Terraria server's in-game time with real-world time. The server time will automatically update every second to match your local time.

### Features
- ✅ Automatic real-time synchronization
- ✅ Toggle on/off with simple commands
- ✅ Thread-safe implementation
- ✅ Proper resource management
- ✅ Error handling and logging

### Requirements
- TShock 5.2.4 or higher
- .NET 9.0

### Installation
1. Download the latest release
2. Place `RealTime.dll` in your TShock `ServerPlugins` folder
3. Restart your server

### Commands
| Command | Permission | Description |
|---------|-----------|-------------|
| `/rt` or `/realtime` | `tshock.RealTime` | Toggle the RealTime plugin on/off |

### Usage
The plugin starts automatically when the server loads. To disable it temporarily:
```
/rt
```
To re-enable it:
```
/rt
```

### Configuration
The plugin uses the following default settings (configurable in source code):
- **Update Interval**: 1000ms (1 second)
- **Time Offset**: 4.5 hours
- **Day/Night Transition**: 15:00 (3 PM)

### How It Works
The plugin converts your local time to Terraria's in-game time:
- Real-world hours and minutes are mapped to Terraria's day/night cycle
- Time before 15:00 (3 PM) = Daytime in Terraria
- Time after 15:00 (3 PM) = Nighttime in Terraria

### Author
**QviNSteN**

### Version
1.1

### License
This plugin is provided as-is for TShock servers.

---

## Français

### Description
RealTime est un plugin TShock qui synchronise l'heure du jeu de votre serveur Terraria avec l'heure réelle. L'heure du serveur se met automatiquement à jour toutes les secondes pour correspondre à votre heure locale.

### Fonctionnalités
- ✅ Synchronisation automatique en temps réel
- ✅ Activation/désactivation avec des commandes simples
- ✅ Implémentation thread-safe
- ✅ Gestion appropriée des ressources
- ✅ Gestion des erreurs et journalisation

### Prérequis
- TShock 5.2.4 ou supérieur
- .NET 9.0

### Installation
1. Téléchargez la dernière version
2. Placez `RealTime.dll` dans le dossier `ServerPlugins` de TShock
3. Redémarrez votre serveur

### Commandes
| Commande | Permission | Description |
|----------|-----------|-------------|
| `/rt` ou `/realtime` | `tshock.RealTime` | Active/désactive le plugin RealTime |

### Utilisation
Le plugin démarre automatiquement au lancement du serveur. Pour le désactiver temporairement :
```
/rt
```
Pour le réactiver :
```
/rt
```

### Configuration
Le plugin utilise les paramètres par défaut suivants (configurables dans le code source) :
- **Intervalle de mise à jour** : 1000ms (1 seconde)
- **Décalage horaire** : 4,5 heures
- **Transition jour/nuit** : 15h00

### Fonctionnement
Le plugin convertit votre heure locale en heure de jeu Terraria :
- Les heures et minutes du monde réel sont mappées sur le cycle jour/nuit de Terraria
- Heure avant 15h00 = Jour dans Terraria
- Heure après 15h00 = Nuit dans Terraria

### Auteur
**QviNSteN**

### Version
1.1

### Licence
Ce plugin est fourni tel quel pour les serveurs TShock.

---

## Development

### Building from Source
```bash
dotnet build RealTime.csproj
```

### Recent Improvements (v1.1)
- Added proper resource disposal
- Implemented thread-safe timer management
- Added error handling and logging
- Improved code organization
- Updated to modern C# patterns (.NET 9)
- Added meaningful description and documentation

---

*For issues, suggestions, or contributions, please contact the author.*
