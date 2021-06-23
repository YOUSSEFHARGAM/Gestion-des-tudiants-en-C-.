using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RecruteurDAO
    {
        #region Singleton


        private static readonly object myLock = new object();
        private static RecruteurDAO instance = null;
        private RecruteurDAO()
        {

        }
        public static RecruteurDAO getInstance()
        {
            lock (myLock)
            {
                if (instance == null) instance = new RecruteurDAO();
                return instance;
            }
        }
        #endregion
        #region CRUD
        public void ADDRecruteur(Recruteur r)
        {
            using (ProjetEntities P = new ProjetEntities())
            {

                P.Recruteur.AddObject(r);
                P.SaveChanges();
            }
        }
        public List<Recruteur> listeRecruteur()
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                return ce.Recruteur.ToList<Recruteur>();
            }
        }
        public void DeleteRecruteur(Recruteur re)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {

                var req = ce.Recruteur.Where(etu => etu.CIN == re.CIN).First();
                ce.Recruteur.DeleteObject(req);
                ce.SaveChanges();
            }
        }
        public void UpdateRecruteur(Recruteur newConv)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                var req = (from p in ce.Recruteur
                           where p.CIN == newConv.CIN
                           select p).FirstOrDefault();
                //req.Date_deb = newConv.Date_deb;
                //req.Date_fin = newConv.Date_fin;
                //req.Periodicite = newConv.Periodicite;
                //req.Code_regroup = newConv.Code_regroup;
                //req.Type_convention = newConv.Type_convention;
                //req.branche = newConv.branche;


                ce.SaveChanges();
            }
        }



        public Recruteur getRecruteurByID(int CIN)
        {



            using (ProjetEntities ce = new ProjetEntities())
            {

                return ce.Recruteur.Where(e => e.CIN == CIN).SingleOrDefault();
            }
        }


        #endregion

    }
}
