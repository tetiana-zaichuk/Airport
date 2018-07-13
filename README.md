# Airport
Homework (bsa 18). Project Structure

Academy 2018 • Project Structure
Створити проект ASP.NET Core WebAPI і реалізувати ендпоінти які ви описували в попередньому домашньому завданні. Створити модель для всіх сутностей які ви описували. Також потрібно добавити якісь seeds дані які будуть по замовчуванню завантажені.

Мы, как диспетчеры должны иметь CRUD операции над всеми сущностями.

Классы должны выглядеть таким образом:

Рейсы (номер рейса, пункт отправления, время отправления, пункт назначения, время прилета в назначенное место, билет)

Билет (Id, цена, номер рейса)

Вылеты (Id, номер рейса, дата вылета, экипаж, самолет)

Стюардессы (Id, Имя, Фамилия, Дата Рождения)

Пилоты (Id, Имя, Фамилия, Дата Рождения, Опыт (например 3 года))

Экипаж (Id, Пилот (1), Стюардессы (1 или более)

Самолет (Id, Название самолета, Тип самолета, Дата выпуска самолета с завода, срок эксплуатации (TimeSpan)

Типы самолетов (Id, модель самолета, кол-во мест, грузоподъемность(кг))

Серед важливих нюансів:

Розділити всю логіку на слої: Presentation Layer - controller, Business Layer - service, Data Access Layer - repository.

Використати IoC контейнер, тобто розбити всю логіку на різні сервіси та створити для них абстракції (все за IoC і Dependency Inversion Principle).

Мати два набори класів: DTO та Model. Використати мапінг (можна задіяти бібліотеку AutoMapper).

Додати валідацію (по бажанню можна використати бібліотеку FluentValidation)

Для роботи з даними реалізувати один з підходів які були описані в лекції, або якщо ви знаєте якийсь інакший, який на вашу думку краще підійде для цього завдання. Проте зберігати їх поки в пам’яті. (Не потрібно реалізовувати операції з реальною базою даних!).
