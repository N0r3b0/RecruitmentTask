<details>
  <summary>Spis treści</summary>
  <ol>
    <li>
      <a href="#opis-poszczególnych-klas-i-metod">Opis Poszczególnych Klas i Metod</a>
      <ul>
        <li><a href="#modele">Modele</a></li>
        <li><a href="#kontekst-bazy-danych">Kontekst bazy danych</a></li>
        <li><a href="#kontrolery">Kontrolery</a></li>
        <li><a href="#serwisy">Serwisy</a></li>
        <li><a href="#komponenty">Komponenty</a></li>
      </ul>
    </li>
    <li>
      <a href="#wykorzystane-biblioteki">Wykorzystane Biblioteki</a>
    </li>
    <li><a href="#sposób-kompilacji-aplikacji">Sposób Kompilacji Aplikacji</a></li>
  </ol>
</details>

# Opis Poszczególnych Klas i Metod
## Modele:
### 1. Contact
- Klasa reprezentująca kontakt.
- Pola:
  - int Id: Identyfikator kontaktu.
  - string FirstName: Imię kontaktu.
  - string LastName: Nazwisko kontaktu.
  - string Email: Adres email kontaktu.
  - string Password: Hasło kontaktu.
  - string Category: Kategoria kontaktu (Business, Personal, Other).
  - string SubCategory: Podkategoria kontaktu (Dla Business dwie -> Boss, Client).
  - string PhoneNumber: Numer telefonu kontaktu.
  - DateTime BirthDate: Data urodzenia kontaktu.
  - int UserId: Identyfikator użytkownika, do którego należy kontakt.

### 2. User
- Klasa reprezentująca użytkownika.
- Pola:
  - int Id: Identyfikator użytkownika.
  - string Username: Nazwa użytkownika.
  - string Email: Adres email użytkownika.
  - string Password: Hasło użytkownika.

### 3. Category
- Klasa reprezentująca kategorię.
- Pola:
  - int Id: Identyfikator kategorii.
  - string Name: Nazwa kategorii.
  - ICollection<SubCategory> SubCategories: Kolekcja podkategorii powiązanych z tą kategorią.

### 4. SubCategory
- Klasa reprezentująca podkategorię.
- Pola:
  - int Id: Identyfikator podkategorii.
  - string Name: Nazwa podkategorii.
  - int CategoryId: Identyfikator kategorii, do której należy podkategoria.
  - Category Category: Obiekt kategorii, do której należy podkategoria.

## Kontekst Bazy Danych
### 1. ContactsContext
- Klasa reprezentująca kontekst bazy danych.
- DbSety:
  - DbSet<Contact> Contacts: Zbiór kontaktów.
  - DbSet<User> Users: Zbiór użytkowników.
  - DbSet<Category> Categories: Zbiór kategorii.
  - DbSet<SubCategory> SubCategories: Zbiór podkategorii.
- Metoda OnModelCreating(ModelBuilder modelBuilder): Konfiguruje model bazy danych, w tym relacje między tabelami i początkowe dane.

## Kontrolery:
### 1. AuthController
- Kontroler odpowiedzialny za uwierzytelnianie i rejestrację użytkowników.
- **Metody**:
  - IActionResult Login(UserLogin login): Metoda do logowania użytkownika.
  - IActionResult Register(UserRegister register): Metoda do rejestracji użytkownika.
  - User Authenticate(UserLogin login): Metoda pomocnicza do uwierzytelniania użytkownika.
  - string Generate(User user): Metoda pomocnicza do generowania tokena JWT.

### 2. ContactController
- Kontroler odpowiedzialny za zarządzanie kontaktami.
- **Metody**:
  - Task<ActionResult<IEnumerable<Contact>>> GetContacts(): Metoda do pobierania wszystkich kontaktów zalogowanego użytkownika.
  - Task<ActionResult<Contact>> GetContact(int id): Metoda do pobierania szczegółów kontaktu po identyfikatorze.
  - Task<IActionResult> PutContact(int id, Contact contact): Metoda do aktualizacji kontaktu.
  - Task<ActionResult<Contact>> PostContact(Contact contact): Metoda do tworzenia nowego kontaktu.
  - Task<IActionResult> DeleteContact(int id): Metoda do usuwania kontaktu oraz powiązanych podkategorii, jeśli kategoria to "Other".

### 3. CategoryController
- Kontroler odpowiedzialny za zarządzanie kategoriami i podkategoriami.
- **Metody**:
  - Task<ActionResult<IEnumerable<Category>>> GetCategories(): Metoda do pobierania wszystkich kategorii wraz z podkategoriami.
  - Task<ActionResult<IEnumerable<SubCategory>>> GetSubCategories(string categoryName): Metoda do pobierania podkategorii dla danej kategorii.


## Serwisy:

### 1. AuthService
- Serwis odpowiedzialny za uwierzytelnianie użytkownika.
- **Metody**:
  - login(user: UserLogin): Observable<any>: Metoda do logowania użytkownika.
  - register(user: UserRegister): Observable<any>: Metoda do rejestracji użytkownika.
  - logout(): Metoda do wylogowania użytkownika.
  - isLoggedIn(): boolean: Metoda sprawdzająca, czy użytkownik jest zalogowany.
  - isAuthenticated(): boolean: Metoda sprawdzająca, czy użytkownik jest uwierzytelniony.

### 2. ContactService
- Serwis odpowiedzialny za zarządzanie kontaktami.
- **Metody**:
  - getContacts(): Observable<Contact[]>: Metoda do pobierania wszystkich kontaktów.
  - getContact(id: number): Observable<Contact>: Metoda do pobierania szczegółów kontaktu po identyfikatorze.
  - createContact(contact: Contact): Observable<Contact>: Metoda do tworzenia nowego kontaktu.
  - updateContact(contact: Contact): Observable<void>: Metoda do aktualizacji kontaktu.
  - deleteContact(id: number): Observable<void>: Metoda do usuwania kontaktu.

### 3. CategoryService
- Serwis odpowiedzialny za zarządzanie kategoriami i podkategoriami.
- **Metody**:
  - getCategories(): Observable<Category[]>: Metoda do pobierania wszystkich kategorii.
  - getSubCategories(categoryName: string): Observable<SubCategory[]>: Metoda do pobierania podkategorii dla danej kategorii.

## Komponenty
### 1. AddContactComponent
- Komponent do dodawania nowego kontaktu.
- **Metody**:
  - ngOnInit(): Metoda inicjalizująca komponent.
  - save(): Metoda do zapisywania nowego kontaktu.
  - onCategoryChange(event: any): Metoda obsługująca zmianę kategorii.
  - loadSubCategories(categoryName: string): Metoda do ładowania podkategorii dla wybranej kategorii.

### 2. ContactDetailsComponent
- Komponent do wyświetlania i edytowania szczegółów kontaktu.
- **Metody**:
  - ngOnInit(): Metoda inicjalizująca komponent.
  - getContact(): Metoda do pobierania szczegółów kontaktu.
  - onCategoryChange(event: any): Metoda obsługująca zmianę kategorii.
  - loadSubCategories(categoryName: string): Metoda do ładowania podkategorii dla wybranej kategorii.
  - save(): Metoda do zapisywania kontaktu.
  - delete(): Metoda do usuwania kontaktu.

# Wykorzystane Biblioteki
- ASP.NET Core - Framework do tworzenia aplikacji webowych.
- Entity Framework Core - ORM do zarządzania bazą danych.
- BCrypt.Net - Biblioteka do haszowania haseł.
- System.IdentityModel.Tokens.Jwt - Biblioteka do generowania i weryfikowania tokenów JWT.
- Angular - Framework do tworzenia aplikacji frontendowych.
- RxJS - Biblioteka do programowania reaktywnego w Angularze.

# Sposób Kompilacji Aplikacji
## Backend (ASP.NET Core)
- **Otwórz projekt**: Otwórz rozwiązanie (plik .sln) w Visual Studio.
- **Przywróć pakiety NuGet**: Kliknij prawym przyciskiem myszy na rozwiązanie i wybierz Restore NuGet Packages.
- **Migracje bazy danych**: Otwórz Package Manager Console (Narzędzia > Menedżer pakietów NuGet > Konsola Menedżera pakietów) i uruchom polecenie:
  ```bash
  Update-Database
  ```
- **Kompilacja i uruchomienie aplikacji**: Kliknij Run lub naciśnij F5, aby skompilować i uruchomić aplikację.

- Aplikacja backendowa będzie dostępna pod adresem http://localhost:5050.


## Frontend (Angular)

- Instalacja zależności: Upewnij się, że masz zainstalowany Node.js i npm. W katalogu projektu frontendowego uruchom polecenie:

``` bash
npm install
```

- Kompilacja i uruchomienie: W katalogu projektu frontendowego uruchom polecenie:
``` bash
ng serve --host=127.0.0.1
```

- Aplikacja frontendowa będzie dostępna pod adresem http://127.0.0.1:4200.
