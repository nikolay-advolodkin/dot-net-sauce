#Requirements for parallelization in feature files
#1. You must be using NUnit or XUnit and SpecFlow Runner
#2. You must have AssemblyInfo.cs set to for NUnit parallelization [assembly: Parallelizable(ParallelScope.Fixtures)]
#3. You cannot use static context properties such as ScenarioContext.Current, FeatureContext.Current or ScenarioStepContext.Current

Feature: BlogPage
	The BlogPath of Ultimate QA should be visible
	And easy to browse for the user.

@mytag
Scenario: Open Blog page
	When the user opens Ultimate QA blog page
	Then the blog page loads successfully
