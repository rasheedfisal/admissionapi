using Microsoft.AspNetCore.Mvc;
using BoldReports.Web.ReportViewer;
using admissionapi.api.Dtos.Responses;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace admissionapi.api.Controllers;

[Route("api/{controller}/{action}/{id?}")]
[Microsoft.AspNetCore.Cors.EnableCors("AllowAllOrigins")]
public class AdmissionViewerController : ControllerBase, IReportController
{
      // Report viewer requires a memory cache to store the information of consecutive client request and
        // have the rendered Report Viewer information in server.
        private readonly IMemoryCache _cache;

        // IHostingEnvironment used with sample to get the application data from wwwroot.
        private readonly IWebHostEnvironment _hostingEnvironment;

          // Post action to process the report from server based json parameters and send the result back to the client.
        public AdmissionViewerController(IMemoryCache memoryCache,
            IWebHostEnvironment hostingEnvironment)
        {
            _cache = memoryCache;
            _hostingEnvironment = hostingEnvironment;
        }

    [ActionName("GetResource")]
    [AcceptVerbs("GET")]
    public object GetResource(ReportResource resource)
    {
        return ReportHelper.GetResource(resource, this, _cache);
    }
    [NonAction]
    public void OnInitReportOptions(ReportViewerOptions reportOption)
    {
        // string basePath = _hostingEnvironment.WebRootPath;
        var folderName = Path.Combine("Resources", "Reports");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            // reportOption.ReportModel.ProcessingMode = ProcessingMode.Local;
        FileStream inputStream = new FileStream(pathToSave + "/" + reportOption.ReportModel.ReportPath, FileMode.Open, FileAccess.Read);
        // FileStream inputStream = new FileStream(folderName + @"\Resources\Reports\school.rdl", FileMode.Open, FileAccess.Read);
        MemoryStream reportStream = new MemoryStream();
        inputStream.CopyTo(reportStream);
        reportStream.Position = 0;
        inputStream.Close();
        reportOption.ReportModel.Stream = reportStream;
        // reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "testset", Value = new{firstname = "ahmed", secondname = "ali"} });
    }
    [NonAction]
    public void OnReportLoaded(ReportViewerOptions reportOption)
    {
    //     List<BoldReports.Web.ReportParameter> userParameters = new List<BoldReports.Web.ReportParameter>();
    // userParameters.Add(new BoldReports.Web.ReportParameter()
    // {
    //     Name = "ReportParameter1",
    //     Values = new List<string>() { "+20988776655" }
    // });
    // reportOption.ReportModel.Parameters = userParameters;
    //     var reportParameters = ReportHelper.GetParameters(jsonArray, this);
    //   var paramList = JObject.Parse(parameterJsonData);

    //   List<BoldReports.Web.ReportParameter> setParameters = new List<BoldReports.Web.ReportParameter>();
    //   if (reportParameters != null)
    //   {
    //     foreach (var rptParameter in reportParameters)
    //     {
    //       var paramValue = paramList[rptParameter.Name].ToString();

    //       setParameters.Add(new BoldReports.Web.ReportParameter()
    //       {
    //         Name = rptParameter.Name,
    //         Values = new List<string>() { paramValue }
    //       });
    //     }
    //     reportOption.ReportModel.Parameters = setParameters;
    //   }
    }
    // [ActionName("PostFormReportAction")]
    [HttpPost]
    public object PostFormReportAction()
    {
        return ReportHelper.ProcessReport(null, this, _cache);
    }
    // [ActionName("PostReportAction")]
    [HttpPost]
    public object PostReportAction([FromBody]Dictionary<string, object> jsonResult)
    {
        return ReportHelper.ProcessReport(jsonResult, this, _cache);
    }
}