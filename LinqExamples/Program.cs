﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Reflection;
//using System.Data.Entity;
//using System.Data.Entity.SqlServer;

//namespace LinqExamples
//{
//    class Program
//    {
        
//        static void Main(string[] args)
//        {
//            try
//            {
//                PADBEntities Db = new PADBEntities();

//                //Db.Database.Log = Console.WriteLine;

//                // Simple LINQ Query
//                Console.WriteLine("Example 1");
//                var emp = (from e in Db.HRISMSTEmployees
//                               //where e.txtcompany == "EVERVE"
//                           orderby e.txtempname
//                           select e).ToList();
//                foreach (var item in emp)
//                {
//                    Console.WriteLine("Company Name " + item.txtcompany + " EmpName :" + item.txtempname);
//                }


//                ///Using Join 
//                #region "Using Join"
//                //single column join
//                Console.WriteLine("Example 2");
//                var res = from e in Db.Albums
//                          join a in Db.Artists on e.ArtistId equals a.ArtistId
//                          select new
//                          {
//                              AlbumName = e.Title,
//                              AlbumArtist = a.Name
//                          };//).OrderBy(x => x.AlbumArtist).ThenBy(y => y.AlbumName).ToList();

//                foreach (var item in res)
//                    Console.WriteLine(" Artist : " + item.AlbumArtist + " \tAlbum : " + item.AlbumName);

//                //Group join
//                Console.WriteLine("Example 3");
//                var hell = from e in Db.Artists
//                           join a in Db.Albums
//                           on  e.ArtistId equals a.ArtistId
//                           into q
//                           select new { Artist = e.Name, AlbumList = q };

//                //foreach (var ch in hell)
//                //{
//                //    Console.WriteLine("Artist : " + ch.Artist);
//                //    foreach (var dd in ch.AlbumList)
//                //        Console.Write(" \n \t Albums : " + dd.Title);
//                //}
//                foreach (var ch in hell)
//                {
//                    try
//                    {
//                        Console.WriteLine("Artist : " + ch.Artist);
//                        Console.WriteLine(" \t Albums : " + ch.AlbumList.FirstOrDefault().Title);
//                    }
//                    catch (Exception)
//                    { }
//                }


//                #endregion

//                ///Using Group By Clause
//                #region "Group By Clause"
//                Console.WriteLine("Example 4");
//                var emp2 = (from e in Db.HRISMSTEmployees
//                           group e by e.txtcompany into g
//                           select g).ToList();
//                foreach (var item in emp2)
//                {
//                    foreach (var empl in item)
//                    {
//                        Console.WriteLine("Company Name " + item.Key + " EmpName :" + empl.txtempname);
//                    }
//                    //Console.WriteLine("Company Name " + item.Key + " EmpName :" + item.FirstOrDefault().txtempname);

//                    //Using count with group by clause
//                    Console.WriteLine("Company Name " + item.Key + " Emp Count :" + item.Count());
//                }
//                #endregion

//                Console.WriteLine("Example 5");                
//                ///Using Dynamic filters
//                //Dynfilter("GenreId", "10");
//                //Console.WriteLine();
//                //Dynfilter("ArtistId", "248");


//                ///Using SubQuery


//                ///DbFunctions - Generic for all Dbs                
//                var artists = from a in Db.Artists
//                              where DbFunctions.Reverse(a.Name).Count() > 10
//                              select a;

//                ///SqlFunctions
//                var albums = from a in Db.Albums
//                             where SqlFunctions.IsDate(a.AlbumArtUrl) == 1
//                             select a;

//                ///Concept of Iqueryable
//                var artistwitha = from a in Db.Artists
//                                  select a;

//                var aresult = GetNameswithA(artistwitha);

//                Console.ReadKey();
//            }
//            catch (Exception)
//            {
                
//                //throw;
//            }
            
//        }

//        static IQueryable<Artist> GetNameswithA(IQueryable<Artist> res)
//        {
//            return res.Where(a => a.Name.StartsWith("A", false, null));
//        }

//        static void Dynfilter(string Col, string val)
//        {
//            PADBEntities Db = new PADBEntities();
//            var valbum = (from a in Db.Albums select a).ToArray();

//            PropertyInfo prp = valbum[0].GetType().GetProperty(Col);

//            var result = valbum.Where(x => prp.GetValue(x, null).ToString() == val);

//            foreach (var r in result)
//            {
//                Console.WriteLine(" Name " + r.Title + " GenreId :" + r.GenreId + " ArtistId : " + r.ArtistId);
//            }

//        }
//    }
//}
