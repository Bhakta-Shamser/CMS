using CMS.Contract.Interfaces;
using CMS.Infrastructure.Services;
using FluentAssertions;
using NetArchTest.Rules;

namespace CMS.UnitTest
{
    public class ArchitectureDependenciesTests 
    {
        private const string DomainNamespace = "CMS.Domain";
        private const string ApplicationNamespace = "CMS.Application";
        private const string ContractNamespace = "CMS.Contract";
        private const string InfrastructureNamespace = "CMS.Infrastructure";
        private const string ApiNamespace = "CMS.Api";


        [Fact]
        public void Domain_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange
            var domainAssembly = typeof(CMS.Domain.Entities.Candidate).Assembly;

            // Act 
            var result = Types.InAssembly(domainAssembly)
              .That()
              .ResideInNamespace(DomainNamespace)
              .ShouldNot()
              .HaveDependencyOn(ApiNamespace)
              .And()
               .HaveDependencyOn(InfrastructureNamespace)
               .And()
               .HaveDependencyOn(ContractNamespace)
               .And()
               .HaveDependencyOn(ApplicationNamespace)
              .GetResult();

            // Assert
            Assert.True(result.IsSuccessful, "Domain layer should not reference other layers.");
        }
        [Fact]
        public void CandidateRepositoryImplementInheritAndShouldBeLocatedInInfrastructureNamespace()
        {
            var result = Types.InAssembly(typeof(CandidateRepository).Assembly)
                                .That()
                                .ImplementInterface(typeof(ICandidateRepository)) 
                                .And()
                                .ImplementInterface(typeof(ICandidateReadRepository))
                                .And()
                                .Inherit(typeof(BaseRepository))
                                .Should()
                                .ResideInNamespaceEndingWith("Infrastructure.Services") 
                                .GetResult();

           Assert.True(result.IsSuccessful, "Candidate Repository should implement ICandidateRepository and ICandidateReadRepository, Inherit BaseRepository and should lie in Infrastructure Layer.");
        }
    }
}
