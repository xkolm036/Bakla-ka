
SELECT MAX(pocet) as maxpocet  FROM (select count(*) as pocet ,KOD_ODEL from zamest
group by KOD_ODEL);


select nazev from odel join (SELECT pocet as maxpocet, kod_odel from (
select count(*) as pocet ,KOD_ODEL from zamest
group by KOD_ODEL
) 
where ROWNUM = 1
order by maxpocet desc)nejodel
on nejodel.kod_odel = odel.KOD_ODDEL;


SELECT kod_odel from (
select count(CISLO_ZAM) as pocet ,KOD_ODEL from zamest
group by KOD_ODEL
) 
where pocet = (select max(pocet) from (select count(CISLO_ZAM) as pocet from zamest
group by KOD_ODEL));
