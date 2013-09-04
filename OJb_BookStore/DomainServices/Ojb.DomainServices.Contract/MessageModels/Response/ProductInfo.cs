// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The product info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Runtime.Serialization;
using Ojb.Framework.ServiceBase.MessageModels;

namespace Ojb.DomainServices.Contract.MessageModels.Response
{
    /// <summary>
    /// The product info.
    /// </summary>
    [DataContract]
    public class ProductInfo : ResponseBase
    {
        /// <summary>
        /// The category.
        /// </summary>
        [DataMember] 
        public CategoryInfo Category;

        /// <summary>
        /// The description.
        /// </summary>
        [DataMember] 
        public string Description;

        /// <summary>
        /// The id.
        /// </summary>
        [DataMember] 
        public int Id;

        /// <summary>
        /// The image path.
        /// </summary>
        [DataMember] 
        public string ImagePath;

        /// <summary>
        /// The unit price.
        /// </summary>
        [DataMember] 
        public decimal UnitPrice;
    }
}