﻿# Тестовый пример приложения расчета ЗП

Для авторизаций (пользователи равно равны)
Guest пароль пустой
Reader пароль reader
Administrator пароль admin

Модель данных:
-Salary - расчет ЗП
  ID Первичный ключ
  EmployeeID/Employee Внешний ключ на Employee
  Date Дата расчета
  Money Сумма расчет		
-Employee – Сотрудник (базовой класс)
  ID Первичный ключ
  Name Наименование
  BaseRate Базовый оклад
  Дата приема на работу
  HeadID/Employee Head Начальник (внешний ключ на Employee) для формирования иерархической структуры подчиненности
  IsCanHead Служебное поле признак возможности стать начальником (для удобства выбора в диалогах)
-Manager – Менеджер (наследован от Employee) (по умолчанию проставляется признак может быть начальником)
-Salesman – Продавец (наследован от Employee) (по умолчанию проставляется признак может быть начальником)

Подчинение между возможно только в режиме у каждого сотрудника может быть 1 начальник (подходит для большинства небольших организация).
Для матричной структуры необходимо создавать отдельную сущность для агрегаций отношений между начальников и подчинённым. 

Для UI на каждую сущность создано
 «NameClass»View для отображения списка Расчетов/Сотрудников и прочие. 
 «NameClass»EditFormView для добавления/изменения сущности

Для расчета ЗП создана иерархия обработчиков для каждого типа сущности, расчет идет по цепочки ответственности: если не нашлось класса обработки вызывается предупреждения пользователю. Возможно данную проблему решить методом стратегий объединив выбор метода расчета возможен через тип.
Параметры расчетов (размеры доплат) сосредоточены в классе ParametersCalculationSource, для единого управления и будущего переноса хранения параметров расчетов ЗП во внешнем хранилище
Алгоритмы расчетов в классе соответствующему объему модели
Разработаны тесты для классов расчетов

Недочеты текущие модели:
 - нет разграничения доступ по правам
 - ViewCollection для Employee/Manager/Salesman не отлавливается события добавления объекта (события обновления/удаления отрабатывает), при этом в SalaryViewCollection все работает.
 - нет автоматической обновления базы данных из-за проблем связки EF и SQLite (добавлен строений проект SQLite.CodeFirst, позволяет получить sql – строку создания базы данных, необходим обработчик по перегенераций БД)
 - Возможно для удобства работы необходимо дописать подбор сотрудников, а не только назначения руководителя
 - EmployeeCollectionViewModel.cs при отборе данных обладает излишними представления о иерархии (из-за иерархий объектов и текущей реализаций паттерна Unit Of Work, нет ограничения на Oftype при выборке данных, не обходимо отдельная реализация repository) 

# Технологии
Методика работы UI MVVM и DevExpress Robbon Control
Методика работы с SQLite Unit Of Work и entity framework 6
Расчет ЗП через цепочку ответственности
Тестирование через Unit Testing Framework и Moq

# Приложение создано на основе

https://documentation.devexpress.com/#WindowsForms/CustomDocument114101
http://www.devexpress.com/example=T254492

# Автор

Павел Карасов
pavel@karasov.net
