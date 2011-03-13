updateFromSelectedFont
	"Update our state based on the selected font."

	|font|
	font := self selectedFont ifNil: [TextStyle defaultFont].
	fontFamilyIndex := (self fontFamilies indexOf: font familyName).
	fontSizeIndex := (self fontSizes indexOf: font pointSize).
	isBold := (font emphasis allMask: TextEmphasis bold emphasisCode).
	isItalic := (font emphasis allMask: TextEmphasis italic emphasisCode).
	isUnderlined := (font emphasis allMask: TextEmphasis underlined emphasisCode).
	isStruckOut := (font emphasis allMask: TextEmphasis struckOut emphasisCode).
	self
		changed: #fontFamilyIndex;
		changed: #fontSizeIndex;
		changed: #isBold;
		changed: #isItalic;
		changed: #isUnderlined;
		changed: #isStruckOut.
	self textPreviewMorph ifNotNilDo: [:tp |
		tp
			font: self selectedFont;
			scrollToTop]