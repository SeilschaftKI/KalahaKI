# KalahaKI  
## _Aktueller Status:_

Aufgrund von **Issue 2** mach ich an den `KalahaBoardDisp`-Klassen erstmal garnix mehr und versuch mal die Zugdynamik in `KalahaBoard`zu basteln  

----

## UML Diagramm
UML Diagramme sind mit freeware ArgoUML bearbeitbar (evt Umstieg auf einfacheres UML Programm, ich blicks nicht), erstmal Keine Updates davon.

----
## Kalaha Regeln  
**Ich habe angedacht, mich an folgende Regeln zu halten:**  
Je 6 Kugeln werden in die 12 kleinen Mulden gelegt

Gewinner ist, wer bei Spielende die meisten Kugeln in seinem Kalaha hat.

Wer am Zuge ist, leert eine seiner Mulden und verteilt die Kugeln, jeweils eine, reihum im Gegenuhrzeigersinn in die nachfolgenden Mulden. Dabei wird auch das eigene Kalaha gefüllt. Das Gegner Kalaha wird ausgelassen.  

Fällt die letzte Kugel ins eigene Kalaha, ist der Spieler nochmals am Zuge.

Fällt die letzte Kugel in eine leere Mulde auf der eigenen Seite,  wird diese Kugel und alle Kugeln in der Gegner Mulde gegenüber, ins eigene Kalaha gelegt und der Gegner hat den nächsten Zug.

Das Spiel ist beendet, wenn alle Mulden eines Spielers leer sind. Der Gegner bekommt dann alle Kugeln aus seinen Mulden in sein Kalaha.

> Quelle: http://www.kalaha.de/kalaha.htm


----

## Klassen (Erklärt in Fließtext, weil ich das mit der UML nicht hinkrieg, s.o.)

* **`class KalahaBoard`** 
  Hier sind die Slots mit den "Kugelzahlen" implementiert, sowie die Spielzüge und ihre Konsequenzen. Außerdem wird gemanaged wer an der Reihe ist. _Wahlweise_ (TODO: bei Brotcrunsher in EvoNet nachschauen wie das nochmal geht, irgendwie mit einem Fragezeichen) besitzt ein KalahaBoard ein KalahaBoardDisplay (sinvoll für Spiel mit Humanen Playern, einfache Kontrollen, Ergebnisse präsentieren. Wegzulassen beim KI Trainieren.   Luxus: Ein Weiteres Attribut soll die Größe des Boards, also die Anzahl der Slots sein.
  
* **`class KalahaBoardDisplay`**  
 Parent-Klasse für Spielfeld-Formulare. Enthält Winform mit `Button_Exit`, drei `RadioButtons` in einer `GroupBox` (Schwarz an der Reihe, Weiß an der Reihe, Spiel vorbei)
 
* **`class KalahaBoardDisplaySTD : KalahaBoardDisplay`**  
Spielfeld mit Standardgröße (6 Slots + 1 Kalahafeld je Spieler, Startfüllung jedes Slots: 6). Das spart erstmal die arbeit ein formular zur Laufzeit zu erzeugen

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
  
--------------------

## ToDo und offene Fragen  
TODO-Liste und offene Fragen Stehen im Project "KalahaKI Aufbau"
  
  
