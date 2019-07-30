//------------------------------------------------------------------------------
// <copyright file="WebDataService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Data.Services;
using System.Data.Services.Common;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;

public class NorthWindDataService : DataService< NorthwindEntities >
{
    // This method is called only once to initialize service-wide policies.
    public static void InitializeService(DataServiceConfiguration config)
    {
        config.SetEntitySetAccessRule("Products", EntitySetRights.AllRead);
        config.SetEntitySetAccessRule("Categories", EntitySetRights.AllRead);
        config.SetEntitySetAccessRule("Suppliers", EntitySetRights.AllRead);


    }
}
