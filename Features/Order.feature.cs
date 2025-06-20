﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace agros_repo.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Ordering and calculation bill for group people")]
    public partial class OrderingAndCalculationBillForGroupPeopleFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en"), "Features", "Ordering and calculation bill for group people", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ordering food by group of people before 7 pm")]
        [NUnit.Framework.TestCaseAttribute("true", null)]
        [NUnit.Framework.TestCaseAttribute("false", null)]
        public void OrderingFoodByGroupOfPeopleBefore7Pm(string isBefore7Pm, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("IsBefore7pm", isBefore7Pm);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ordering food by group of people before 7 pm", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Starters",
                            "Mains",
                            "Drinks",
                            "IsBefore7pm"});
                table1.AddRow(new string[] {
                            "4",
                            "4",
                            "4",
                            string.Format("{0}", isBefore7Pm)});
                testRunner.Given("A group of 4 people order", ((string)(null)), table1, "Given ");
                testRunner.When("The bill is requested via the endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("The calculated sum of bill is correct in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Ordering food by group of people joining later to main group of people")]
        public void OrderingFoodByGroupOfPeopleJoiningLaterToMainGroupOfPeople()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Ordering food by group of people joining later to main group of people", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Starters",
                            "Mains",
                            "Drinks",
                            "IsBefore7pm"});
                table2.AddRow(new string[] {
                            "1",
                            "2",
                            "2",
                            "true"});
                testRunner.Given("A group of 2 people order", ((string)(null)), table2, "Given ");
                testRunner.When("The bill is requested via the endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("The calculated sum of bill is correct in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Starters",
                            "Mains",
                            "Drinks",
                            "IsBefore7pm"});
                table3.AddRow(new string[] {
                            "1",
                            "2",
                            "2",
                            "true"});
                testRunner.When("A group of 2 people is joined and order", ((string)(null)), table3, "When ");
                testRunner.When("The bill is requested via the endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("The calculated sum of bill is correct in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Canceling order by some of the people from the group")]
        [NUnit.Framework.TestCaseAttribute("true", null)]
        [NUnit.Framework.TestCaseAttribute("false", null)]
        public void CancelingOrderBySomeOfThePeopleFromTheGroup(string isBefore7Pm, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("IsBefore7pm", isBefore7Pm);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Canceling order by some of the people from the group", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Starters",
                            "Mains",
                            "Drinks",
                            "IsBefore7pm"});
                table4.AddRow(new string[] {
                            "1",
                            "1",
                            "4",
                            string.Format("{0}", isBefore7Pm)});
                testRunner.Given("A group of 4 people order", ((string)(null)), table4, "Given ");
                testRunner.When("The bill is requested via the endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("The calculated sum of bill is correct in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Starters",
                            "Mains",
                            "Drinks",
                            "IsBefore7pm"});
                table5.AddRow(new string[] {
                            "0",
                            "0",
                            "1",
                            string.Format("{0}", isBefore7Pm)});
                testRunner.When("Some people from the group cancel order", ((string)(null)), table5, "When ");
                testRunner.When("The bill is requested via the endpoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
                testRunner.Then("The calculated sum of bill is correct in the response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
