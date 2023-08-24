<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AirportSummaryDownload.ascx.cs" Inherits="FuelManagementSystem.AirportSummaryDownload" %>


<div>
    <asp:ImageButton runat="server" ID="summaryReportImageButton" ClientIDMode="Static"  ToolTip="" 
    ImageUrl="./Content/download-Logo.png"  OnClick="summaryReportImageButton_Click"/> 
</div>
<div>
    <asp:ImageButton runat="server" ID="fuelReportImageButton" ClientIDMode="Static"  ToolTip="" 
    ImageUrl="./Content/download-Logo.png"  OnClick="FuelReportImageButton_Click"/> 
</div>
    <asp:TextBox runat="server" ID="startDateUserHandle" ClientIDMode="Static" TextMode="Date" />
    <asp:TextBox  runat="server"  ID="endDateUserHandle" ClientIDMode="Static" TextMode="Date"/>
