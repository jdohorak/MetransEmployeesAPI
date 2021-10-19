Vytvořte rozhraní REST API pomocí ASP.NET Core. 
1. v řešení použijte komponenty
1.1. Microsoft.EntityFrameworkCore.InMemory
1.2. Swagger UI (Swashbuckle.Core)

2. do projektu přidejte tabulku zaměstnanci (Employees)

3. nad tabulkou vytvořte CRUD operace (vytvoření nového záznamu, čtení, editaci, smazání záznamu)

3.1. GET Employees/{id}

3.2. POST Employees/Create

3.3. PUT Employees/Update

3.4. DELETE Employees/Delete

3.5. GET Employees (vrací seznam zaměstnanců, zde implementujte možnost řazení podle datumu narození a příjmení)

4. kód prosím zdokumentujte (funkce, parametry, proměnné)

Příklad hodnoty pro GET Employees/1
{
  "id": 1,
  "name": "Václav",
  "surname": "Novák",
  "dateOfBirth": "5.11.1985"
}
