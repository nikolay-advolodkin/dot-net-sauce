# demonstration-scripts-C#/dot-net-sauce
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/8d73359469c54f01a0ba96a175514ad3)](https://app.codacy.com/app/nadvolod/demo-csharp?utm_source=github.com&utm_medium=referral&utm_content=nadvolod/demo-csharp&utm_campaign=Badge_Grade_Dashboard)
[![Build Status](https://dev.azure.com/nikolayadvolodkin/SauceExamples/_apis/build/status/nikolay-advolodkin.dot-net-sauce)](https://dev.azure.com/nikolayadvolodkin/SauceExamples/_build/latest?definitionId=1)

This directory contains example scripts and dependencies for running automated Selenium tests on Sauce Labs using C#. You can use these scripts to test your Sauce Labs authentication credentials, the setup of your automated testing environment, and try out Sauce Labs features, like cross-browser testing. Feel free to copy these files or clone the entire directory to your local environment to experiment with creating your own automated Selenium tests!

**For Demonstration Purposes Only**

The code in these scripts is provided on an "AS-IS” basis without warranty of any kind, either express or implied, including without limitation any implied warranties of condition, uninterrupted use, merchantability, fitness for a particular purpose, or non-infringement. These scripts are provided for educational and demonstration purposes only, and should not be used in production. Issues regarding these scripts should be submitted through GitHub. These scripts are maintained by the Technical Services team at Sauce Labs.

## Setting Up a Selenium Project in Visual Studio 

<p>This procedure shows you how to set up a Selenium project in Visual Studio (VS).  Once you set up a project, you'll run a test script written in C#, which we provide, on Sauce Labs. In the future, you can use this script as a template for your own automated tests.</p>
<p>
  <ac:structured-macro ac:macro-id="f2192343-d438-4546-b9cc-b28263b49ba1" ac:name="toc" ac:schema-version="1"/>
</p>
<h3>Installing Visual Studio Community Edition
</h3>
<p>In this step you download and install Visual Studio Community, the free version of Visual Studio. If you already have it installed, go to the next step, <strong>Creating a Test Project</strong>.
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>Go to the <a href="https://visualstudio.microsoft.com/downloads/">
        <span style="color: rgb(17,85,204);">Visual Studio download
      </a>s page.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Download the Community version.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Decide if you want to take the survey or not.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click <strong>Yes</strong> to allow the app to make changes to your device.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click <strong>Continu</strong>
      <strong>e</strong> to accept the license terms.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Select <strong>.NET desktop development, </strong>then click <strong>Install</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click <strong>Launch</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Decide if you want to sign in with your Microsoft account, create an account, or sign in later.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Select a color scheme, then click <strong>Start Visual Studio</strong>.<br/>
      <span style="letter-spacing: 0.0px;">Visual Studio opens.
    </p>
  </li>
</ol>
<h3>Creating a Test Project
</h3>
<p>In this step you create a basic test project.
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>In VS, select <strong>File</strong> &gt; <strong>Project</strong> &gt; <strong>Unit Test Project</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>In the <strong>Name</strong> field, name the project, then click <strong>OK</strong>.<br/>
      <span style="letter-spacing: 0.0px;">Visual Studio creates the project.
    </p>
  </li>
</ol>
<h3>Adding the NuGet Packages
</h3>
<p>In this step, you add the NuGet packages you need to run your automated web tests on Sauce Labs.
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>In the <strong>Solution Explorer</strong> panel to the right of the Visual Studio frame, right-click <strong>References</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Select <strong>Manage </strong>
      <strong>NuGet Packages</strong>. <br/>The NuGet window opens.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>In the <strong>Search</strong> field, enter <strong>Selenium Support</strong>. <br/>A list of Selenium packages appears.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Select <strong>Selenium Support, </strong>then click <strong>Install</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>When the <strong>Preview Changes</strong> dialog box opens, click <strong>OK</strong>. <br/>The package is installed.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Search for <strong>Selenium.WebDriver.ChromeDriver</strong>. Follow the same steps to install it.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Search for <strong>NUnit</strong> and install it.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Search for <strong>NUnit 3 Test Adapter</strong> and install it.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Search for <strong>DotNetSeleniumExtras.WaitHelpers</strong> and install it.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>If you want to check that all the packages are installed, in Solution Explorer, click <strong>packages.config</strong>. <br/>An XML page appears that shows all the installed packages.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Close the NuGet window.</p>
  </li>
</ol>
<h3>Adding the Test Script
</h3>
<p>In this step, you download and run a C# test script from Sauce Labs. The script opens up the Sauce Labs sample web application (a simulated online store) and simulates a login with a sample user. 
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>Download the test script from <a href="https://github.com/saucelabs-training/demo-csharp/blob/master/SauceExamples/Web.Tests/InstantSauceTest.cs">https://github.com/saucelabs-training/demo-csharp/blob/master/SauceExamples/Web.Tests/InstantSauceTest.cs</a>
    </p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Delete the text in the VS file you created and paste in the script you downloaded.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Save the file.</p>
  </li>
</ol>
<h3>Getting Your Access Code on Sauce Labs
</h3>
<p>Before you can run your test on Sauce Labs, you need your user name and access key.
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>Log in to Sauce Labs at <a href="http://www.saucelabs.com">
        <span style="color: rgb(17,85,204);">www.saucelabs.com
      </a>. <br/>If you don’t have a Sauce Labs account you can create one and use Sauce Labs for free for two weeks.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click your name in the <strong>Account Profile</strong> menu in the upper-right corner.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click <strong>User Settings</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Scroll down to <strong>Access Key</strong> and click <strong>Show</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click the <strong>Copy </strong>icon.</p>
  </li>
</ol>
<h3>Updating Your Test Script
</h3>
<p>You need to enter your Sauce Labs user name and access key into the test script. In VS, scroll down until you see:
</p>
<ac:structured-macro ac:macro-id="6a12c42a-7f9c-480d-b46e-58984b99fa95" ac:name="code" ac:schema-version="1">
  <ac:plain-text-body><![CDATA[var sauceUserName = "YOUR USER NAME";
var sauceAccessKey = "YOUR ACCESS KEY";]]></ac:plain-text-body>
</ac:structured-macro>
<p>Enter your own credentials inside the quotes. You should be able to paste in your access key.
</p>
<h3>Running Your Script on Sauce Labs
</h3>
<p>You’re now ready to run your test on Sauce Labs!
</p>
<ol>
  <li style="list-style-type: decimal;">
    <p>In VS, click <strong>Test</strong>, point to <strong>Windows</strong> and click <strong>Test Explorer</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>In the Test Explorer panel, select your test and click <strong>Run All</strong>. <br/>You'll see that the test starts running.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Log in to the Sauce Labs web interface and click <strong>Automated Tests</strong>.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>You'll see that the test <strong>ShouldOpenOnSafari</strong> is running.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>To see the details of the test when it completes, click <strong>ShouldOpenOnSafari</strong>. </p>
  </li>
  <li style="list-style-type: decimal;">
    <p>You'll see that <strong>Test Success</strong> is selected. </p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Click the <strong>Play</strong> button. <br/>You'll see a video of the entire test run. The test opens up the Sauce Labs sample application. It then logs in to the application and clicks the <strong>LogIn</strong> button.</p>
  </li>
  <li style="list-style-type: decimal;">
    <p>Go back to VS. <br/>In the Test Explorer pane, you'll see a green check mark next to your test, which means the test completed successfully. You can also click the <strong>Output</strong> tab to see some details.</p>
  </li>
</ol>
<p>Congratulations, you've just run your first test on Sauce Labs! Now try using <a href="https://wiki.saucelabs.com/display/DOCS/Platform+Configurator#/">our Platform Configurator</a> to change the desired capabilities of your test to run it on different combinations of platform, operating system, and browser. </p>
