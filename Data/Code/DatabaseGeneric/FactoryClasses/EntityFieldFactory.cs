﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.10.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using FavMovies.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace FavMovies.FactoryClasses
{
	/// <summary>Factory class for IEntityField2 instances, used in IEntityFields2 instances. For backwards compatibility</summary>
	public static partial class EntityFieldFactory
	{
		/// <summary>Creates a new IEntityField2 instance for usage in the EntityFields object for the entity related to the field index specified.</summary>
		/// <param name="fieldIndex">The field which IEntityField2 instance should be created</param>
		/// <returns>The IEntityField2 instance for the field specified in fieldIndex</returns>
		public static IEntityField2 Create(Enum fieldIndex)	{ return new EntityField2(ModelInfoProviderSingleton.GetInstance().GetFieldInfo(fieldIndex)); }

		/// <summary>Creates a new IEntityField2 instance, which represents the field objectName.fieldName</summary>
		/// <param name="objectName">the name of the object the field belongs to, like CustomerEntity or OrdersTypedView</param>
		/// <param name="fieldName">the name of the field to create</param>
		public static IEntityField2 Create(string objectName, string fieldName) { return new EntityField2(ModelInfoProviderSingleton.GetInstance().GetFieldInfo(objectName, fieldName)); }

	}
}