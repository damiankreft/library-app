# Opis modelu bazy danych

## Uzasadnienie braku kluczy podstawowych w tabelach związków many-many

> In the database, it will have no function, as you can't reasonably use it in a query for any type of meaningful result.
https://stackoverflow.com/a/4503891

## __Encje i atrybuty w diagramie__

### __GenericResource__

To książka w rozumieniu logicznym.
Ta encja reprezentuje generyczny zasób - np. _"A Song of Ice and Fire: a feast for crows"_

### __Edition__

Jest reprezentacją wydania książki - np.:

- _"A Song of Ice and Fire" - Bantam Books_
- _"A Song of Ice and Fire" - Voyager Books_

### __ResourceInstance__

Reprezentuje fizyczny zasób - książkę _na półce_.
