using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace sampleWebApp.Test
{
    public class DependencyInjecdtionCreateObject
    {
        class IndependenType{ }

        [Fact]
        public void should_create_object_using_delegate_registration()
        {
            
        }



        [Fact]
        public void should_create_object_using_type_registration()
        {
            
        }


        [Fact]
        public void should_create_new_instance_per_call_for_transient_scope()
        {
            //Given
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IndependenType>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            
            //When
            var instance = provider.GetService<IndependenType>();
            var another = provider.GetService<IndependenType>();
            
            //Then
            Assert.NotSame(instance, another);
        }

        [Fact]
        public void should_create_one_instance_per_scope()
        {
            //Given
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IndependenType>();
            ServiceProvider provider = serviceCollection.BuildServiceProvider();
            
            
            //when
            var instance = provider.GetService<IndependenType>();
            var another = provider.GetService<IndependenType>();
            
            //Then
            Assert.Same(instance, another); 
            
        }
        
        [Fact]
        public void should_create_
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}