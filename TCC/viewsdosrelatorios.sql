create view RELATORIODEVENDA
as
select i.ITSID 'Codigo de venda',
       s.SAIDATA 'Data da venda',
       pro.PRODESCRICAO 'Nome do produto',
        t.TIPNOME 'Tipo',
       i.ITSQUANTIDADE 'Quantidade vendida',
        i.ITSPRECO 'Preço unitário',
        i.ITSTOTAL 'Valor total'
        
FROM  ITENSSAIDA i
JOIN SAIDA s ON i.SAIID = s.SAIID
JOIN PROTIPO pt ON i.PTID = pt.PTID
JOIN PRODUTO pro ON pt.PROID = pro.PROID
JOIN TIPO t ON pt.TIPID = t.TIPID
go

create view RELATORIODEREPOSICAO
as
select ite.ITEID 'Codigo de reposição',
        ent.ENTDATA 'Data de reposição',
        pro.PRODESCRICAO 'Nome do produto',
        t.TIPNOME 'Tipo',
          ite.ITEQUANTIDADE 'Quantidade reposta',
        ite.ITEPRECO 'Preço unitário',
        ite.ITETOTAL 'Valor total'
      
        
FROM  ITENSENTRADA ite
JOIN ENTRADA ENT ON ite.ENTID = ent.ENTID
JOIN PROTIPO pt ON ite.PTID = pt.PTID
JOIN PRODUTO pro ON pt.PROID = pro.PROID
JOIN TIPO t ON pt.TIPID = t.TIPID