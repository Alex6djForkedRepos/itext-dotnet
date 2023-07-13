using System;
using System.Collections.Generic;
using iText.Commons.Utils;
using iText.StyledXmlParser.Css;
using iText.StyledXmlParser.Css.Resolve.Shorthand.Impl;
using iText.Test;
using iText.Test.Attributes;

namespace iText.StyledXmlParser.Css.Resolve.Shorthand {
    [NUnit.Framework.Category("UnitTest")]
    public class ColumnsShorthandResolverTest : ExtendedITextTest {
        [NUnit.Framework.Test]
        public virtual void InitialOrInheritOrUnsetValuesTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String initialShorthand = CommonCssConstants.INITIAL;
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(initialShorthand);
            NUnit.Framework.Assert.AreEqual(2, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_COUNT, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.INITIAL, resolvedShorthand[0].GetExpression());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[1].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.INITIAL, resolvedShorthand[1].GetExpression());
            String inheritShorthand = CommonCssConstants.INHERIT;
            resolvedShorthand = resolver.ResolveShorthand(inheritShorthand);
            NUnit.Framework.Assert.AreEqual(2, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_COUNT, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.INHERIT, resolvedShorthand[0].GetExpression());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[1].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.INHERIT, resolvedShorthand[1].GetExpression());
            String unsetShorthand = CommonCssConstants.UNSET;
            resolvedShorthand = resolver.ResolveShorthand(unsetShorthand);
            NUnit.Framework.Assert.AreEqual(2, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_COUNT, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.UNSET, resolvedShorthand[0].GetExpression());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[1].GetProperty());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.UNSET, resolvedShorthand[1].GetExpression());
        }

        [NUnit.Framework.Test]
        [LogMessage(iText.StyledXmlParser.Logs.StyledXmlParserLogMessageConstant.SHORTHAND_PROPERTY_CANNOT_BE_EMPTY
            , Count = 2)]
        public virtual void EmptyShorthandTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String emptyShorthand = "";
            NUnit.Framework.Assert.AreEqual(JavaCollectionsUtil.EmptyList<CssDeclaration>(), resolver.ResolveShorthand
                (emptyShorthand));
            String shorthandWithSpaces = "    ";
            NUnit.Framework.Assert.AreEqual(JavaCollectionsUtil.EmptyList<CssDeclaration>(), resolver.ResolveShorthand
                (shorthandWithSpaces));
        }

        [NUnit.Framework.Test]
        public virtual void ColumnsWithOneAbsoluteValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "10px";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("10px", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithOneMetricValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "10px";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("10px", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithOneRelativeValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "10em";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("10em", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithColumnCountTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "3";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_COUNT, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("3", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithAutoValuesTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "auto auto";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.IsTrue(resolvedShorthand.IsEmpty());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithAutoAndRelativeValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "3em auto";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("3em", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithRelativeAndAutoValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "auto 3em";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(1, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("3em", resolvedShorthand[0].GetExpression());
        }

        [NUnit.Framework.Test]
        public virtual void ColumnWithRelativeAndCountValueTest() {
            IShorthandResolver resolver = new ColumnsShorthandResolver();
            String shorthand = "12 3em";
            IList<CssDeclaration> resolvedShorthand = resolver.ResolveShorthand(shorthand);
            NUnit.Framework.Assert.AreEqual(2, resolvedShorthand.Count);
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_COUNT, resolvedShorthand[0].GetProperty());
            NUnit.Framework.Assert.AreEqual("12", resolvedShorthand[0].GetExpression());
            NUnit.Framework.Assert.AreEqual(CommonCssConstants.COLUMN_WIDTH, resolvedShorthand[1].GetProperty());
            NUnit.Framework.Assert.AreEqual("3em", resolvedShorthand[1].GetExpression());
        }
    }
}
