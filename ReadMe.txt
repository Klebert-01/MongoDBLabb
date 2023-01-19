-----------------------
	TO DO
------------------------

- fixa update metod, viktigt kunna bara uppdatera en key i en collection [X]

- Generellt felhantering m�ste fixas p� det mesta [ ]
	* korrekt input! vid create och även update
	* 
- möjlighet att välja att uppdatera bara en eller alla [ ]

- STRUKTURERA UPP ENLIGT DET VI G�TT IGENOM P� LEKTIONERNA! [/]

- g�r metoder asynkrona [ ]

- l�gg till metoder för återkommande grejer typ validering av index []

- Rensa readme innan inspelning och inlämning

- kolla foreachloopen i CreateMetoden i controllern. kan förbättras

- kolla valideringen av index-input på varje metod som har i kontrollern. [ ] 3

- en "är du verkligen säker? J/N" vid uppdatering och delete [ ]

--------------------------
	BUGGAR / FELHANTERING
--------------------------
	* input datetime visar 4h fel pga tidsskillnad [X]
	* om tom input vid update ska det inte ändras till något [ ]
	* finns det 282 dok i collection, tar bort document index 281, sen skapar en ny så får den också [/]
	  indexnummer 282 eftersom att den går efter readall.count. måste sätta till senaste indexnr + 1 eller nåt