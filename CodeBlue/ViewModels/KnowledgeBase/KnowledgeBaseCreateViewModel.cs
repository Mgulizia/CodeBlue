using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.ViewModels.KnowledgeBase
{
    public class KnowledgeBaseCreateViewModel
    {
        public Models.KnowledgeBase KnowledgeBase { get; set; }
        public List<KnowledgeBaseCatagory> KnowledgeBaseCatagories { get; set; }
    }
}