using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class candidatDAO
    {
        #region Singleton


        private static readonly object myLock = new object();
        private static candidatDAO instance = null;
        private candidatDAO()
        {

        }
        public static candidatDAO getInstance()
        {
            lock (myLock)
            {
                if (instance == null) instance = new candidatDAO();
                return instance;
            }
        }
        #endregion
        #region CRUD
        public void ADDCandidat(Condidat c)
        {
            using (ProjetEntities P = new ProjetEntities())
            {

                P.Condidat.AddObject(c);
                P.SaveChanges();
            }
        }
        public List<Condidat> listecandidat()
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                return ce.Condidat.ToList<Condidat>();
            }
        }
        public void Deleteconditat(Condidat c)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {

                var req = ce.Condidat.Where(etu => etu.CIN == c.CIN).First();
                ce.Condidat.DeleteObject(req);
                ce.SaveChanges();
            }
        }
        public void UpdateCondidat(Condidat newConv)
        {
            using (ProjetEntities ce = new ProjetEntities())
            {
                var req = (from p in ce.Condidat
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



        public Condidat getcandidatByID(int CIN)
        {



            using (ProjetEntities ce = new ProjetEntities())
            {

                return ce.Condidat.Where(e => e.CIN == CIN).SingleOrDefault();
            }
        }


        #endregion

    }
}
