/*
This file is part of the iText (R) project.
Copyright (c) 1998-2023 iText Group NV
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

namespace iText.Forms.Logs {
    /// <summary>Class containing constants to be used in logging in forms module.</summary>
    public sealed class FormsLogMessageConstants {
        public const String ACROFORM_NOT_SUPPORTED_FOR_SELECT = "AcroForm fields creation for select fields (ComboBoxField and ListBoxField) is not supported. They will "
             + "be flattened instead.";

        public const String ANNOTATION_IN_ACROFORM_DICTIONARY = "Annotation is noticed directly in fields array " 
            + "of AcroForm dictionary. It violates pdf specification.";

        public const String CANNOT_CREATE_FORMFIELD = "Cannot create form field from a given PDF object: {0}";

        public const String ERROR_WHILE_LAYOUT_OF_FORM_FIELD = "Cannot layout form field field. It won't be displayed";

        public const String ERROR_WHILE_LAYOUT_OF_FORM_FIELD_WITH_TYPE = "Error during layout of form filed with type {0}.";

        public const String CANNOT_MERGE_FORMFIELDS = "Cannot merge form fields with the same fully qualified " + 
            "names. Partial name is {0}. Field type (FT), value (V), and default value (DV) should be the same";

        public const String FORM_FIELD_WAS_FLUSHED = "A form field was flushed. There's no way to create this field in the AcroForm dictionary.";

        public const String INCORRECT_PAGEROTATION = "Encounterd a page rotation that was not a multiple of 90°/ (Pi/2) when generating default appearances "
             + "for form fields";

        public const String INPUT_FIELD_DOES_NOT_FIT = "Input field doesn't fit in outer object. It will be clipped";

        public const String N_ENTRY_IS_REQUIRED_FOR_APPEARANCE_DICTIONARY = "\\N entry is required to be present in an appearance dictionary.";

        public const String NO_FIELDS_IN_ACROFORM = "Required AcroForm entry /Fields does not exist in the document. Empty array /Fields will be created.";

        public const String PROVIDE_FORMFIELD_NAME = "No form field name provided. Process will not be continued.";

        public const String UNSUPPORTED_COLOR_IN_DA = "Unsupported color in FormField's DA";

        public const String FIELDNAME_NOT_FOUND_OPERATION_CAN_NOT_BE_COMPLETED = "Fieldname: <{0}> not found. Operation can not be completed.";

        private FormsLogMessageConstants() {
        }
    }
}
