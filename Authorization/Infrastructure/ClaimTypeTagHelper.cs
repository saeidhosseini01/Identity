﻿using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection;
using System.Security.Claims;

namespace Authorization.Infrastructure
{




    [HtmlTargetElement("td",Attributes="identity-claim-type")]
    public class ClaimTypeTagHelper:TagHelper
    {
        [HtmlAttributeName("identity-claim-type")]
        public string ClaimType { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            bool foundType=false;
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            foreach (FieldInfo field in fields) 
            {
                if(field.GetValue(null).ToString()==ClaimType)
                {
                    output.Content.SetContent(field.Name);
                }

            }
            if (!foundType)
            {
                output.Content.SetContent(ClaimType.Split('/','.').Last());

            }
        }
    }
}
