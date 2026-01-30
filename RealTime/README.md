# RealTime - TShock Plugin

[English](#english) | [Français](#français)

---

## English

### Description
RealTime is a TShock plugin that synchronizes your Terraria server's in-game time with real-world time. The server time will automatically update every second to match your local time.

### Features
- ? Automatic real-time synchronization
- ? Toggle on/off with simple commands
- ? Thread-safe implementation
- ? Proper resource management
- ? Error handling and logging

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
The plugin starts automatically when the server loads (if `enabled_on_startup` is true). To disable it temporarily:
```
/rt
```
To re-enable it:
```
/rt
```
To reload configuration without restarting the server:
```
/rt reload
```

### Configuration
Edit `tshock/RealTimeConfig.json`:

```json
{
  "update_interval_ms": 1000,
  "enabled_on_startup": true,
  "debug_mode": false,
  "terraria_day_start": 4.5,
  "terraria_night_start": 19.5,
  "terraria_day_duration": 54000.0,
  "terraria_night_duration": 32400.0
}
```

**Configuration Options:**
- `update_interval_ms`: Time update frequency in milliseconds (default: 1000ms = 1 second)
- `enabled_on_startup`: Auto-start plugin when server loads (default: true)
- `debug_mode`: Enable console logging of sync information (default: false)
- `terraria_day_start`: Real-time hour when day begins (default: 4.5 = 4:30 AM)
- `terraria_night_start`: Real-time hour when night begins (default: 19.5 = 7:30 PM)
- `terraria_day_duration`: Terraria day duration in game seconds (default: 54000 = 15 real hours)
- `terraria_night_duration`: Terraria night duration in game seconds (default: 32400 = 9 real hours)

**Note:** You can customize the day/night cycle to match your preferences! After modifying the configuration file, use `/rt reload` to apply changes without restarting the server.

### How It Works
The plugin maps real-world time to Terraria's game time using configurable cycles:

**Day Phase (default: 4:30 AM - 7:30 PM):**
- Real-world 15 hours ? Terraria 54,000 game seconds
- Example: 12:00 PM real-time ? Mid-day in Terraria

**Night Phase (default: 7:30 PM - 4:30 AM):**
- Real-world 9 hours ? Terraria 32,400 game seconds  
- Example: 11:00 PM real-time ? Mid-night in Terraria

The synchronization runs at the configured interval to keep the game time aligned with your local clock. All timing values are fully customizable in the configuration file.

### Author
**QviNSteN / C0sm0s**

### Version
1.2

### License
This plugin is provided as-is for TShock servers.

---

## Français

### Description
RealTime est un plugin TShock qui synchronise l'heure du jeu de votre serveur Terraria avec l'heure réelle. L'heure du serveur se met automatiquement à jour pour correspondre à votre heure locale selon les cycles jour/nuit de Terraria.

**Cycles Temporels de Terraria :**
- ?? **Jour** : 4h30 à 19h30 (15 heures temps réel)
- ?? **Nuit** : 19h30 à 4h30 (9 heures temps réel)

### Fonctionnalités
- ? Synchronisation précise avec les cycles jour/nuit de Terraria
- ? Activation/désactivation avec des commandes simples
- ? Rechargement de la configuration sans redémarrage
- ? Mode debug pour surveiller la synchronisation
- ? Implémentation thread-safe
- ? Gestion appropriée des ressources
- ? Gestion des erreurs et journalisation

### Prérequis
- TShock 5.2.4 ou supérieur
- .NET 9.0

### Installation
1. Téléchargez la dernière version
2. Placez `RealTime.dll` dans le dossier `ServerPlugins` de TShock
3. Redémarrez votre serveur
4. Le plugin créera un fichier `RealTimeConfig.json` dans votre dossier `tshock`

### Commandes
| Commande | Permission | Description |
|----------|-----------|-------------|
| `/rt` ou `/realtime` | `tshock.RealTime` | Active/désactive le plugin RealTime |
| `/rt reload` ou `/realtime reload` | `tshock.RealTime` | Recharge la configuration depuis le fichier |

### Utilisation
Le plugin démarre automatiquement au lancement du serveur (si `enabled_on_startup` est activé).

**Activer/désactiver le plugin :**
```
/rt
```

**Recharger la configuration :**
```
/rt reload
```

### Configuration
Éditez `tshock/RealTimeConfig.json` :

```json
{
  "update_interval_ms": 1000,
  "enabled_on_startup": true,
  "debug_mode": false,
  "terraria_day_start": 4.5,
  "terraria_night_start": 19.5,
  "terraria_day_duration": 54000.0,
  "terraria_night_duration": 32400.0
}
```

**Options de Configuration :**
- `update_interval_ms` : Fréquence de mise à jour en millisecondes (défaut : 1000ms = 1 seconde)
- `enabled_on_startup` : Démarrage automatique au lancement du serveur (défaut : true)
- `debug_mode` : Activer la journalisation des informations de sync (défaut : false)
- `terraria_day_start` : Heure réelle de début du jour (défaut : 4.5 = 4h30)
- `terraria_night_start` : Heure réelle de début de la nuit (défaut : 19.5 = 19h30)
- `terraria_day_duration` : Durée du jour en secondes de jeu Terraria (défaut : 54000 = 15 heures réelles)
- `terraria_night_duration` : Durée de la nuit en secondes de jeu Terraria (défaut : 32400 = 9 heures réelles)

**Note :** Vous pouvez personnaliser le cycle jour/nuit selon vos préférences ! Après modification du fichier de configuration, utilisez `/rt reload` pour appliquer les changements sans redémarrer le serveur.

### Fonctionnement
Le plugin mappe l'heure réelle sur l'heure de jeu Terraria en utilisant des cycles configurables :

**Phase de Jour (défaut : 4h30 - 19h30) :**
- 15 heures réelles ? 54 000 secondes de jeu Terraria
- Exemple : 12h00 heure réelle ? Milieu de journée dans Terraria

**Phase de Nuit (défaut : 19h30 - 4h30) :**
- 9 heures réelles ? 32 400 secondes de jeu Terraria
- Exemple : 23h00 heure réelle ? Milieu de nuit dans Terraria

La synchronisation s'exécute à l'intervalle configuré pour maintenir l'heure du jeu alignée avec votre horloge locale. Toutes les valeurs temporelles sont entièrement personnalisables dans le fichier de configuration.

### Auteur
**QviNSteN / C0sm0s**

### Version
1.2
1.2

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
