using System.Collections;
using System.Collections.Generic;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UnityEngine;
using static Google.Apis.Sheets.v4.SheetsService;

public static class DataDump
{
    public static bool initialized = false;
    public static string[] Scopes = { Scope.Spreadsheets };
    public static string ApplicationName = "EscapeRoom";
    public static string SpreadsheetID = "10PPl7Go9VPR4k-bqHTQyRaaJ0LvP4SuUu13N8Ds7g7k";
    public static string[] sheets = new string[] { "TimesAndHints", "UserFeedback" };
    public static SheetsService service;
    private static GoogleCredential credential;
    public static void Initialize() {
        if (!initialized) {
            string credentialString = Resources.Load("DataDump/keys",typeof(TextAsset)).ToString();
            credential = GoogleCredential.FromJson(credentialString).CreateScoped(Scopes);
            service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
            initialized = true;
        }
    }

    /// <summary>
    /// This method reads and returns entries from the spreadsheet as a 2D IList.
    /// </summary>
    public static IList<IList<object>> ReadEntries(string rangeLow, string rangeHigh, int index){
        var range = $"{sheets[index]}!{rangeLow}:{rangeHigh}";
        var request = service.Spreadsheets.Values.Get(SpreadsheetID, range);
        var response = request.Execute();
        var values = response.Values;
        return values;
    }
    /// <summary>
    /// This method creates entries on the spreadsheet (will not overwrite entries).
    /// </summary>
    public static void CreateEntry(string leftColumn, string rightColumn, List<object> inputs, int index) {
        var sheet = sheets[index];
        var range = $"{sheet}!{leftColumn}:{rightColumn}";
        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
        valueRange.Values = new List<IList<object>> {inputs} ;
        var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetID, range);
        appendRequest.ValueInputOption = Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        var appendResponse = appendRequest.Execute();
    }
    /// <summary>
    /// This method changes entries on the spreadsheet. (untested)
    /// </summary>
    public static void UpdateEntry(string cell, List<object> inputs, int index) {
        var range = $"{sheets[index]}!{cell}";
        var valueRange = new Google.Apis.Sheets.v4.Data.ValueRange();
        valueRange.Values = new List<IList<object>> {inputs};
        var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetID, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var updateResponse = updateRequest.Execute();

    }
    /// <summary>
    /// This method deletes entries from the spreadsheet. (untested)
    /// </summary>
    public static void DeleteEntry(string leftBound, string rightBound, int index) {
        var range = $"{sheets[index]}!{leftBound}:{rightBound}";
        var requestBody = new ClearValuesRequest();
        var deleteRequest = service.Spreadsheets.Values.Clear(requestBody, SpreadsheetID, range);
        var deleteResponse = deleteRequest.Execute();
    }
}
