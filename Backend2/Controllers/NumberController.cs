using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend2.Models;
using Backend2.Services;


namespace Backend2.Controllers
{
    public class NumberController : Controller
    {
        private readonly IArithmeticService arithmeticService;

        public NumberController(IArithmeticService arithmeticService)
        {
            this.arithmeticService = arithmeticService;
        }

        public ActionResult NumberManual()   
        {
            if (this.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                String namestring = this.Request.Form["Name"];
                String namestring1 = this.Request.Form["Name1"];
                String optin = this.Request.Form["opt"];
                this.ViewBag.Name = namestring;
                this.ViewBag.Name1 = namestring1;
                this.ViewBag.Opt = optin;
                if ((String.IsNullOrEmpty(namestring)) && (String.IsNullOrEmpty(namestring1)))
                {
                    this.ViewBag.Error = "First operand is required";
                    this.ViewBag.Error1 = "Second operand is required";
                    return this.View();
                }
                if (String.IsNullOrEmpty(namestring))
                {
                    this.ViewBag.Error = "First operand is required";
                    if (optin == "4")
                    {
                        int NS1 = Int32.Parse(namestring1);
                        if (NS1 == 0)
                        {
                            this.ViewBag.Error1 = "Division by zero is forbidden";     
                        } 
                    }
                    return this.View();
                }
                if (String.IsNullOrEmpty(namestring1))
                {
                    this.ViewBag.Error1 = "Second operand is required";
                    return this.View();
                }
                int name = Int32.Parse(namestring);
                int name1 = Int32.Parse(namestring1);
                var greeting = 0;
                if (optin == "1")
                {
                    greeting = this.arithmeticService.plus(name, name1);
                }
                if (optin == "2")
                {
                    greeting = this.arithmeticService.minus(name, name1);
                }
                if (optin == "3")
                {
                    greeting = this.arithmeticService.sum(name, name1);
                }
                if (optin == "4")
                {
                    if (name1 == 0)
                    {
                        this.ViewBag.Error1 = "Division by zero is forbidden";
                        return this.View();
                    }
                    greeting = this.arithmeticService.del(name, name1);
                }

                var resultModel = new NumberResultViewModel
                {
                    First = greeting
                };

                return this.View("ResultNumber", resultModel);
            }

            return this.View();

        }

        public ActionResult NumberManualWithSeparateHandlers()
        {
            return this.View();
        }

        [HttpPost, ActionName("NumberManualWithSeparateHandlers")]
        [ValidateAntiForgeryToken]
        public ActionResult NumberManualWithSeparateHandlersConfirm()
        {
                String namestring = this.Request.Form["Name"];
                String namestring1 = this.Request.Form["Name1"];
                String optin = this.Request.Form["opt"];
            this.ViewBag.Name = namestring;
            this.ViewBag.Name1 = namestring1;
            this.ViewBag.Opt = optin;
            if ((String.IsNullOrEmpty(namestring)) && (String.IsNullOrEmpty(namestring1)))
            {
                this.ViewBag.Error = "First operand is required";
                this.ViewBag.Error1 = "Second operand is required";
                return this.View();
            }
            if (String.IsNullOrEmpty(namestring))
                {
                    this.ViewBag.Error = "First operand is required";
                if (optin == "4")
                {
                    int NS1 = Int32.Parse(namestring1);
                    if (NS1 == 0)
                    {
                        this.ViewBag.Error1 = "Division by zero is forbidden";
                    }
                }
                return this.View();
                }
                if (String.IsNullOrEmpty(namestring1))
                {
                    this.ViewBag.Error1 = "Second operand is required";
                    return this.View();
                }
               
                int name = Int32.Parse(namestring);
                int name1 = Int32.Parse(namestring1);
                var greeting = 0;
                if (optin == "1")
                {
                    greeting = this.arithmeticService.plus(name, name1);
                }
                if (optin == "2")
                {
                    greeting = this.arithmeticService.minus(name, name1);
                }
                if (optin == "3")
                {
                    greeting = this.arithmeticService.sum(name, name1);
                }
                if (optin == "4")
                {
                if (name1 == 0)
                {
                    this.ViewBag.Error = "Division by zero is forbidden";
                    return this.View();
                }
                greeting = this.arithmeticService.del(name, name1);
                }

                var resultModel = new NumberResultViewModel
                {
                    First = greeting
                };

                return this.View("ResultNumber", resultModel);
            }

        public ActionResult NumberModelBindingInParameters()
        {
            
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NumberModelBindingInParameters(String name, String name1, String opt)
        {
            this.ViewBag.Name = name;
            this.ViewBag.Name1 = name1;
            this.ViewBag.Opt = opt;
            if ((String.IsNullOrEmpty(name)) && (String.IsNullOrEmpty(name1)))
            {
                this.ViewBag.Error = "First operand is required";
                this.ViewBag.Error1 = "Second operand is required";
                return this.View();
            }
            if (String.IsNullOrEmpty(name))
            {
                this.ViewBag.Error = "First operand is required";
                if (opt == "4")
                {
                    int NS1 = Int32.Parse(name1);
                    if (NS1 == 0)
                    {
                        this.ViewBag.Error1 = "Division by zero is forbidden";
                    }
                }
                return this.View();
            }
            if (String.IsNullOrEmpty(name1))
            {
                this.ViewBag.Error1 = "Second operand is required";
                return this.View();
            }

            int names = Int32.Parse(name);
            int names1 = Int32.Parse(name1);
            var greeting = 0;
            if (opt == "1")
            {
                greeting = this.arithmeticService.plus(names, names1);
            }
            if (opt == "2")
            {
                greeting = this.arithmeticService.minus(names, names1);
            }
            if (opt == "3")
            {
                greeting = this.arithmeticService.sum(names, names1);
            }
            if (opt == "4")
            {
                if (names1 == 0)
                {
                    this.ViewBag.Error = "Division by zero is forbidden";
                    return this.View();
                }
                greeting = this.arithmeticService.del(names, names1);
            }

            var resultModel = new NumberResultViewModel
            {
                First = greeting
            };

            return this.View("ResultNumber", resultModel);
        }

        public ActionResult NumberModelBindingInSeparateModel()
        {
            return this.View(new NumberViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NumberModelBindingInSeparateModel(NumberViewModel model)
        {

            this.ViewBag.Name = model.Name;
            this.ViewBag.Name1 = model.Name1;
            this.ViewBag.Opt = model.Opt;
            if (this.ModelState.IsValid)
            {
                if ((String.IsNullOrEmpty(model.Name)) && (String.IsNullOrEmpty(model.Name1)))
                {
                    
                    this.ModelState.AddModelError("Name", "First operand is required");
                    this.ModelState.AddModelError("Name1", "Second operand is required");
                    return this.View(model);
                }
                if (String.IsNullOrEmpty(model.Name)) 
                {
                    this.ModelState.AddModelError("Name", "First operand is required");
                    if (model.Opt == "4")
                    {
                        int NS1 = Int32.Parse(model.Name1);
                        if (NS1 == 0)
                        {
                            this.ModelState.AddModelError("Name1", "Division by zero is forbidden");
                        }
                    }
                    return this.View(model);
                }
                if (String.IsNullOrEmpty(model.Name1))
                { 
                    this.ModelState.AddModelError("Name1", "Second operand is required");
                    return this.View(model);
                }

                int names = Int32.Parse(model.Name);
                int names1 = Int32.Parse(model.Name1);
                var greeting = 0;
                if (model.Opt == "1")
                {
                    greeting = this.arithmeticService.plus(names, names1);
                }
                if (model.Opt == "2")
                {
                    greeting = this.arithmeticService.minus(names, names1);
                }
                if (model.Opt == "3")
                {
                    greeting = this.arithmeticService.sum(names, names1);
                }
                if (model.Opt == "4")
                {
                    if (names1 == 0)
                    {
                        this.ViewBag.Error = "Division by zero is forbidden";
                        return this.View();
                    }
                    greeting = this.arithmeticService.del(names, names1);
                }

                var resultModel = new NumberResultViewModel
                {
                    First = greeting
                };

                return this.View("ResultNumber", resultModel);
            }

            return this.View(model);
        }
    }
}
