<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="CreateLog.aspx.cs" Inherits="SportsManagementSystem.CreateLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="right_col" role="main">
        <div class="">
            <div class="page-title">
                <div class="title_left">
                    <h3>Create Log</h3>
                </div>
                <div class="title_right">
                    <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="Search" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="clearfix"></div>

            <div class="row">
                <div class="col-md-12">
                    <div class="x_panel">
                        <div class="x_content">
                            <!-- start Log list -->
                            <table class="table table-striped projects">
                                <thead>
                                    <tr>
                                        <th style="width: 1%">Pos</th>
                                        <th style="width: 20%">Team</th>
                                        <th></th>
                                        <th>P</th>
                                        <th>D</th>
                                        <th>W</th>
                                        <th>L</th>
                                        <th>Pts</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>
                                            <select class="select2_single" tabindex="-1" style="width: 130px; height: 24px;">
                                                <option></option>
                                                <option>Kaizer Chiefs</option>
                                                <option>Orlando Pirates</option>
                                                <option>Amazulu</option>
                                                <option>Mamelodi Sundowns</option>
                                            </select></td>
                                        <td></td>
                                        <td><a>
                                            <input style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input style="width: 50px;" /></a></td>
                                        <td><a>
                                            <input style="width: 50px;" /></a></td>
                                    </tr>
                                </tbody>
                            </table>
                            <!-- end Log list -->
                            <div class="ln_solid"></div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                    <asp:LinkButton class="btn btn-success" ID="lnkAddLeague" runat="server">Create Log</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->

</asp:Content>
