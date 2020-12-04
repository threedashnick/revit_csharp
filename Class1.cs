using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
namespace Lab1PlaceGroup
{
    
    
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    
    // IExternalApplication - отдельное поле на панели. Использование подраумевает наличие внутри ONstartup и onshutdown  https://www.revitapidocs.com/2015/196c8712-71de-03e8-b30d-a9625bd626d2.htm   
    // IExternalCommand - новая строка в выпадающем меню Надстройки - Внешние инструменты
    
   
    public class Class1 : IExternalApplication
    {
    
    
        
        
        public Result OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        
        
        
                public Result OnShutdown(UIControlledApplication application)
        {
            string
            return Result.Succeeded;
        }
        
        
        
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and documnet objects
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            //Define a reference Object to accept the pick result
            Reference pickedref = null;

            //Pick a group
            Selection sel = uiapp.ActiveUIDocument.Selection;
            pickedref = sel.PickObject(ObjectType.Element, "Please select a group");
            Element elem = doc.GetElement(pickedref);
            Group group = elem as Group;

            //Pick point
            XYZ point = sel.PickPoint("Please pick a point to place group");

            //Place the group
            Transaction trans = new Transaction(doc);
            trans.Start("Lab");
            doc.Create.PlaceGroup(point, group.GroupType);
            trans.Commit();

            return Result.Succeeded;
        }
    }
}
