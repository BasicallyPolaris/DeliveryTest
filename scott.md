# Quellen
## Aufgabe 1:
Throwing mechanics:
- https://www.youtube.com/watch?v=99yIg-A5eCw&list=PLGXzgnKhu_mCTmg_AS66j8U7duSzcsub7
    - Beschreibt wie durch Ziehen mit der Maus eine Kugel gesteuert werden kann, um werfen zu simulieren. 
    - Fokus liegt hierbei wie an die Eingaben der Maus gelangt werden kann und wie diese sich auf die Kräfte, die auf ein Objekt im Spiel wirken sollen, übersetzen lassen.
    - Die Translation auf die Kräfte wurde umgekehrt um das Verhalten einer Schleuder zu simulieren.

## Aufgabe 3:
Größte Schwierigkeit:
Die Unity Funktionalität zu Navigations Agenten zu verstehen, war herausfordernd an dieser Aufgabe.
Der Editor in Unity erlaubt es einem zusätzliche Features wie mehrere Agententypen zu verwenden, obwohl diese nur durch Erweiterungen funktionieren.
Die Fehlermeldungen die bei Verwendung von mehreren Agententypen ausgegeben werden beziehen sich auf ein anderes Problem und führen nur zu falschen Ansätzen beim Debugging.

Assets:
- https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-environment-pack-99479
    - Hieraus wurden Bäume und Materialien verwendet, um keine eigenen Shader und Materialien verwenden zu müssen.
- https://assetstore.unity.com/packages/3d/environments/simplistic-low-poly-nature-93894
    - Steine, Bäume und Terrain werden eingesetzt, um das Navigationsmesh zu gestalten. 
    - Das Schildkrötenmodell stellt alle NPCs in der Szene dar, jeweils mit veränderten Farben
    - Der enthltene Animation-Controller wurde korrekt eingebaut und um Zustände erweitert, außerdem wurden Kollision hinzugefügt.

Learning Animation Controllers:
- https://www.youtube.com/watch?v=FF6kezDQZ7s
    - Grundlagenwissen wie Animation-Controller funktioniern
    - Stellt den Zusammenhang zwischen Skripten und dem Unity Interface vor
    - Wurde verwendet um zwischen Idle- und LAufanimationen zu wechseln

Learning Flocking:
- https://learn.unity.com/tutorial/flocking#6317c572edbc2a2290a9e350
    - Die ersten beiden Teile erklären wie man einen Flock organisiert und die einzelnen NPCs in einem Flock miteinander über einen gemeinsamen Manager kommuniziern lässt
    - Auf Grundlage von diesem wurde die eigene Manager Klasse entwickelt und um Zustände, Routinen und weitere Funktionalität erweitert
    - Außerdem wurde das Verhalten des Flocks mit dem AI-Navigation-Agent von Unity kombiniert
