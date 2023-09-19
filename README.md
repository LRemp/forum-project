# forum-project
T120B165 Saityno taikomųjų programų projektavimas modulio projektas

# Sprendžiamo uždavinio aprašymas

Projekto tikslas – sukurti platformą leidžiančią vartotojams laisvai bendrauti, kurti pokalbius pagal aktualias temas.

Veikimo principas – projekto programą sudaro dvi dalys: kliento pusė ir serverio pusė.

Vartotojas norėdamas dalyvauti pokalbiuose pasirenka atitinkamą kategoriją. Kategorijoje gali prisijungti prie pokalbio(angl. Thread) arba sukurti naują. Administratorius gali kurti naujas kategorijas, šalinti ir blokuoti vartotojus.

## Funkciniai reikalavimai
### Neregistruotas naudotojas
1.      Peržiūrėti platformos reprezentacinį puslapį;
2.      Peržiūrėti prisijungimo puslapį;
3.      Peržiūrėti registracijos puslapį;
4.  	Užsiregistruoti į sistemą;
5.      Prisijungti prie sistemos;
6.      Peržiūrėti kategorijas;
7.      Peržiūrėti pokalbius;
8.      Peržiūrėti pokalbių žinutes;'

### Registruotas sistemos naudotojas
1.      Atsijungti interetinės aplikacijos;
2.      Peržiūrėti kategorijas;
3.      Kurti, ištrinti, redaguoti pokalbius;
4.      Kurti, ištrinti, redaguoti žinutes;
5.      Redaguoti savo profilį;

### Administratorius
1.      Kurti, ištrinti, redaguoti kategorijas;
2.      Blokuoti vartotojus;
3.      Šalinti vartotojus;

# Sistemos architektūra

## Sistemos sudedamosios dalys:

-   Kliento pusė, vartotojo sąsaja (ang. Front-End) – naudojant React.js, Float UI;
-   Serverio pusė, API, JWT (angl. Back-End) – naudojant ASP.NET, Dapper, MySQL duomenų bazę.