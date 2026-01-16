Denna app är designad för att kunna lista lagersaldo på varje butik, samt lägga till eller ta bort böcker från en vald butik på bokhandeln.

För att komma igång med appen, kan du använda NuGet package Manager Console:
  1. Skriv Update-Database i consolen. (Migration är redan skapad)
  2. Säkerställ att databasen är skapad.
  3. Starta appen.
  4. I appen kan du välja en butik. (After att ha valt den i ComboBoxen uppdateras lagersaldot i DataGrid)
        *OBS: Det finns ingen data för saldot från början.
  5. Tryck på "Add book" knappen för att lägga till en bok på butiken.
  6. I det öppnade fönstret kan du välja vilken bok och hur många du vill lägga till. (Om du skriver annat än siffror eller lämnar textboxen tom så fungerar inte Add knappen.)
  7. Om du skriver ett minus värde och sedan trycker på Add, stängs fönstret men inga böcker kommer att läggas till.
  8. Om den valda boken redan finns i den valda butiken, läggs till böckerna i det redan existerade fältet (Fältet uppdateras) i tabellen och om den inte finns så skapas fältet.
  9. "Remove book" knappen är inaktiverad om du inte har vald en rad (en book).
  10. Efter att ha valt den önskade boken, kan du trycka på "Remove book".
  11. I det öppnade fönstret kan du skriva hur många av den valda boken du vill ta bort från den valda butiken.
  12. Samma input regler som "Add book" fönstret gäller.
  13. Om saldot på den uppdaterade boken blir 0 eller mindre så tas raden bort från tabellen. Annars uppdateras saldot.
  14. "Select Store", "Add book" samt "Remove book" är tillgängliga även via menus.
