readEFontBDFForJapaneseFromFile: fileName name: aString overrideWith: otherFileName

	| fontReader stream |
	fontReader _ EFontBDFFontReaderForRanges readOnlyFileNamed: fileName.
	stream _ ReadStream on: (fontReader readRanges: fontReader rangesForJapanese overrideWith: otherFileName otherRanges: {Array with: 8481 with: 12320} additionalOverrideRange: fontReader additionalRangesForJapanese).
	xTable _ stream next.
	glyphs _ stream next.
	minAscii _ stream next.
	maxAscii _ stream next.
	maxWidth _ stream next.
	ascent _ stream next.
	descent _ stream next.
	pointSize _ stream next.
	name _ aString.
	type _ 0. "no one see this"
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	emphasis _ 0.
	self reset.
