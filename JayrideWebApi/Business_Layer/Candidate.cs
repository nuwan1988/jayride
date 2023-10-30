using System;
using System.Collections.Generic;
using System.Text;
using DataAccess_Layer.Models;

namespace Business_Layer
{
    public class Candidate
    {
        public CandidateClass GetCandidate() 
        {
            var candidate = new CandidateClass
            {
                Name = "test",
                Phone = "test"
            };
            return candidate;
        }
    }
}
