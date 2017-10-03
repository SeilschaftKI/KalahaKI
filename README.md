# KalahaKI

UML Diagramme sind mit freeware ArgoUML bearbeitbar (evt Umstieg auf einfacheres UML Programm, ich blicks nicht), erstmal Keine Updates davon.

----

## Klassen (Erklärt in Fließtext, weil ich das mit der UML nicht hinkrieg, s.o.)

* **`class KalahaBoard`** 
  Hier sind die Slots mit den "Kugelzahlen" implementiert, sowie die Spielzüge und ihre Konsequenzen. Außerdem wird gemanaged wer an der Reihe ist. _Wahlweise_ (TODO: bei Brotcrunsher in EvoNet nachschauen wie das nochmal geht, irgendwie mit einem Fragezeichen) besitzt ein KalahaBoard ein KalahaBoardDisplay (sinvoll für Spiel mit Humanen Playern, einfache Kontrollen, Ergebnisse präsentieren. Wegzulassen beim KI Trainieren.   Luxus: Ein Weiteres Attribut soll die Größe des Boards, also die Anzahl der Slots sein.
  
* **`class KalahaBoardDisplay`**  
 Visuelle Darstellung des Spiels in einem Windows Formular. Im Falle eines `HumanPlayers` werden hier durch Klickereignis die Züge durchgefuehrt

* **`class Match`**  
  Ein Match ist eine Spielrunde mit zwei Playern (Human oder KI) und einem `KalahaBoard`
  
* **`class HumanPlayer : IPlayer`**
`ChooseMove()` Übermittelt bei Zug einen vom Spieler geklickten Slot

* **`class KIPlayer : IPlayer`**
Besitzt ein Neuronales Netz mit den "Slotfülllungen" zu Beginn des eigenen Zuges als Input, den Eigenen Slots als `OutputNeuronen`. Das Maximale `OutputNeuron` legt dann über `ChooseMove()` den nächsten Zug fest 

## Interfaces
  * **`interface IPlayer`**  
  Hat eine Methode `ChooseMove()` (vorl. Namensvorschlag) mit der er einen Möglichen Zug auswählt, sobald er an der Reihe ist.
  _Gag am "Interface"_: Jede Klasse, die von `IPlayer` erbt, muss ihre eigene Version von `ChooseMove()` Implementieren. Hier passt das auf Grund der unterschiedlichen Zug-Wahl eines `HumanPlayer` oder `KIPlayer`. Das "`I`" am Anfang eines Interface ist C#-Konvention
  
  
