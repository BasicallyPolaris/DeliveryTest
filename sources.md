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
	- https://assetstore.unity.com/packages/3d/environments/landscapes/free-low-poly-nature-forest-205742
	- https://devilsworkshop.itch.io/hyper-casual-game-assets-low-poly-beer-pong

- Assets for Particle Effects
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
	- https://assetstore.unity.com/packages/3d/animations/basic-motions-free-154271
	- https://assetstore.unity.com/packages/3d/environments/landscapes/lowpoly-environment-pack-99479

- Tutorials:
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
