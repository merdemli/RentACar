using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    { 
        //voi^d'ler için
        bool Success { get; } //örn ekleme işi başarılı mı?
        string Message { get; } //ürün eklendi
    }
};
