/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
Authors: iText Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using iText.IO.Util;
using iText.Kernel.Actions;

namespace iText.Kernel.Pdf.Statistics {
    /// <summary>Statistics aggregator which aggregates number of pages in PDF documents.</summary>
    public class NumberOfPagesStatisticsAggregator : AbstractStatisticsAggregator {
        private const int ONE = 1;

        private const int TEN = 10;

        private const int HUNDRED = 100;

        private const int THOUSAND = 1000;

        private const String STRING_FOR_ONE_PAGE = "1";

        private const String STRING_FOR_TEN_PAGES = "2-10";

        private const String STRING_FOR_HUNDRED_PAGES = "11-100";

        private const String STRING_FOR_THOUSAND_PAGES = "101-1000";

        private const String STRING_FOR_INF = "1001+";

        private static readonly IDictionary<int, String> NUMBERS_OF_PAGES;

        // This List must be sorted.
        private static readonly IList<int> SORTED_UPPER_BOUNDS_OF_PAGES = JavaUtil.ArraysAsList(ONE, TEN, HUNDRED, 
            THOUSAND);

        static NumberOfPagesStatisticsAggregator() {
            IDictionary<int, String> temp = new Dictionary<int, String>();
            temp.Put(ONE, STRING_FOR_ONE_PAGE);
            temp.Put(TEN, STRING_FOR_TEN_PAGES);
            temp.Put(HUNDRED, STRING_FOR_HUNDRED_PAGES);
            temp.Put(THOUSAND, STRING_FOR_THOUSAND_PAGES);
            NUMBERS_OF_PAGES = JavaCollectionsUtil.UnmodifiableMap(temp);
        }

        private readonly Object Lock = new Object();

        private readonly IDictionary<String, AtomicLong> numberOfDocuments = new ConcurrentDictionary<String, AtomicLong
            >();

        /// <summary>Aggregates number of pages from the provided event.</summary>
        /// <param name="event">
        /// 
        /// <see cref="NumberOfPagesStatisticsEvent"/>
        /// instance
        /// </param>
        public override void Aggregate(AbstractStatisticsEvent @event) {
            if (!(@event is NumberOfPagesStatisticsEvent)) {
                return;
            }
            int numberOfPages = ((NumberOfPagesStatisticsEvent)@event).GetNumberOfPages();
            String range = STRING_FOR_INF;
            foreach (int upperBound in SORTED_UPPER_BOUNDS_OF_PAGES) {
                if (numberOfPages <= upperBound) {
                    range = NUMBERS_OF_PAGES.Get(upperBound);
                    break;
                }
            }
            lock (Lock) {
                AtomicLong documentsOfThisRange = numberOfDocuments.Get(range);
                if (documentsOfThisRange == null) {
                    numberOfDocuments.Put(range, new AtomicLong(1));
                }
                else {
                    documentsOfThisRange.IncrementAndGet();
                }
            }
        }

        /// <summary>Retrieves Map where keys are ranges of pages and values are the amounts of such PDF documents.</summary>
        /// <returns>
        /// aggregated
        /// <see cref="System.Collections.IDictionary{K, V}"/>
        /// </returns>
        public override Object RetrieveAggregation() {
            return numberOfDocuments;
        }
    }
}
