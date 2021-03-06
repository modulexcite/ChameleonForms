﻿using ChameleonForms.Enums;
using ChameleonForms.FieldGenerators;
using ChameleonForms.FieldGenerators.Handlers;
using NUnit.Framework;

namespace ChameleonForms.Tests.FieldGenerator.Handlers
{
    class DefaultHandlerShould : FieldGeneratorHandlerTest<string>
    {
        protected override IFieldGeneratorHandler<TestFieldViewModel, string> GetHandler(IFieldGenerator<TestFieldViewModel, string> handler)
        {
            return new DefaultHandler<TestFieldViewModel, string>(handler);
        }

        [Test]
        public void Return_single_text_input_for_display_type()
        {
            var type = GetDisplayType();

            Assert.That(type, Is.EqualTo(FieldDisplayType.SingleLineText));
        }
    }
}
