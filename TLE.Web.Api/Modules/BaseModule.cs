using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using TLE.Web.Api.Configuration;

namespace TLE.Web.Api.Modules
{
    public class BaseModule : NancyModule
    {
        protected int UserId => Context.UserId();
        protected string UserName => Context.UserFullName();
        protected string UserEmail => Context.UserEmail();
        protected string AccessToken => Context.AccessToken();

        protected BaseModule(string modulePrefix, bool isAuth = true) : base(modulePrefix)
        {
            ApplyAuth(isAuth);
        }

        private int GetParam(dynamic args)
        {
            var dic = (DynamicDictionary)args;

            return dic.Values.Last();
        }

        private string GetStringParam(dynamic args)
        {
            var dic = (DynamicDictionary)args;

            return dic.Values.Last();
        }

        private int GetParams(dynamic args, out int value2)
        {
            var dic = (DynamicDictionary)args;
            int value1 = dic.Values.Skip(dic.Values.Count - 2).First();
            value2 = dic.Values.Last();

            return value1;
        }

        private void ApplyAuth(bool isAuth)
        {
            if (isAuth)
            {
                this.RequiresAuthentication();
            }
        }

        /// <summary>
        /// Define a get actions
        /// </summary>
        protected void Get<TOutput>(string path, Func<Task<TOutput>> action, bool isAuth = true)
        {
            base.Get(path, async args => { ApplyAuth(isAuth); return await action.Invoke(); });
        }

        /// <summary>
        /// Define a get action with a single ID defining from routing
        /// </summary>
        protected void Get<TOutput>(string path, Func<int, Task<TOutput>> action, bool isAuth = true)
        {
            base.Get(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetParam(args)); });
        }

        /// <summary>
        /// Define a get action with a single param as string defining from routing
        /// </summary>
        protected void Get<TOutput>(string path, Func<string, Task<TOutput>> action, bool isAuth = true)
        {
            base.Get(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetStringParam(args)); });
        }

        /// <summary>
        /// Define a get action with two IDs defining from routing
        /// </summary>
        protected void Get<TOutput>(string path, Func<int, int, Task<TOutput>> action, bool isAuth = true)
        {
            base.Get(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetParams(args, out int value2), value2); });
        }

        /// <summary>
        /// Define a post action with a single model
        /// </summary>
        /// <typeparam name="TInput">Input(model) type</typeparam>
        /// <typeparam name="TOutput">Return type</typeparam>
        /// <param name="path">Routing path</param>
        /// <param name="action">Action invocked to handle the request</param>
        protected void Post<TInput, TOutput>(string path, Func<TInput, Task<TOutput>> action, bool isAuth = true)
        {
            base.Post(path, async args =>
            {
                ApplyAuth(isAuth);
                var model = this.BindAndValidate<TInput>();

                if (ModelValidationResult.IsValid)
                {
                    return await action.Invoke(this.Bind<TInput>());
                }

                return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
            });
        }

        /// <summary>
        /// Define a post action with an ID defining from routing and a Model
        /// </summary>
        protected void Post<TInput, TOutput>(string path, Func<int, TInput, Task<TOutput>> action, bool isAuth = true)
        {
            base.Post(path, async args =>
            {
                ApplyAuth(isAuth);
                var model = this.BindAndValidate<TInput>();

                if (ModelValidationResult.IsValid)
                {
                    return await action.Invoke(GetParam(args), model);
                }

                return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
            });
        }

        /// <summary>
        /// Define a put action with a single model
        /// </summary>
        protected void Put<TInput, TOutput>(string path, Func<TInput, Task<TOutput>> action, bool isAuth = true)
        {
            base.Put(path, async args =>
            {
                ApplyAuth(isAuth);
                var model = this.BindAndValidate<TInput>();

                if (ModelValidationResult.IsValid)
                {
                    return await action.Invoke(model);
                }

                return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
            });
        }

        /// <summary>
        /// Define a put action with an ID defining from routing and a Model
        /// </summary>
        protected void Put<TInput, TOutput>(string path, Func<int, TInput, Task<TOutput>> action, bool isAuth = true)
        {
            base.Put(path, async args =>
            {
                ApplyAuth(isAuth);
                var model = this.BindAndValidate<TInput>();

                if (ModelValidationResult.IsValid)
                {
                    return await action.Invoke(GetParam(args), model);
                }

                return Negotiate.WithModel(ModelValidationResult).WithStatusCode(HttpStatusCode.BadRequest);
            });
        }

        /// <summary>
        /// Define a put action with two IDs defining from routing
        /// </summary>
        protected void Put<TOutput>(string path, Func<int, int, Task<TOutput>> action, bool isAuth = true)
        {
            base.Put(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetParams(args, out int value2), value2); });
        }

        /// <summary>
        /// Define a delete action with an ID defining from routing
        /// </summary>
        protected void Delete<TOutput>(string path, Func<int, Task<TOutput>> action, bool isAuth = true)
        {
            base.Delete(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetParam(args)); });
        }

        /// <summary>
        /// Define a delete action with two IDs defining from routing
        /// </summary>
        protected void Delete<TOutput>(string path, Func<int, int, Task<TOutput>> action, bool isAuth = true)
        {
            base.Delete(path, async args => { ApplyAuth(isAuth); return await action.Invoke(GetParams(args, out int value2), value2); });
        }
    }
}
