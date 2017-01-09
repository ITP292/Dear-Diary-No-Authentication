<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dear_Diary.NewEntry.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-wrapper">
            <div class="slider-wrap" data-navigation="navbtns">
                <div class="prev">
                    <img src="../Content/img/slider.png" title="prev" alt="prev" />
                </div>
                <div class="next">
                    <img src="../Content/img/slider.png" title="next" alt="next" />
                </div>
                <div class="owl-carousel owl-theme" >
                    <div class="item">
                        <div class="thumbnail">
                            <img src="../Content/img/thumb01.jpg" title="nyc subway" alt="nyc subway"/>
                        </div>
                    </div>
                    <div class="item">
                        <div class="thumbnail">
                            <img src="../Content/img/thumb02.jpg" alt="danny antonucci" title="danny antonucci"/>
                        </div>
                    </div>
                    <div class="item">
                        <div class="thumbnail">
                            <img src="../Content/img/thumb03.jpg" title="color-pick" alt="danny antonucci"/>
                        </div>
                    </div>
                    <div class="item">
                        <div class="thumbnail">
                            <img src="../Content/img/thumb04.jpg" title="i-pad" alt="danny antonucci"/>
                        </div>
                    </div>
                    <div class="item">
                        <div class="thumbnail">
                            <img src="../Content/img/thumb05.jpg" title="magazines" alt="danny antonucci"/>
                        </div>
                    </div>
                </div>
                <div class="clear" ></div>
                
            </div>
            <div class="clear" ></div>
            <div class="end-line">
            </div>
            <div class="body-wrapper">
                <div class="wrapper">
                    <div class="img left">
                        <img src="../Content/img/thumb03.jpg" title="Delicious food recipe" alt="Delicious food recipe" />
                    </div>
                    <div class="contant right">
                        <h2>Delicious food recipe</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum suscipit, augue et feugiat vehicula, massa quam rutrum augue, ut imperdiet dui ipsum a elit. Sed quis odio ac nisi fringilla vestibulum viverra id nibh. Maecenas nec euismod sapien. Fusce viverra nisl lacus, sit amet ornare nulla tristique ut. Nulla facilisi. Pellentesque a sagittis dui, in facilisis velit. Phasellus eros erat, dignissim a feugiat at, tempus nec mi.</p>
                        <button class="contibue-btn">Continue Reading ...</button>
                    </div>
                    <div class="clear" ></div>
                </div>
                <div class="wrapper">
                    <div class="img left">
                        <img src="../Content/img/thumb04.jpg"  />
                    </div>
                    <div class="contant right">
                        <h2>Delicious food recipe</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum suscipit, augue et feugiat vehicula, massa quam rutrum augue, ut imperdiet dui ipsum a elit. Sed quis odio ac nisi fringilla vestibulum viverra id nibh. Maecenas nec euismod sapien. Fusce viverra nisl lacus, sit amet ornare nulla tristique ut. Nulla facilisi. Pellentesque a sagittis dui, in facilisis velit. Phasellus eros erat, dignissim a feugiat at, tempus nec mi.</p>
                        <button class="contibue-btn">Continue Reading ...</button>
                    </div>
                    <div class="clear" ></div>
                </div>
                <div class="wrapper">
                    <div class="img left">
                        <img src="../Content/img/thumb05.jpg" />
                    </div>
                    <div class="contant right">
                        <h2>Delicious food recipe</h2>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum suscipit, augue et feugiat vehicula, massa quam rutrum augue, ut imperdiet dui ipsum a elit. Sed quis odio ac nisi fringilla vestibulum viverra id nibh. Maecenas nec euismod sapien. Fusce viverra nisl lacus, sit amet ornare nulla tristique ut. Nulla facilisi. Pellentesque a sagittis dui, in facilisis velit. Phasellus eros erat, dignissim a feugiat at, tempus nec mi.</p>
                        <button class="contibue-btn">Continue Reading ...</button>
                    </div>
                    <div class="clear" ></div>
                </div>
                <div class="paging left">
                    <ul>
                        <li><a id="click" href="#"> << </a></li>
                        <li><a href="#"> 1 </a></li>
                        <li><a href="#"> 2 </a></li>
                        <li class="active-page"><a href="#"> 3 </a></li>
                        <li><a href="#"> 4 </a></li>
                        <li><a href="#"> 5 </a></li>
                        <li><a href="#"> >> </a></li>
                    </ul>
                </div>
                <div class="clear"></div>
            </div>
        </div>
</asp:Content>
