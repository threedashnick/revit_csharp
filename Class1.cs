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
    
    #region external application methods
    
    
    public class Class1 : IExternalApplication
    {

        #region external application methods
        
        public Result OnStartup(UIControlledApplication application)
        {

            string tabName = "tabaNama";
            application.CreateRibbonTab(tabName);
            string panelAnnotationName = "PanelaAnnotationaNama";
            application.CreateRibbonPanel(tabName, panelAnnotationName);
            // выше создали вкладку на ленте, а затем и панель на этой вкладке


            return Result.Succeeded;
        }



        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }


        #endregion 


    }
}
        
        
        
//        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
//        {
//            //Get application and documnet objects
//            UIApplication uiapp = commandData.Application;
//            Document doc = uiapp.ActiveUIDocument.Document;
//
//            //Define a reference Object to accept the pick result
//            Reference pickedref = null;
//
//            //Pick a group
//            Selection sel = uiapp.ActiveUIDocument.Selection;
//            pickedref = sel.PickObject(ObjectType.Element, "Please select a group");
//            Element elem = doc.GetElement(pickedref);
//            Group group = elem as Group;
//
//            //Pick point
//            XYZ point = sel.PickPoint("Please pick a point to place group");
//
//            //Place the group
//            Transaction trans = new Transaction(doc);
//            trans.Start("Lab");
//            doc.Create.PlaceGroup(point, group.GroupType);
//            trans.Commit();
//
//            return Result.Succeeded;
//        }
//    }
// }

/*

1. Visual Studio create new ClassLibrary(.NET Core) - Библиотека классов(.NET Core)
2. Check if Platform is relevant to you Revit version (for 2019 if .NET Framework 4.7.2)
3. Solutiom manager > links > add link "C:\Program Files\Autodesk\Revit 2019\RevitAPI.dll" and "C:\Program Files\Autodesk\Revit 2019\RevitAPIUI.dll"
4. Set local copy > false (see link propeties) for both just added links
5. Type code part ///
6. Create manifest file as this:
                            <?xml version="1.0" encoding="utf-8"?>
                            <RevitAddIns>
                             <AddIn Type="Command">
                                   <Name>Lab1PlaceGroup</Name>
                                   <FullClassName>Lab1PlaceGroup.Class1</FullClassName>
                                   <Text>Lab1PlaceGroup</Text>
                                   <Description>Places the Group at Particular Point</Description>
                                   <VisibilityMode>AlwaysVisible</VisibilityMode>
                                   <Assembly>C:\test\Lab1PlaceGroup\Lab1PlaceGroup\bin\Debug\Lab1placeGroup.dll</Assembly>
                                   <AddInId>502fe383-2648-4e98-adf8-5e6047f9dc34</AddInId>
                                <VendorId>ADSK</VendorId>
                                <VendorDescription>Autodesk, Inc, www.autodesk.com</VendorDescription>
                             </AddIn>
                            </RevitAddIns>
7. Save this text as an addin-file and put this manifest file in "C:\ProgramData\Autodesk\Revit\Addins\20xx\"

*/


