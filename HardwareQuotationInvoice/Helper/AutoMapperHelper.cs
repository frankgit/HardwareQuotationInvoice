using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Collections;

namespace HardwareQuotationInvoice.Helper
{
    public static class AutoMapperHelper
    {

        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            Mapper.Initialize(x => x.CreateMap(obj.GetType(), typeof(T)));
            return Mapper.Map<T>(obj);
        }

        public static TDest MapTo<TSource, TDest>(this TSource source, TDest tdest)
            where TSource:class
            where TDest:class
        {
            if (source == null) return tdest;
            Mapper.Initialize(x => x.CreateMap<TSource, TDest>());
            return Mapper.Map(source, tdest);
        }


        public static IEnumerable<TDest> MapToList<TDest>(this IEnumerable source)
        {
            if (source == null) return null;
            foreach (var item in source)
            {
                Mapper.Initialize(x => x.CreateMap(item.GetType(), typeof(TDest)));
            }

            return Mapper.Map<IEnumerable<TDest>>(source);
        }

        public static IEnumerable<TDest> MapToList<Tsource, TDest>(this IEnumerable<Tsource> source)
        {
            if (source == null) return null;
            Mapper.Initialize(x => x.CreateMap<Tsource,TDest>());
            return Mapper.Map<IEnumerable<TDest>>(source);
        }
    }
}