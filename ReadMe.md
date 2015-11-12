# XamGrid with Styled Background for Null values

This is a test project to create an Infragistics XamGrid that uses a custom style to
change the background color for the cell if the binding value is null. This is similar
to Sql Server Management Studio (SSMS) that uses a special background color for NULL values.
I don't want the cell style to also put `NULL` in the TextBlock, but it would be nice 
to know how to do it as well.

The issue I'm facing is that I do not know how to create the Style that uses the 
binding from the XamGrid TextColumn. Instead I have to use the binding to an property
in the XamGrid.ItemsSource, so it is effectively hard-coded for each column instead of
a generic style that can be applied to any column.

I created two XamGrids where one is bound to a `DataView` (from a `DataTable`) and the
other is bound to a `ViewModel`.

I also added two DataGrids for comparison, although technically it isn't fully working
either. The style for the DataGrids is bound to the `TextBlock.Text` value and applies
the style when `Text` is empty instead of only when the value is null.

![MainWindow Screenshot](MainWindow.png)

![SSMS Grid with NULL](SSMS_Results.png)

## Outstanding Issues

1. The `NullCellStyle` has a hard-coded binding in the `DataTrigger`. How can I create
a style that uses the binding of the column instead?

2. How can I change the text in a `TextColumn` if the binding value is null?

3. The `EmptyTextBlock` style actually compares against empty Text instead of null value.

## Resolved Issues

None.