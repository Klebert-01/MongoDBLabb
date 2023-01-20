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

- kolla valideringen av index-input på varje metod som har i kontrollern. [/]

- en "är du verkligen säker? J/N" vid uppdatering och delete [ ]

- ändra från hårdkodad "expenses vid getcollection i expenseDAO konstruktorn. gör hela klassen generisk istället för expenseODM [ ]

- lägg till logfil och lägg exceptions där istället för att bara skriva ut till anv. 

- menyn i programfile borde ligga i egen printmainmenu metod, typ ligga i viewmappen, eller i textio klassen [X]

-  toShortDate = expense.Date.ToString().Remove(10); lägg denna i egen metod används fler ggr. också om möjligt undvik använda Remove(10)

- använd lambda istället för foreachloopar för att kolla av indexnr. Ska gå att göra med findmetoden. 

- FUNTIONER LÄGG TILL
	* sök efter namn som innehåller nyckelord/produkt
	* sök mellan årtal (kanske behövs ToLocalTime där också)
	* 

--------------------------
	BUGGAR / FELHANTERING
--------------------------
	* input datetime visar 4h fel pga tidsskillnad [X]
	* om tom input vid update ska det inte ändras till något [ ]
	* finns det 282 dok i collection, tar bort document index 281, sen skapar en ny så får den också [X]
		indexnummer 282 eftersom att den går efter readall.count.
	* felhantering vid input av pris, så det inte bara blir noll [ ]
	* decimal pris verkar skickas in i mongodb som decimal men sparas som string [ ]

