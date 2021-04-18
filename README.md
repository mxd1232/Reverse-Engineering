# Reverse-Engineering
Application creating an UML class diagram out of c# source code.















**********************TEORIA***************************#


*Diagram klas 
– statyczny diagram strukturalny w UML, przedstawiający strukturę systemu w modelach obiektowych przez ilustrację struktury klas i zależności między nimi.

Diagram klas pokazuje określony fragment struktury systemu. Diagramów klas używa się do modelowania statycznych aspektów perspektywy projektowej. Wiąże się z tym silnie modelowanie słownictwa systemu, kooperacji lub schematów. Diagramy klas pozwalają na sformalizowanie specyfikacji danych i metod. Mogą także pełnić rolę graficznego środka pokazującego szczegóły implementacji klas.

*Klasy
Klasa w modelu UML programu obiektowego jest reprezentowana przez prostokąt z umieszczoną wewnątrz nazwą klasy. Oddzielona część prostokąta pod nazwą klasy może zawierać atrybuty klasy, czyli metody, właściwości lub pola. Każdy atrybut pokazywany jest przynajmniej jako nazwa, opcjonalnie także z typem, wartością i innymi cechami.

Metody klasy mogą znajdować się w osobnej części prostokąta. Każda metoda jest pokazywana przynajmniej jako nazwa, a dodatkowo także ze swoimi parametrami i zwracanym typem.

*Atrybuty (zmienne i właściwości) oraz metody mogą mieć też oznaczoną widoczność (zakres znaczenia ich nazw) jak następuje:

"+" dla public – publiczny, dostęp globalny
"#" dla protected – chroniony, dostęp dla pochodnych klasy (wynikających z generalizacji)
"−" dla private – prywatny, dostępny tylko w obrębie klasy (przy atrybucie statycznym) lub obiektu (przy atrybucie zwykłym)
"~" dla package – pakiet, dostępny w obrębie danego pakietu, projektu.

*Związki (powiązania)

Oznaczenia związków klas w UML
Zależność
Zależność (ang. dependency) – najsłabszy związek znaczeniowy między klasami, gdy jedna z klas używa innej. Na diagramie klas oznaczana przerywaną linią zakończoną strzałką wskazującą kierunek zależności.

Asocjacja
Asocjacja (ang. association) wskazuje na silniejsze powiązanie pomiędzy obiektami danych klas (np. firma zatrudnia pracowników). Na diagramie asocjację oznacza się za pomocą linii, która może być zakończona strzałką z otwartym grotem (oznaczającą kierunek powiązania klas). Nazwy cech (np. zatrudniony, zatrudniający) wraz z krotnością umieszcza się w punkcie docelowym asocjacji. Nazwę asocjacji podaje się pośrodku (np. zatrudnia).

Generalizacja
Generalizacja lub dziedziczenie– związek opisujący klasy i podklasy (ogólne klasy i szczegółowe lub inaczej rodziców i dzieci). Na diagramie generalizację oznacza się za pomocą niewypełnionego trójkąta symbolizującego strzałkę (skierowaną od klasy pochodnej do klasy bazowej).

Agregacja
Agregacja reprezentuje związek typu całość-część, czyli jakaś większa całość jest rozbita na elementy. Oznacza to, że elementy częściowe mogą należeć do większej całości, jednak również mogą istnieć bez niej (np. koła i samochód). Na diagramie agregację oznacza się za pomocą linii zakończonej pustym rombem.

Kompozycja
Kompozycja, jest silniejszą formą agregacji. W związku kompozycji, części należą tylko do jednej całości, a ich okres życia jest wspólny — razem z całością niszczone są również części. W dużej mierze jest to kwestia umowna, zależna od danego systemu. Na diagramie, kompozycję oznacza się za pomocą linii zakończonej wypełnionym rombem.








#Refleksja
- służy to uzyskania informacji o typie w trakcie wykonywania programu. Klasy, które mają dostęp do metadanych działającego programu są zdefiniowane w przestrzeni nazw System.Reflection.
Przestrzeń ta zawiera klasy, które pozwalają na uzyskanie informacji o aplikacji oraz pozwalają na dynamiczne dodawanie typów, wartości i obiektów do aplikacji.
Możliwości refleksji:
podgląd atrybutów w trakcie wykonywania programu;
sprawdzenie różnych typów danych w danej bibliotece oraz utworzenie ich instancji;
wykonanie późnego wiązania do metod i właściwości (późne wiązanie oznacza, że np. docelowa metoda jest poszukiwana w trakcie wykonywania programu. Wiązanie takie ma zwykle wpływ na wydajność. Poszukiwanie takie wymaga dopasowania w trakcie wykonywania programu, oznacza to, że wywołania metod są wolniejsze. Przeciwieństwem jest wczesne wiązanie, tj. docelowa metoda jest znana już w trakcie kompilacji kodu);
tworzenie nowych typów w trakcie wykonywania programu a następnie wykonywanie różnych zadań przy użyciu tych typów.
