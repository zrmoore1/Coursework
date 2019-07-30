<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TriangleAreaCalculator.ascx.cs" Inherits="Homework_week2_TriangleAreaCalculator"%>
    <script src="../../Scripts/triangleAreaCalculator.js" type="text/javascript"></script>
<div class="outer-wrapper">
    <div class="inner-wrapper">
        <img src="../../Images/triangle.gif" width="100" height="90"/>
        <section>
            <p>
                Enter the width and height of your<br /> triangle to calculate the area.
            </p>
            <table>
                <tr>
                    <td><label for="txtWidth">Width (b):</label></td>
                    <td><input name="txtWidth" type="text" id="txtWidth"/></td>
                </tr>
                <tr>
                    <td><label for="txtHeight">Height (h):</label></td>
                    <td><input name="txtHeight" type="text" id="txtHeight"/></td>
                </tr>
            </table>
            <button type="button" onclick="calculateArea()">Calculate area</button>
            <hr />
            <table>
                <tr>
                    <td><strong><label for="txtArea">The area is:</label></strong></td>
                    <td><input name="txtArea" type="text" id="txtArea" /></td>
                </tr>
            </table>
        </section>
    </div>
</div>