using Core.Entities;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{                                           
    //çalışılan tablo ve context verilir
    public class EFEntityRepositoryBase <TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity: class, IEntity,new()                    //referans tip, veritabanı tablosu ve new'lenebiliyor olma şartı
        where TContext: DbContext,new()                        //DbContext'ten inherit edilmş olmalı ve new'lenebiliyor olmalı
    {
        public void Add(TEntity entity)
        {
            //using : IDispossable pattern implementation of C#
            using (TContext context = new TContext())  //using içine yazılan nesneler, using bitince garbage collector tarafından belleken atılır
            {
                var addedEntity = context.Entry(entity); //gönderilen nesne veri kaynağı ile ilişkilendirilir yani referansı yakalanır
                addedEntity.State = EntityState.Added;    //yeni eklenecek nesne olarak set edilir  ; State nesnenin Added oldugunu gösterir
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) //filter null olamaz
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //default'u null
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() // tüm liste gelir select* from Cars
                    : context.Set<TEntity>().Where(filter).ToList(); //filtre varsa, filtreye göre filtrele ve getir listele
            }                                 //lambda                   //select*from Cars where filter..
        }

        public void Update(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
