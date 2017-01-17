<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="MainPage.aspx.cs" Inherits="Dear_Diary.NewEntry.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-wrapper">

        <%--Image slider (scroll bar) related code--%>
        <div class="slider-wrap" data-navigation="navbtns">
            <div class="prev">
                <img src="../Content/img/slider.png" title="prev" alt="prev" />
            </div>
            <div class="next">
                <img src="../Content/img/slider.png" title="next" alt="next" />
            </div>
            <div class="owl-carousel owl-theme">
                <div class="item">
                    <div class="thumbnail">
                        <img src="../Content/img/thumb01.jpg" title="nyc subway" alt="nyc subway" />
                    </div>
                </div>
                <div class="item">
                    <div class="thumbnail">
                        <img src="../Content/img/thumb02.jpg" alt="danny antonucci" title="danny antonucci" />
                    </div>
                </div>
                <div class="item">
                    <div class="thumbnail">
                        <img src="../Content/img/thumb03.jpg" title="color-pick" alt="danny antonucci" />
                    </div>
                </div>
                <div class="item">
                    <div class="thumbnail">
                        <img src="../Content/img/thumb04.jpg" title="i-pad" alt="danny antonucci" />
                    </div>
                </div>
                <div class="item">
                    <div class="thumbnail">
                        <img src="../Content/img/thumb05.jpg" title="magazines" alt="danny antonucci" />
                        
                    </div>
                </div>
            </div>
            <div class="clear"></div>


        </div>
        <div class="clear"></div>
        <div class="end-line">
        </div>
        <div class="body-wrapper">
            <%-- Display one image and discription related code ( this code will repeat as per database record) --%>
            <asp:Repeater ID="rptPostList" runat="server">
                <ItemTemplate>
                    <div class="wrapper">
                        <div class="img left">
                            <asp:Image ImageUrl='<%# Eval("Picture").ToString() == "" ? "~/Pictures/default-thumbnail.jpg" : Eval("Picture") %>' ID="img" runat="server" />
                        </div>
                        <div class="contant right">
                            <p>
                                <asp:Label ID="lblpostEntrytext" runat="server" Text='<%# Eval("Post_Text") %>' />
                            </p>
                            <asp:Button CssClass="contibue-btn" ID="btnMoreDetails" CommandArgument='<%# Eval("Post_Id") %>' OnCommand="btnMoreDetails_Click" Text="More Details ..." runat="server" />
                        </div>
                        <div class="clear"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />

            <%--<div class="paging left">
                    <ul>
                        <li><a id="click" href="#"><< </a></li>
                        <li><a href="#">1 </a></li>
                        <li><a href="#">2 </a></li>
                        <li class="active-page"><a href="#">3 </a></li>
                        <li><a href="#">4 </a></li>
                        <li><a href="#">5 </a></li>
                        <li><a href="#">>> </a></li>
                    </ul>
                </div>--%>
            <div class="clear"></div>
        </div>
    </div>
    <script src="/Content/js/owl.carousel.min.js"></script>
    <script type="text/javascript">

        <%-- this is code for image of scrollbar (image slider) --%>

        $(document).ready(function () {
            $("#menu_open").click(function () {
                $(".menu").toggle(500);
            });
            $(".prev").click(function () {
                $(".owl-prev").click();
            });
            $(".next").click(function () {
                $(".owl-next").click();
            });
            $('.owl-carousel').owlCarousel({
                loop: true,
                margin: 10,
                nav: true,
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 3
                    }
                }
            })
        });
    </script>
</asp:Content>
