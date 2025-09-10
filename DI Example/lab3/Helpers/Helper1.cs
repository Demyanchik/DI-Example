using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DI.Controllers;
using DI.MyClasses;

namespace DI
{
    namespace Helpers
    {
        public static class Helper1
        {

            //TagBuilder table = new TagBuilder("table");

            //TagBuilder tr = new TagBuilder("tr");
            //form.Attributes.Add("action", DictController.path + "/Dict/AddSave");
            //form.Attributes.Add("method", "post");

            //TagBuilder button1 = new TagBuilder("input");
            //button1.MergeAttribute("type", "submit", true);
            //button1.MergeAttribute("name", "press", true);
            //button1.Attributes.Add("size", "20");
            //button1.MergeAttribute("value", "Добавить", true);

            //TagBuilder button2 = new TagBuilder("input");
            //button2.MergeAttribute("type", "submit");
            //button2.MergeAttribute("name", "press");
            //button2.MergeAttribute("size", "20");
            //button2.MergeAttribute("value", "Отмена", true);

            //form.InnerHtml += button1.ToString() + button2.ToString();
            public static MvcHtmlString AddForm(this HtmlHelper html)
            {
                TagBuilder form = new TagBuilder("form");
                form.Attributes.Add("action", DictController.path + "/Dict/AddSave");
                form.Attributes.Add("method", "post");

                form.InnerHtml = "<table>" +
                        "<tr>" +
                            "<td><label for=\"surname\">Фамилия:</label> </td>" +
                            "<td> <input type=\"text\" name=\"surname\" size=\"20\"> </td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><label for=\"number\">Телефон:</label></td>" +
                            "<td><input type=\"text\" name=\"number\" size=\"20\"></td>" +
                        "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<input type=\"submit\" name=\"press\" value=\"Добавить\" size=\"20\">" +
                    "<input type=\"submit\" name=\"press\" value=\"Отмена\" size=\"20\">";

                return new MvcHtmlString(form.ToString());
            }

            public static MvcHtmlString UpdateForm(this HtmlHelper html, PhoneNumbers line)
            {
                TagBuilder form = new TagBuilder("form");
                form.Attributes.Add("action", DictController.path + "/Dict/UpdateSave?id=" + line.id);
                form.Attributes.Add("method", "post");

                form.InnerHtml = "<table>" +
                        "<tr>" +
                            "<td><label for=\"surname\">Фамилия:</label> </td>" +
                            "<td> <input type=\"text\" name=\"surname\" value=\"" + line.surname + "\" size=\"20\"> </td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><label for=\"number\">Телефон:</label></td>" +
                            "<td><input type=\"text\" name=\"number\" value=\"" + line.number + "\" size=\"20\"></td>" +
                        "</tr>" +
                    "</table>" +
                    "<br>" +
                    "<input type=\"submit\" name=\"press\" value=\"Изменить\" size=\"20\">" +
                    "<input type=\"submit\" name=\"press\" value=\"Отмена\" size=\"20\">";

                return new MvcHtmlString(form.ToString());
            }

            public static MvcHtmlString DeleteForm(this HtmlHelper html, PhoneNumbers line)
            {
                TagBuilder form = new TagBuilder("form");
                form.Attributes.Add("action", DictController.path + "/Dict/DeleteSave?id=" + line.id);
                form.Attributes.Add("method", "post");

                form.InnerHtml = "<h4>" +
                    "Вы действительно хотите удалить следующую запись?" +
                "</h4>" +
                "<table border=\"1\">" +
                    "<tr>" +
                        "<td>" + line.surname + "</td>" +
                        "<td>" + line.number + "</td>" +
                    "</tr>" +
                "</table>" +
                "<br />" +
                "<input type=\"submit\" name=\"press\" value=\"Да\" size=\"20\">" +
                "<input type=\"submit\" name=\"press\" value=\"Нет\" size=\"20\">";

                return new MvcHtmlString(form.ToString());
            }
        }
    }
}