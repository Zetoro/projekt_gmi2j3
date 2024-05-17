using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Biljettshoppen.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biljettshoppen.Events
{
    public class Ocassion : iOcassion
    {


        private PremiseFactory premiseFactory;
        private Premise premise;
        private string _ocassionName;
        private string _ocassionPerformer;
        private DateTime _ocassionDate;
        private string _ocassionType;

        public Ocassion(string ocassionName, string ocassionPerformer, string ocassionType, string ocassionDateString, string typeOfPremise)
        {
            this.PremiseFactory = new PremiseFactory();
            premiseSet = premiseFactory.TypeOfPremise(typeOfPremise);
            if (!DateTime.TryParse(ocassionDateString, out DateTime ocassionDate) || ocassionDate < DateTime.Today)
            {
                throw new InvalidDataException("Invalid date format.");
            }
            /*
            if (ocassionDate < DateTime.Today)
            {
                throw new InvalidDataException("Invalid date.");
            }*/
            for (int i = 0; i < ActiveOcassions.Ocassions.Count; i++)
            {
                if (ActiveOcassions.Ocassions[i].OcassionDate == ocassionDate &&
                    ActiveOcassions.Ocassions[i].premiseSet.GetLocation() == premiseSet.GetLocation())
                {
                    throw new InvalidDataException("An occasion with the same name, date, and premise already exists.");
                }
            }
            OcassionName = ocassionName;
            OcassionPerformer = ocassionPerformer;
            OcassionType = ocassionType;
            OcassionDate = ocassionDate;


            ActiveOcassions.AddOcassion(this);

        }
        public string OcassionName
        {
            get { return _ocassionName; }
            set { _ocassionName = value; }
        }
        public string OcassionPerformer
        {
            get { return _ocassionPerformer; }
            set { _ocassionPerformer = value; }
        }
        public DateTime OcassionDate
        {
            get { return _ocassionDate; }
            set { _ocassionDate = value; }
        }
        public Premise premiseSet
        {
            get { return premise; }
            set { premise = value; }
        }
        public PremiseFactory PremiseFactory
        {
            get { return premiseFactory; }
            set { premiseFactory = value; }
        }
        public string OcassionType
        {
            get { return _ocassionType; }
            set { _ocassionType = value; }
        }

    }
}
