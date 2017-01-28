﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

namespace OdeToCode.AddFeatureFolders
{
    public class FeatureViewLocationExpander : IViewLocationExpander
    {
        private readonly string _placeholder;

        public FeatureViewLocationExpander(FeatureFolderOptions options)
        {
            _placeholder = options.FeatureNamePlaceholder;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (viewLocations == null)
            {
                throw new ArgumentNullException(nameof(viewLocations));
            }

            var controllerDescriptor = context.ActionContext.ActionDescriptor as ControllerActionDescriptor;
            var featureName = controllerDescriptor?.Properties["feature"] as string;

            foreach (var location in viewLocations)
            {
                yield return location.Replace(_placeholder, featureName);
            }
        }
    }
}
