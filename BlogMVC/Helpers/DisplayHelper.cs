using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Helpers
{
    public static class DisplayHelper
    {
        public static MvcHtmlString CustomDispay<TModel,TValue>(this HtmlHelper <TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            var builder = new TagBuilder("p");
            builder.Attributes["name"] = name;
            if (metadata.Model.ToString().Length > 30)
            {
                builder.SetInnerText(metadata.Model.ToString().Substring(0,30)+"....");
            }
            if(metadata.Model.ToString().Length<30)
            {
                builder.SetInnerText(metadata.Model.ToString());
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
            
    }
}