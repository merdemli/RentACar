
using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{        
                                         //T için generic constraint kısıtı getirme
                                         //class : referans tip olabilir, int vs yazılamaz,newlenebilir olmalı
                                         //IEntity: sadece IEntity(ortak özellik) tipinde yazılabilir,ya da onu implemente eden bir nesne olabilir
                                         //new: IEntity olmaması için new'leniyor olması,soyut olmamalı
    public interface IEntityRepository<T> where T: class,IEntity,new()  
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);  //Expression manager da ...'ya göre listele gibi filre vermeyi sağlar
                                               //filtre vermeyebilirsin //default'u null
        T Get(Expression<Func<T, bool>> filter); //tek datanın detayına gitmek için, filtre zorunludur 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
         
    }
}


//ortak katmandır bizim veritabanımızla alakası yoktur //repository pattern //crud operation 