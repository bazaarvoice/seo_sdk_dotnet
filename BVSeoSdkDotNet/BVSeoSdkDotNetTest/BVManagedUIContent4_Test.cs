﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BVSeoSdkDotNet.Config;
using BVSeoSdkDotNet.Content;
using BVSeoSdkDotNet.Model;
using BVSeoSdkDotNet.BVException;
using System.Diagnostics;

namespace BVSEOSDKTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BVManagedUIContent4_Test
    {
        private BVUIContent _bvUIContent;

        private const String CLOUD_KEY = "bodyglove-8e186f6e16e2d688784728b360df41c5";
        private const String DISPLAY_CODE = "Main_Site-en_US";
        private const long CONTENT_RETRIEVAL_THRESHOLD = 1500;
        private Stopwatch stopwatch = new Stopwatch();

        public BVManagedUIContent4_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize()]
        public void BVManagedUIContent4_TestInitialize()
        {
            BVConfiguration _bvConfiguration = new BVSdkConfiguration();
            _bvConfiguration.addProperty(BVClientConfig.BV_ROOT_FOLDER, DISPLAY_CODE);
            _bvConfiguration.addProperty(BVClientConfig.CLOUD_KEY, CLOUD_KEY);
            _bvConfiguration.addProperty(BVClientConfig.LOAD_SEO_FILES_LOCALLY, "false");
            _bvConfiguration.addProperty(BVClientConfig.SEO_SDK_ENABLED, "true");
            _bvConfiguration.addProperty(BVClientConfig.STAGING, "true");
            _bvConfiguration.addProperty(BVClientConfig.EXECUTION_TIMEOUT, "300000");

            _bvUIContent = new BVManagedUIContent(_bvConfiguration);
        }

        [TestMethod]
        public void Test_InlinePage_Review()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.REVIEWS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/reviews";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/reviews/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }

        [TestMethod]
        public void Test_InlinePage_Question() 
        {
		    BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.QUESTIONS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/question";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/questions/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
		    try 
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e) 
            {
			    erroMessage = e.getMessage();
		    }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
		    Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
		    Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
	    }


        [TestMethod]
        public void Test_InlinePage_Stories()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.STORIES);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/story";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/story/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }


        [TestMethod]
        public void Test_SinglePage_Review()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.REVIEWS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/reviews";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/reviews/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }


        [TestMethod]
        public void Test_SinglePage_Question()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.QUESTIONS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/question";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/questions/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }


        [TestMethod]
        public void Test_SinglePage_Stories()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.STORIES);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.BaseURI = "http://www.example.com/store/products/story";
            bvParameters.PageURI = "http://www.example.com/store/products/data-gen-696yl2lg1kurmqxn88fqif5y2/?utm_campaign=bazaarvoice&utm_medium=SearchVoice&utm_source=RatingsAndReviews&utm_content=Default&bvrrp=Main_Site-en_US/story/product/2/50524.htm";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }


        [TestMethod]
        public void TestSEOContentFrom_Using_HTTPS()
        {
            BVConfiguration bvConfig = new BVSdkConfiguration();
            bvConfig.addProperty(BVClientConfig.SSL_ENABLED, "true");
            bvConfig.addProperty(BVClientConfig.CLOUD_KEY, "myshco-69cb945801532dcfb57ad2b0d2471b68");
            bvConfig.addProperty(BVClientConfig.BV_ROOT_FOLDER, "Main_Site-en_US");
            bvConfig.addProperty(BVClientConfig.EXECUTION_TIMEOUT, "6000");
            bvConfig.addProperty(BVClientConfig.STAGING, "true");
            BVUIContent uiContent = new BVManagedUIContent(bvConfig);

            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.REVIEWS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "12345";
            bvParameters.PageURI = "http://localhost:8080/sample/xyz.jsp";

            String theUIContent = uiContent.getContent(bvParameters);
            Assert.AreEqual<Boolean>(theUIContent.Contains("bvseo-reviewsSection"), true, "there should be bvseo-reviewsSection in the content");
        }

        [TestMethod]
        public void Test_ExternalPage_Review()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.REVIEWS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.PageNumber = "2";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }

        [TestMethod]
        public void Test_ExternalPage_Question()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.QUESTIONS);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.PageNumber = "2";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }


        [TestMethod]
        public void Test_ExternalPage_Stories()
        {
            BVParameters bvParameters = new BVParameters();
            bvParameters.UserAgent = "google";
            bvParameters.ContentType = new BVContentType(BVContentType.STORIES);
            bvParameters.SubjectType = new BVSubjectType(BVSubjectType.PRODUCT);
            bvParameters.SubjectId = "50524";
            bvParameters.PageNumber = "2";
            String erroMessage = null;
            String content = null;
            try
            {
                stopwatch.Restart();
                content = _bvUIContent.getContent(bvParameters);
                stopwatch.Stop();
            }
            catch (BVSdkException e)
            {
                erroMessage = e.getMessage();
            }

            Assert.IsTrue(stopwatch.ElapsedMilliseconds <= CONTENT_RETRIEVAL_THRESHOLD, String.Format("Content retrieval time exceeded {0} milliseconds", CONTENT_RETRIEVAL_THRESHOLD));
            Assert.IsNull(erroMessage, "There should not be any errorMessage");
            Assert.IsNotNull(content, "There should be content to proceed further assertion!!");
            Assert.IsFalse(content.Contains("HTTP 403 Forbidden"), "There should be valid content");
        }
    }
}
