using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace MultyProjectPoc
{
    public class ProjectLoactionExpander : IViewLocationExpander
    {
        private readonly Project _project;

        public ProjectLoactionExpander(Project project)
        {
            _project = project;
        }
        
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var location in viewLocations)
            {
                yield return location.Replace("{0}", _project + "/{0}");
                yield return location;
            }

        }

        private IEnumerable<string> ExpandViewLocationsCore(IEnumerable<string> viewLocations, string value)
        {
            foreach (var location in viewLocations)
            {
                yield return location.Replace("{0}", value + "/{0}");
                yield return location;
            }
        }


        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }
    }
}