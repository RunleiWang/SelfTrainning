using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace sampleWebApp.Test
{
    public class ManageObjectLifetime
    {
        class Disposable : IDisposable
        {
            public bool IsDisposed { get; private set; }
            public void Dispose()
            {
                IsDisposed = true;
            }
        }


        [Fact]
        public void should_dispose_object()
        {
            //register definition
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<Disposable>();
            
            //create provider
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            var disposables = new List<Disposable>();
            disposables.Add(provider.GetService<Disposable>());
            disposables.Add(provider.GetService<Disposable>());
            disposables.Add(provider.GetService<Disposable>());
            disposables.Add(provider.GetService<Disposable>());
            
            provider.Dispose();
            
            //Assert.True(disposables.All(item = > item.Is));
        }

        [Fact]
        public void should_manage_object_by_scope()
        {
            //web application stratup
            
            //request comes
            
            //call controller action
            
            //request end
        }


        [Fact]
        public void should_manage_object_numbers()
        {
            //web application startup
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<Disposable>();  //Disposable 这个对象 证明provider只能创建一个对象；返回来的是同一个对象
            
            
            //create service provider
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            var disposable = provider.GetService<Disposable>();
            var another = provider.GetService<Disposable>();
            
            Assert.Same(disposable, another);   //这两个对象就是一样的！
            
            provider.Dispose();
            
            Assert.True(disposable.IsDisposed);
        }
        
    }
}