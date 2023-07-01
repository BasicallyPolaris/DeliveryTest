# Steuerung

## Aufgabe 1:

- Umsetzung in Projekt1 ODER Projekt DeliveryTest-Szene A1-Beerpong
- Steuerung mit der Maus
- Klicke und ziehe den Ball, um ihn in einen Becher zu schleudern
- Landet der Ball im Becher, so verschwindet der Becher, Ziel ist es alle Becher abzuräumen
- Reset Button dient dazu den ball, falls er irgendwie stuck ist oder nicht zurück kommt, manuell zu resetten. Score wird oben Links angezeigt im UI.

## Aufgabe 2:

- Umsetzung in Projekt2 ODER Projekt DeliveryTest-Szene A2-IK
- Steuerung mit Maus und Tastatur
- Leertaste um zu springen und um das Spiel zu beginnen
- WASD zur Bewegung
- Shift um zu rennen
- Bewege die Maus um die Kamera zu bewegen (nur Horizontal)

## Aufgabe 3:

- Umsetzung in Projekt3 ODER Projekt DeliveryTest-Szene A3-Turtles 
- Steuerung mit der Maus
- Bewege die Maus umher, um den Pilz zu verschieben
- Die Schildkröten verhalten sich unterschiedlich je nach Farbe:
  - Grün: Finden sich in Gruppen zusammen um den Pilz zu verfolgen
  - Lila: Sucht den Pilz
  - Gelb: Verfolgen die grünen Schildkröten

# Schwierigkeiten

## Aufgabe 1:
- Der ShaderGraph für das Material des Balls und der Becher hat nicht auf jedem PC richtig funktioniert. Um das zu umgehen haben wir den generierten Code des Shadergraphs in einen eigenen normalen Shader gepasted und dann ging es Device-Unabhängig. 
- Ansonsten lief alles relativ gut, das mit den Physic Materials und der Bouncyness musste man noch etwas ausprobieren, jedoch haben wir uns dafür entschieden dem Tisch auch bouncyness zu geben um eine andere Setting bei dem Ball & Cup wählen zu können, sodass der Ball auf dem Tisch gut abprallt aber bei den Cups weniger gut, damit der auch dort gescheit landen kann.

## Aufgabe 2:
- Das Player Movement ist relativ scrappy und wir hatten keine gute möglichkeit gefunden ohne viel extra aufwand mehr als die 4 Animationen (Jumping, Walking, Running, Idle) zu implementieren. Das Landen des Character Models ist auch etwas unschön das die IK zu früh triggered und so den fuß bereits auf dem Boden platziert wenn eigentlich noch die Fall animation abgespielt werden sollte.
- Nach mehreren Stunden rumarbeiten mit dem Character Rigging tool hab ich mich für Inverse Kinematics mit dem Character Animator entschieden. Irgendwas mit den Raycasts und der Fußposition hatten wir irgendwie nicht richtig mit dem rigging tool umgesetzt bekommen. Die Inverse Kinematics mit dem Character Animator war jedoch sehr einfach und schnell umsetzbar.

## Aufgabe 3:
Größte Schwierigkeit:
Die Unity Funktionalität zu Navigations Agenten zu verstehen, war herausfordernd an dieser Aufgabe.
Der Editor in Unity erlaubt es einem zusätzliche Features wie mehrere Agententypen zu verwenden, obwohl diese nur durch Erweiterungen funktionieren.
Die Fehlermeldungen die bei Verwendung von mehreren Agententypen ausgegeben werden, beziehen sich auf ein anderes Problem und führen nur zu falschen Ansätzen beim Debugging.

# Quellen

## Aufgabe 1:
- Throwing mechanics:
    - https://www.youtube.com/watch?v=99yIg-A5eCw&list=PLGXzgnKhu_mCTmg_AS66j8U7duSzcsub7
    - Beschreibt wie durch Ziehen mit der Maus eine Kugel gesteuert werden kann, um werfen zu simulieren. 
    - Fokus liegt hierbei wie an die Eingaben der Maus gelangt werden kann und wie diese sich auf die Kräfte, die auf ein Objekt im Spiel wirken sollen, übersetzen lassen.
    - Die Translation auf die Kräfte wurde umgekehrt um das Verhalten einer Schleuder zu simulieren.

- Movable Objects Tutorial:
	- https://www.youtube.com/watch?v=0yHBDZHLRbQ

- Low Poly Assets
	- Für die Umgebung des Bierpong Tisches
		- https://assetstore.unity.com/packages/3d/environments/landscapes/free-low-poly-nature-forest-205742
		- https://devilsworkshop.itch.io/hyper-casual-game-assets-low-poly-beer-pong

- Assets for Particle Effects
	- Wurden im Endeffekt doch nicht verwendet
		- https://assetstore.unity.com/packages/vfx/particles/particle-pack-127325	
	
- Unity-Tutorials: 
	- https://www.youtube.com/watch?v=vmLIy62Gsnk

- Unity API Docs:
	- https://docs.unity3d.com/ScriptReference/Rigidbody.html
	- https://docs.unity3d.com/ScriptReference/SerializeField.html
	- https://docs.unity3d.com/ScriptReference/Transform-position.html
	- https://learn.unity.com/tutorial/ui-components
    
## Aufgabe 2
- Assets:
	- Wurden verwendet um keien Animationen selbst zu erstellen und ein schnelles enviornment zu erstellen für den Charakter
		- https://assetstore.unity.com/packages/3d/animations/basic-motions-free-154271
		- https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-environment-pack-99479

- Tutorials:
	- Gehen auf Inverse Kinematics ein, teilweise mit dem Rigging Tool oder dem Animation Tool, hauptsächlich verwendet um die Logik der IK zu verstehen und das vorgehen mit Raycasts
		- https://youtube.com/playlist?list=PLD\_vBJjpCwJsqpD8QRPNPMfVUpPFLVGg4
		- https://www.youtube.com/watch?v=TUBHvQ2XEJs
		- https://www.youtube.com/watch?v=qc0xU2Ph86Q
		- https://www.youtube.com/watch?v=rGB1ipH6DrM

## Aufgabe 3:
- Assets:
    - https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-environment-pack-99479
        - Hieraus wurden Bäume und Materialien verwendet, um keine eigenen Shader und Materialien verwenden zu müssen.
    - https://assetstore.unity.com/packages/3d/environments/simplistic-low-poly-nature-93894
        - Steine, Bäume und Terrain werden eingesetzt, um das Navigationsmesh zu gestalten. 
        - Das Schildkrötenmodell stellt alle NPCs in der Szene dar, jeweils mit veränderten Farben
        - Der enthltene Animation-Controller wurde korrekt eingebaut und um Zustände erweitert, außerdem wurden Kollision hinzugefügt.

- Learning Animation Controllers:
    - https://www.youtube.com/watch?v=FF6kezDQZ7s
    - Grundlagenwissen wie Animation-Controller funktioniern
    - Stellt den Zusammenhang zwischen Skripten und dem Unity Interface vor
    - Wurde verwendet um zwischen Idle- und LAufanimationen zu wechseln

- Learning Flocking:
    - https://learn.unity.com/tutorial/flocking#6317c572edbc2a2290a9e350
    - Die ersten beiden Teile erklären wie man einen Flock organisiert und die einzelnen NPCs in einem Flock miteinander über einen gemeinsamen Manager kommuniziern lässt
    - Auf Grundlage von diesem wurde die eigene Manager Klasse entwickelt und um Zustände, Routinen und weitere Funktionalität erweitert
    - Außerdem wurde das Verhalten des Flocks mit dem AI-Navigation-Agent von Unity kombiniert
