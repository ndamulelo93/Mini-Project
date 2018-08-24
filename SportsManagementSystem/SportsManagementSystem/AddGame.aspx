<%@ Page Title="" Language="C#" MasterPageFile="~/SMS.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="SportsManagementSystem.AddGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="vendors/dropzone/dist/min/dropzone.min.css" rel="stylesheet" />
    <div class="nav-md">
        <div class="right_col" role="main">
                
            <div class="">
                <div class="page-title">
                    <div class="title_left">
                        <h3>Create New Game</h3>
                    </div>

                    <div class="title_right">
                        <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="Search " />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearfix"></div>

                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_content">

                                <div class="form-horizontal form-label-left">

                                    <div class="item form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="t1">Team One</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="txtTeamOne" name="t1" runat="server" required="required" class="form-control col-md-7 col-xs-12" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3">Team Two</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="txtTeamTwo" runat="server" class="form-control col-md-7 col-xs-12" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3">Venue</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <input id="txtVenue" runat="server" class="form-control col-md-7 col-xs-12" required="required" />
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3">Game Date</label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <%--<input id="txtGameDate" runat="server"  class="form-control col-md-7 col-xs-12" required="required" />--%>
                                            <asp:TextBox ID="txtDate" runat="server" TextMode="DateTimeLocal">Game Date</asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="item form-group">
                                        <label class="control-label col-md-3">Upload Game Image</label>
                                        <%-- <div class="item form-group col-md-6 col-sm-6 col-xs-12" style="height: 150px;">
                                            <div action="Tester.aspx" class="dropzone"></div>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </div>--%>
                                        <asp:FileUpload ID="flImage" runat="server" class="btn btn-success" />
                                    </div>

                                    <div class="ln_solid"></div>
                                    <div class="form-group">
                                        <div class="col-md-6 col-md-offset-3">
                                            <asp:LinkButton class="btn btn-success" ID="lnkSubmit" runat="server" OnClick="lnkSubmit_Click">Submit</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /page content -->
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="../vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../vendors/nprogress/nprogress.js"></script>
    <!-- validator -->
    <%--    <script src="../vendors/validator/validator.js"></script>--%>

    <!-- Custom Theme Scripts -->
    <script src="../build/js/custom.min.js"></script>
    <!-- /page content -->
    <!-- jQuery -->
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <%--    <script src="../vendors/fastclick/lib/fastclick.js"></script>--%>
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- Dropzone.js -->
    <%--    <script src="vendors/dropzone/dist/min/dropzone.min.js"></script>--%>
    <script src="vendors/dropzone/dist/min/dropzone.min.js"></script>
    <script src="vendors/dropzone/dist/min/dropzone-amd-module.min.js"></script>
    <script src="vendors/dropzone/dist/dropzone.js"></script>
    <link href="vendors/dropzone/dist/dropzone.css" rel="stylesheet" />
    <script src="vendors/dropzone/dist/dropzone-amd-module.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>


</asp:Content>
