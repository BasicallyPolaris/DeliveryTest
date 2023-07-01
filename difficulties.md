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