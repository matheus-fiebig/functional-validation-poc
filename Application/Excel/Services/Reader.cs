using ClosedXML.Excel;

namespace Application.Excel.Services;

public class Reader
{
    public static IEnumerable<T> ReadExcel<T>(string file, Func<IXLRangeRow, T> selector)
    {
        using var workbook = new XLWorkbook(file);
        return workbook.Worksheet(1)
            .RangeUsed()
            .RowsUsed()
            .Select(row => selector(row));
    }   
}