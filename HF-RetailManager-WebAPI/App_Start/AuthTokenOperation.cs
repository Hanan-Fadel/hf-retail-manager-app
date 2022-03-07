using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace HF_RetailManager_WebAPI.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            //To add an end point for the token to the Swagger
            //We want to add it under the Auth Category,
            //The type of data you are expecting as parameters should come through
            //application/x-www-form-urlencoded
            //The command is Post and it takes 3 parameters (grant_type, username, password).
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation 
                {
                    tags = new List<string> {"Auth"}, 
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter> 
                    {
                        new Parameter
                        {
                            type="string",
                            name="grant_type",
                            required= false,
                            @in="formData",
                            @default="password"

                        },
                        new Parameter
                        {
                            type="string",
                            name="username",
                            required=true,
                            @in="formData"
                        },
                        new Parameter
                        {
                            type="string",
                            name="password",
                            required=false,
                            @in="formData"
                        }
                    }
                }
            }
                
            );
        }
    }
}