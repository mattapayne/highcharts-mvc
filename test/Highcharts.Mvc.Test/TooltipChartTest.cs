﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;

namespace Highcharts.Mvc.Test
{
    [TestFixture]
    public class TooltipChartTest : ConfiguratorTest<TooltipConfigurator>
    {
        [Test]
        public void BasicTooltipSetup()
        {
            var actual = this.Configure(x => x.Shared().Crosshairs());
            var expected = @"tooltip: {
                                shared: true,
                                crosshairs: true
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TooltipAnonymousFormatterSetup()
        {
            var actual = this.Configure(x => x.Formatter("return 'The value for <b>' + this.x + '</b> is <b>' + this.y + '</b>';"));
            var expected = @"tooltip: {
                                formatter: function() {
                                    return 'The value for <b>' + this.x + '</b> is <b>' + this.y +'</b>';
                                }
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TooltipNamedFormatterSetup()
        {
            var actual = this.Configure(x => x.Formatter("myFunction"));
            var expected = @"tooltip: {
                                formatter: myFunction
                            }";

            HtmlAssert.AreEqual(expected, actual);
        }
    }
}