﻿// Copyright 2017-2018 Dirk Lemstra (https://github.com/dlemstra/line-bot-sdk-dotnet)
//
// Dirk Lemstra licenses this file to you under the Apache License,
// version 2.0 (the "License"); you may not use this file except in compliance
// with the License. You may obtain a copy of the License at:
//
//   https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Line.Tests
{
    public partial class MessageActionTests
    {
        [TestClass]
        public class TheConvertMethod
        {
            [TestMethod]
            public void ShouldPreserveInstanceWhenValueIsMessageAction()
            {
                var action = new MessageAction()
                {
                    Label = "Foo",
                    Text = "Test"
                };

                var messageAction = MessageAction.Convert(action);

                Assert.AreSame(action, messageAction);
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenLabelIsNull()
            {
                var action = new MessageAction()
                {
                    Text = "Foo"
                };

                ExceptionAssert.Throws<InvalidOperationException>("The label cannot be null.", () =>
                {
                    MessageAction.Convert(action);
                });
            }

            [TestMethod]
            public void ShouldThrowExceptionWhenTextIsNull()
            {
                var action = new MessageAction()
                {
                    Label = "Test"
                };

                ExceptionAssert.Throws<InvalidOperationException>("The text cannot be null.", () =>
                {
                    MessageAction.Convert(action);
                });
            }

            [TestMethod]
            public void ShouldConvertCustomIActionMessageToActionMessage()
            {
                var action = new TestMessageAction();

                var messageAction = MessageAction.Convert(action);

                Assert.AreNotEqual(action, messageAction);

                Assert.AreEqual("MessageLabel", messageAction.Label);
                Assert.AreEqual("MessageText", messageAction.Text);
            }
        }
    }
}
