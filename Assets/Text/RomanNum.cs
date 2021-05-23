using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class RomanNum : MonoBehaviour
{
    public static Dictionary<int, string> RomanDict = new Dictionary<int, string> {
        { 1000, "M"},
        { 900, "CM"},
        { 500, "D"},
        { 400, "CD"},
        { 100, "C"},
        { 90, "XC"},
        { 50, "L"},
        { 40, "XL"},
        { 10, "X"},
        { 9, "IX"},
        { 5, "V"},
        { 4, "IV"},
        { 1, "I"}
    };
    public static string ToRoman(int number) {
        if (number == 0) {
            return "Z";
        }
        StringBuilder roman = new StringBuilder();
        foreach (var item in RomanDict) {
            while (number >= item.Key) {
                roman.Append(item.Value);
                number -= item.Key;
            }
        }
        return roman.ToString();
    }
}
