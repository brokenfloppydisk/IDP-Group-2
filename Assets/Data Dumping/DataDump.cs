using System.Collections;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;
using static Google.Apis.Sheets.v4.SheetsService;
using System.Text;

public class DataDump : MonoBehaviour
{
    void Start() {
        Debug.Log("DataDump Script Started");
        using (var stream = new FileStream("keys.json", FileMode.Open, FileAccess.Read)){
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }

        service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer(){
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });
    }
    void Update() {

    }
    public static string[] Scopes = {Scope.Spreadsheets}; 
    public static string ApplicationName = "EscapeRoom";
    public static string SpreadsheetID = "10PPl7Go9VPR4k-bqHTQyRaaJ0LvP4SuUu13N8Ds7g7k";
    public static string sheet = "Sheet1";
    public static SheetsService service;
    private GoogleCredential credential;

    /// <summary>
    /// This method reads and returns entries from the spreadsheet as a 2D IList.
    /// </summary>
    public IList<IList<object>> ReadEntries(string rangeLow, string rangeHigh){
        var range = $"{sheet}!{rangeLow}:{rangeHigh}";
        var request = service.Spreadsheets.Values.Get(SpreadsheetID, range);
        var response = request.Execute();
        var values = response.Values;
        return values;
    }
    /// <summary>
    /// This method creates entries on the spreadsheet.
    /// </summary>
    public void CreateEntry(string leftColumn, string rightColumn, List<object> inputs) {
        var range = $"{sheet}!{leftColumn}:{rightColumn}";
        var valueRange = new ValueRange();
        // var objectList = new List<object>() {"Test", "Test2", "Test3"};
        valueRange.Values = new List<IList<object>> {inputs} ;
        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetID, range);
        appendRequest.ValueInputOption = Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
    }
    /// <summary>
    /// This method changes entries on the spreadsheet.
    /// </summary>
    public void UpdateEntry(string cell, List<object> inputs) {
        var range = $"{sheet}!{cell}";
        var valueRange = new ValueRange();
        valueRange.Values = new List<IList<object>> {inputs};
        var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetID, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var updateResponse = updateRequest.Execute();

    }
    /// <summary>
    /// This method deletes entries from the spreadsheet.
    /// </summary>
    public void DeleteEntry(string leftBound, string rightBound) {
        var range = $"{sheet}!{leftBound}:{rightBound}";
        var requestBody = new ClearValuesRequest();
        var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetID, range);
        var deleteResponse = deleteRequest.Execute();
    }
}
