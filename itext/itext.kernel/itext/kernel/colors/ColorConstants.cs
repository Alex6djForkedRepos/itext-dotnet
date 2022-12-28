/*
This file is part of the iText (R) project.
Copyright (c) 1998-2023 iText Group NV
Authors: iText Software.

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License version 3
as published by the Free Software Foundation with the addition of the
following permission added to Section 15 as permitted in Section 7(a):
FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
ITEXT GROUP. ITEXT GROUP DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
OF THIRD PARTY RIGHTS

This program is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU Affero General Public License for more details.
You should have received a copy of the GNU Affero General Public License
along with this program; if not, see http://www.gnu.org/licenses or write to
the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
Boston, MA, 02110-1301 USA, or download the license from the following URL:
http://itextpdf.com/terms-of-use/

The interactive user interfaces in modified source and object code versions
of this program must display Appropriate Legal Notices, as required under
Section 5 of the GNU Affero General Public License.

In accordance with Section 7(b) of the GNU Affero General Public License,
a covered work must retain the producer line in every PDF that is created
or manipulated using iText.

You can be released from the requirements of the license by purchasing
a commercial license. Buying such a license is mandatory as soon as you
develop commercial activities involving the iText software without
disclosing the source code of your own applications.
These activities include: offering paid services to customers as an ASP,
serving PDFs on the fly in a web application, shipping iText with a closed
source product.

For more information, please contact iText Software Corp. at this
address: sales@itextpdf.com
*/
namespace iText.Kernel.Colors {
    /// <summary>
    /// Class containing predefined
    /// <see cref="DeviceRgb"/>
    /// colors.
    /// </summary>
    /// <remarks>
    /// Class containing predefined
    /// <see cref="DeviceRgb"/>
    /// colors.
    /// Color space specific classes should be used for the advanced handling of colors.
    /// The most common ones are
    /// <see cref="DeviceGray"/>
    /// ,
    /// <see cref="DeviceCmyk"/>
    /// and
    /// <see cref="DeviceRgb"/>.
    /// </remarks>
    public class ColorConstants {
        /// <summary>Predefined black DeviceRgb color</summary>
        public static readonly Color BLACK = DeviceRgb.BLACK;

        /// <summary>Predefined blue  DeviceRgb color</summary>
        public static readonly Color BLUE = DeviceRgb.BLUE;

        /// <summary>Predefined cyan DeviceRgb color</summary>
        public static readonly Color CYAN = new DeviceRgb(0, 255, 255);

        /// <summary>Predefined dark gray DeviceRgb color</summary>
        public static readonly Color DARK_GRAY = new DeviceRgb(64, 64, 64);

        /// <summary>Predefined gray DeviceRgb color</summary>
        public static readonly Color GRAY = new DeviceRgb(128, 128, 128);

        /// <summary>Predefined green DeviceRgb color</summary>
        public static readonly Color GREEN = DeviceRgb.GREEN;

        /// <summary>Predefined light gray DeviceRgb color</summary>
        public static readonly Color LIGHT_GRAY = new DeviceRgb(192, 192, 192);

        /// <summary>Predefined magenta DeviceRgb color</summary>
        public static readonly Color MAGENTA = new DeviceRgb(255, 0, 255);

        /// <summary>Predefined orange DeviceRgb color</summary>
        public static readonly Color ORANGE = new DeviceRgb(255, 200, 0);

        /// <summary>Predefined pink DeviceRgb color</summary>
        public static readonly Color PINK = new DeviceRgb(255, 175, 175);

        /// <summary>Predefined red DeviceRgb color</summary>
        public static readonly Color RED = DeviceRgb.RED;

        /// <summary>Predefined white DeviceRgb color</summary>
        public static readonly Color WHITE = DeviceRgb.WHITE;

        /// <summary>Predefined yellow DeviceRgb color</summary>
        public static readonly Color YELLOW = new DeviceRgb(255, 255, 0);
    }
}
