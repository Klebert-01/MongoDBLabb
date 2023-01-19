-----------------------
	TO DO
------------------------

- fixa update metod, viktigt kunna bara uppdatera en key i en collection [X]

- Generellt felhantering m�ste fixas p� det mesta [ ]
	* korrekt input! vid create och även update
	*

- STRUKTURERA UPP ENLIGT DET VI G�TT IGENOM P� LEKTIONERNA! [/]

- g�r metoder asynkrona [ ]

- l�gg till metoder f�r �terkommande grejer typ validering av index []

- Rensa readme innan inspelning och inlämning

-   // kolla foreachloopen i CreateMetoden i controllern. kan förbättras


--------------------------
	BUGGAR / FELHANTERING
--------------------------
	* input datetime visar 4h fel pga tidsskillnad [ ]
	* om tom input ska det inte �ndras till n�got [ ]
	* finns det 282 dok i collection, tar bort document index 281, sen skapar en ny så får den också [/]
	  indexnummer 282 eftersom att den går efter readall.count. måste sätta till senaste indexnr + 1 eller nåt