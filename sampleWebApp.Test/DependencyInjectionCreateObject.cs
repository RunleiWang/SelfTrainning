using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace sampleWebApp.Test
{
    public class DependencyInjectionCreateObject
    {
        class IndependentType{ }
        
        class WithDependency
        {
            public IndependentType Dependency { get; }

            public WithDependency(IndependentType dependency)
            {
                Dependency = dependency;
            }
        }


        [Fact]
        public void should_create_object_using_delegate_registration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(_ => new IndependentType());
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            var instance = provider.GetService<IndependentType>();
            
            Assert.Same(typeof(IndependentType), instance.GetType());;                        
        }

        [Fact]
        public void should_return_null_create_an_object_is_not_in_get_service()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(_ => new IndependentType());
            ServiceProvider provider = serviceCollection.BuildServiceProvider();

            var instance = provider.GetService<WithDependency>();
            
            Assert.Null(instance);;
        }

        [Fact]
        public void should_create_object_using_type_registration()
        {
            //Given
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IndependentType>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            
            //When
            var instance = provider.GetService<IndependentType>();
            
            Assert.Same(typeof(IndependentType), instance.GetType());
        }
      
        [Fact]
        public void should_create_new_instance_per_call_for_transient_scope()
        {
            //Given
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IndependentType>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            
            //When
            var instance = provider.GetService<IndependentType>();
            var another = provider.GetService<IndependentType>();
            
            //Then
            Assert.NotSame(instance, another);
        }

        [Fact]
        public void should_create_one_instance_per_scope()
        {
            //Given
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IndependentType>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            
            
            //when
            var instance = provider.GetService<IndependentType>();
            var another = provider.GetService<IndependentType>();
            
            //Then
            Assert.Same(instance, another); 
            
        }

        [Fact]
        public void should_create_one_instance_per_root_scope()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IndependentType>();
            ServiceProvider rootScopeProvider = serviceCollection.BuildServiceProvider();

            IServiceScope childscope = rootScopeProvider.CreateScope();
            IServiceScope anotherScope = rootScopeProvider.CreateScope();

            var instance = childscope.ServiceProvider.GetService<IndependentType>();
            var another = anotherScope.ServiceProvider.GetService<IndependentType>();
            var third = rootScopeProvider.GetService<IndependentType>();
            
            
            Assert.Same(instance, another);
            Assert.Same(another, third);
        }

  

        [Fact]
        public void should_create_instance_with_dependency_using_delegate_registration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient(_ => new IndependentType());
            serviceCollection.AddTransient(p => new WithDependency(p.GetService<IndependentType>()));
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var instance = serviceProvider.GetService<WithDependency>();
            
            
            Assert.Same(typeof(WithDependency), instance.GetType());
            Assert.Same(typeof(IndependentType), instance.Dependency.GetType());
            
        }

        [Fact]
        public void should_create_instance_with_dependency_using_type_registration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IndependentType>();
            serviceCollection.AddTransient<WithDependency>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            
            var instance = serviceProvider.GetService<WithDependency>();
            
            
            Assert.Same(typeof(WithDependency), instance.GetType());
            Assert.Same(typeof(IndependentType), instance.Dependency.GetType());

        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}