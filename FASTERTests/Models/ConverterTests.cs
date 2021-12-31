﻿using FASTER.Models;
using NUnit.Framework;
using System;
using System.Windows.Media;

namespace FASTER.Models.Tests
{
    [TestFixture()]
    public class ProfileModsFilterIsInvalidTextConverterTests
    {
        readonly ProfileModsFilterIsInvalidTextConverter converter = new();

        [Test()]
        public void ConvertTest()
        {
            Assert.AreEqual(" ", converter.Convert(false, typeof(string), null, System.Globalization.CultureInfo.InvariantCulture));
            Assert.AreEqual("Invalid regular expression...", converter.Convert(true, typeof(string), null, System.Globalization.CultureInfo.InvariantCulture));
        }

        [Test()]
        public void ConvertBackTest()
        {
            Assert.Throws<NotImplementedException>(() => converter.ConvertBack(null, null, null, null));
        }
    }

    [TestFixture()]
    public class ProfileModsFilterIsInvalidBackgroundColorConverterTests
    {
        readonly ProfileModsFilterIsInvalidBackgroundColorConverter converter = new();

        [Test()]
        public void ConvertTest()
        {
            SolidColorBrush c1 = converter.Convert(true, typeof(SolidColorBrush), null, System.Globalization.CultureInfo.InvariantCulture) as SolidColorBrush;
            SolidColorBrush c2 = converter.Convert(false, typeof(SolidColorBrush), null, System.Globalization.CultureInfo.InvariantCulture) as SolidColorBrush;

            Assert.AreEqual(new SolidColorBrush(Color.FromRgb(90, 29, 29)).Color, c1.Color);
            Assert.AreEqual(new SolidColorBrush().Color, c2.Color);
        }

        [Test()]
        public void ConvertBackTest()
        {
            Assert.Throws<NotImplementedException>(() => converter.ConvertBack(null, null, null, null));
        }
    }

    [TestFixture()]
    public class ProfileModsFilterIsInvalidBorderColorConverterTests
    {
        readonly ProfileModsFilterIsInvalidBorderColorConverter converter = new();
        [Test()]
        public void ConvertTest()
        {
            SolidColorBrush c1 = converter.Convert(true, typeof(SolidColorBrush), null, System.Globalization.CultureInfo.InvariantCulture) as SolidColorBrush;
            SolidColorBrush c2 = converter.Convert(false, typeof(SolidColorBrush), null, System.Globalization.CultureInfo.InvariantCulture) as SolidColorBrush;

            Assert.AreEqual(new SolidColorBrush(Color.FromRgb(190, 17, 0)).Color, c1.Color);
            Assert.AreEqual(new SolidColorBrush().Color, c2.Color); 
        }

        [Test()]
        public void ConvertBackTest()
        {
            Assert.Throws<NotImplementedException>(() => converter.ConvertBack(null, null, null, null));
        }
    }

    [TestFixture()]
    public class NotBooleanToVisibilityConverterTests
    {
        readonly NotBooleanToVisibilityConverter converter = new();
        [Test()]
        public void ConvertTest()
        {
            Assert.AreEqual(System.Windows.Visibility.Visible, converter.Convert(false, typeof(System.Windows.Visibility), null, System.Globalization.CultureInfo.InvariantCulture));
            Assert.AreEqual(System.Windows.Visibility.Collapsed, converter.Convert(true, typeof(System.Windows.Visibility), null, System.Globalization.CultureInfo.InvariantCulture));
        }

        [Test()]
        public void ConvertBackTest()
        {
            Assert.Throws<NotImplementedException>(() => converter.ConvertBack(null, null, null, null));
        }
    }

    [TestFixture()]
    public class FolderSizeConverterTests
    {
        readonly FolderSizeConverter converter = new();
        [Test()]
        public void ConvertTest()
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            Assert.AreEqual($"   1{separator}00  B", converter.Convert((long)1, typeof(string), null, System.Globalization.CultureInfo.InvariantCulture));
            Assert.AreEqual($"   1{separator}00 KB", converter.Convert((long)1024, typeof(string), null, System.Globalization.CultureInfo.InvariantCulture));
            Assert.AreEqual("0 B", converter.Convert("FAIL", typeof(string), null, System.Globalization.CultureInfo.InvariantCulture));
        }

        [Test()]
        public void ConvertBackTest()
        {
            Assert.IsNull(converter.ConvertBack(1, typeof(string), null, null));
        }
    }
}