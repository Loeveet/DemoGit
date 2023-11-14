# Att-Göra-Lista och Enhetstester

## Uppgiftsbeskrivning
Skapa en konsolbaserad att-göra-lista och skriv enhetstester för kärnlogiken (dvs för hanteringen av uppgifter, inte för hur användaren interagerar med den). Applikationen ska tillåta användare att lägga till, visa, markera som klar, och ta bort uppgifter. Skapa test-doubles för extern lagring (databas/filsystem) för att testa detta i isolation.

## Krav
- **TodoItem Class**: Implementera en `TodoItem`-klass för att representera en uppgift med egenskaper som `Id`, `Title`, `Description`, och `IsComplete`.
- **TodoList Class**: Skapa en `TodoList`-klass som hanterar en lista av `TodoItem`-objekt. Den här klassen bör erbjuda metoder för att lägga till, visa, markera uppgifter som klara och ta bort uppgifter. Du kan också inkludera metoder för att filtrera uppgifter (t.ex. visa endast avklarade eller oavklarade uppgifter).
- **Storage Interface**: Definiera en gränssnitt, t.ex. `ITodoListStorage`, som representerar datalagring för `TodoList`. Detta gränssnitt bör inkludera metoder för att spara och ladda uppgifter.
- **TodoList Tests**: Skriv enhetstester för `TodoList`-klassen med hjälp av Moq. Mocka lagringsgränssnittet och se till att det anropas korrekt när uppgifter läggs till, tas bort eller markeras som klara.
- **Konsolapplikation**: Bygg en konsolbaserad applikation som interagerar med `TodoList`-klassen. Applikationen bör låta användare utföra följande åtgärder:
  - Lägg till en ny uppgift.
  - Visa uppgifter (alla uppgifter, avklarade uppgifter eller oavklarade uppgifter).
  - Markera en uppgift som klar.
  - Ta bort en uppgift.
  - Avsluta applikationen.
- **(OPTIONAL)**: Implementera en mocklagringsklass (MockTodoListStorage) som implementerar `ITodoListStorage`-gränssnittet men inte faktiskt lagrar data. Istället lagrar den uppgifter i minnet. Använd den här klassen i dina enhetstester istället för Moq. Vilka är fördelarna och nackdelarna med detta tillvägagångssätt?

## Uppgiftsstruktur
- Börja med att designa klassstrukturer och gränssnitt (TodoItem, TodoList, ITodoListStorage).
- Skriv enhetstester för `TodoList`-klassen med hjälp av Moq för att mocka lagringsgränssnittet.
- Implementera kärnfunktionaliteten i `TodoList`-klassen och se till att den interagerar korrekt med lagringsgränssnittet.
- Skapa konsolapplikationen för användarinteraktion.
- Testa konsolapplikationen manuellt för att säkerställa att den fungerar som förväntat.
- **(OPTIONAL)**: Om du byggde en anpassad `MockTodoListStorage`, använd denna mockade lagringsklass för datalagring under testning.
