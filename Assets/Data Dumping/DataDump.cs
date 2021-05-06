using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class DataDump : MonoBehaviour
{
    static readonly string[] Scopes = {SheetsService.Scope.Spreadsheets};
    static readonly string ApplicationName = "EscapeRoom";
    static readonly string SpreadsheetID = "10PPl7Go9VPR4k-bqHTQyRaaJ0LvP4SuUu13N8Ds7g7k";
    static readonly string sheet = "Sheet1";
    static SheetsService service;

    void DataDumping() {
        GoogleCredential credential;
        using (var stream = new FileStream("keys.json", FileMode.Open, FileAccess.Read)){
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }

        service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer(){
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });

        ReadEntries();
    }
    void ReadEntries() {
        var range = $"{sheet}!A1:Z25";
        var request = service.Spreadsheets.Values.Get(SpreadsheetID, range);
        var response = request.Execute();
        var values = response.Values;
        if (values != null && values.Count > 0) {
            foreach (var row in values) {
                Debug.Log(System.String.Format("Values extracted: {0}, {1}, {2}",row[0],row[1],row[3]));
            }

        }
    }
}
