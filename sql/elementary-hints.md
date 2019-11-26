# Реляционные базы данных и SQL

## Подсказки для практических заданий

### Элементарный уровень

#### Задание 1

Ожидаемый результат:

| CustomerID  | CompanyName         |
| ----------- | ------------------- |
| ALFKI       | Alfreds Futterkiste |
| ...         | ...                 |
| WOLZA       | Wolski Zajazd       |

Используйте [ORDER BY](https://docs.microsoft.com/en-us/sql/t-sql/queries/select-order-by-clause-transact-sql).


#### Задание 2

Ожидаемый результат: 9.

Используйте [TOP](https://docs.microsoft.com/en-us/sql/t-sql/queries/top-transact-sql) и ORDER BY.


#### Задание 3

Ожидаемый результат:

| Country   |
| --------- |
| Argentina |
| Austria   |
| Belgium   |
| ...       |

Используйте [DISTINCT](https://docs.microsoft.com/en-us/sql/t-sql/queries/select-clause-transact-sql).


#### Задание 4

Ожидаемый результат:

| CompanyName          |
| -------------------- |
| Spécialités du monde |
| Seven Seas Imports   |
| Romero y tomillo     |
| ...                  |
| Alfreds Futterkiste  |

Используйте [WHERE IN](https://docs.microsoft.com/en-us/sql/t-sql/queries/where-transact-sql) и ORDER BY.


#### Задание 5

Ожидаемый результат:

| CustomerID |
| ---------- |
| BERGS      |
| BSBEV      |
| COMMI      |

Используйте WHERE BETWEEN и ORDER BY.


#### Задание 6

Ожидаемый результат: Thomas Hardy.

Используйте WHERE LIKE.


#### Задание 7

Ожидаемый результат:

| City      | CustomerCount |
| --------- | ------------- |
| Århus     | 1             |
| Bräcke    | 1             |
| Kobenhavn | 1             |
| Luleå     | 1             |
| Stavern   | 1             |

Используйте WHERE IN, [GROUP BY](https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql), ORDER BY и count().


#### Задание 8

Ожидаемый результат:

| Country  | CustomerCount |
| -------- | ------------- |
| USA      | 13            |
| France   | 11            |
| Germany  | 11            |

Используйте: [HAVING](https://docs.microsoft.com/en-us/sql/t-sql/queries/select-having-transact-sql), GROUP BY, ORDER BY, count().


#### Задание 9

Ожидаемый результат:

| CustomerID | FreightAvg |
| ---------- | ---------- |
| MEREP      | 107.0000   |
| EASTC      | 104.0000   |
| SEVES      | 102.0000   |
| LAUGB      | 3.0000     |

Используйте: WHERE IN, GROUP BY, HAVING, ORDER BY, avg() и round().


#### Задание 10

Ожидаемый результат: 8.

Используйте TOP, ORDER BY, WHERE NOT IN и [subqueries](https://docs.microsoft.com/en-us/sql/relational-databases/performance/subqueries).


#### Задание 11

Ожидаемый результат: 8.

Используйте OFFSET и FETCH.


#### Задание 12

Ожидаемый результат:

| CustomerID | FreightSum |
| ---------- | ---------- |
| HILAA      | 81.9100    |
| ERNSH      | 286.5700   |

Используйте WHERE BETWEEN, GROUP BY, ORDER BY, sum(), avg() и subqueries.


#### Задание 13

Ожидаемый результат:

| CustomerID | ShipCountry | OrderPrice |
| ---------- | ----------- | ---------- |
| HANAR      | Brazil      | 15810      |
| GOURL      | Brazil      | 3424       |
| HANAR      | Brazil      | 3127.5     |

Используйте TOP, WHERE/WHERE IN, ORDER BY и [correlated subqueries](https://docs.microsoft.com/en-us/sql/relational-databases/performance/subqueries).


#### Задание 14

Нет подсказок.


#### Задание 15

Ожидаемый результат:

| Customer           | Employee        |
| ------------------ | --------------- |
| Around the Horn    | Michael Suyama  |
| Seven Seas Imports | Steven Buchanan |

Используйте INNER JOIN, concat().


#### Задание 16

Ожидаемый результат:

| ProductName           | UnitsInStock | ContactName    | Phone        |
| --------------------- | ------------ | -------------- | ------------ |
| Rogede sild           | 5            | Niels Petersen | 43844108     |
| Nord-Ost Matjeshering | 10           | Sven Petersen  | (04721) 8713 |
| ...                   | ...          | ...            | ...          |
| Ipoh Coffee           | 17           | Chandra Leka   | 555-8787     |

Используйте INNER JOIN.
